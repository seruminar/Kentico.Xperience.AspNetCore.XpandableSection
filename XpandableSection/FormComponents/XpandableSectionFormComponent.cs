using CMS.DataEngine;

using Kentico.Forms.Web.Mvc;

using XpandableSection.FormComponents;

[assembly: RegisterFormComponent(
    XpandableSectionFormComponent.Id,
    typeof(XpandableSectionFormComponent),
    "{$XpandableSection.FormComponent$}",
    ViewName = "FormComponents/_XpandableSectionFormComponent"
    )]

namespace XpandableSection.FormComponents
{
    public class XpandableSectionFormComponentProperties : FormComponentProperties<string>
    {
        public XpandableSectionFormComponentProperties()
            : base(FieldDataType.Text)
        {
        }

        public override string DefaultValue { get; set; }
    }

    public class XpandableSectionFormComponent : FormComponent<XpandableSectionFormComponentProperties, string>
    {
        public const string Id = "XpandableSection.FormComponent";

        [BindableProperty]
        public string Json { get; set; }

        public override string GetValue() => Json;

        public override void SetValue(string value) => Json = value;
    }
}