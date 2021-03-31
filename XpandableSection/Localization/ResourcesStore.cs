using System;
using System.Collections.Generic;

using Kentico.Web.Mvc.Internal;

using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace XpandableSection.Localization
{
    public class ResourcesStore
    {
        private readonly CaseInsensitiveResourceManagerStringLocalizerFactory factory;

        public ResourcesStore(ILoggerFactory loggerFactory)
        {
            factory = new CaseInsensitiveResourceManagerStringLocalizerFactory(Options.Create(new LocalizationOptions()), loggerFactory);
        }

        public IDictionary<string, string> GetResources(Type resourceType, string cultureCode)
        {
            var resources = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var localizer = factory.CreateLocalizerWithCulture(resourceType, cultureCode);

            foreach (var localizedString in localizer.GetAllStrings())
            {
                resources.TryAdd(localizedString.Name, localizedString.Value);
            }

            return resources;
        }
    }
}