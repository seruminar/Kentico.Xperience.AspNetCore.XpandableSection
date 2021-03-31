using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using XpandableSection.FormComponents;
using XpandableSection.Models;
using XpandableSection.Sections;

[assembly: RegisterSection(
    "XpandableSection.Section",
    "{$XpandableSection.Section$}",
    typeof(XpandableSectionProperties),
    "Sections/_XpandableSection",
    IconClass = "icon-l-lightbox"
    )]

namespace XpandableSection.Sections
{
    public class XpandableSectionProperties : ISectionProperties
    {
        [EditingComponent(XpandableSectionFormComponent.Id, Label = "{$XpandableSection.Layout$}")]
        public string Json { get; set; } = JsonConvert.SerializeObject(
            new Section
            {
                Name = "section"
            },
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }
        );

        [EditingComponent(StylesEditorFormComponent.Id, Label = "{$XpandableSection.Styles$}", ExplanationText = "{$XpandableSection.StylesExplanation$}")]
        public string Styles { get; set; } = JsonConvert.SerializeObject(string.Empty);
    }
}