using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using CMS.Helpers;

using Microsoft.AspNetCore.Mvc;

namespace XpandableSection.Controllers
{
    public class XpandableSectionController : Controller
    {
        private static readonly Assembly assembly = typeof(XpandableSectionController).Assembly;

        public static IDictionary<string, byte[]> Resources = assembly
            .GetManifestResourceNames()
            .ToDictionary(
                resourceName => resourceName,
                resourceName =>
                {
                    var resourceStream = assembly.GetManifestResourceStream(resourceName);

                    using var stream = new MemoryStream();

                    resourceStream.CopyTo(stream);

                    return stream.ToArray();
                });

        [HttpGet]
        [ResponseCache(Duration = 60 * 60)]
        [Route("xpandableSection/{*resourceName}")]
        public ActionResult Get(string resourceName)
        {
            try
            {
                var resource = Resources
                    .FirstOrDefault(resource => resource.Key.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));

                if (resource.Value != null)
                {
                    return File(resource.Value, GetMediaType(resourceName), resourceName);
                }

                if (CacheHelper.TryGetItem(resourceName, out string value))
                {
                    return File(Encoding.UTF8.GetBytes(value), GetMediaType(resourceName), resourceName);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public static string Create(string content, string type)
        {
            var name = SecurityHelper.GetSHA2Hash(content);

            CacheHelper.Cache(() => content, new CacheSettings(60, $"{name}.{type}"));

            return name;
        }

        private string GetMediaType(string resourceName)
        {
            return resourceName switch
            {
                var _ when resourceName.EndsWith(".js") => "text/javascript",
                var _ when resourceName.EndsWith(".css") => "text/css",
                var _ when resourceName.EndsWith(".ttf") => "font/ttf",
                _ => "application/octet-stream",
            };
        }
    }
}