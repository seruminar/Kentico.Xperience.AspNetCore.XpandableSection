using CMS.DataEngine;

using Kentico.Forms.Web.Mvc;

using XpandableSection.FormComponents;

[assembly: RegisterFormComponent(
    StylesEditorFormComponent.Id,
    typeof(StylesEditorFormComponent),
    "{$XpandableSection.FormComponent$}",
    ViewName = "FormComponents/_StylesEditorFormComponent"
    )]

namespace XpandableSection.FormComponents
{
    public class StylesEditorFormComponentProperties : FormComponentProperties<string>
    {
        public StylesEditorFormComponentProperties()
            : base(FieldDataType.Text)
        {
        }

        public override string DefaultValue { get; set; }
    }

    public class StylesEditorFormComponent : FormComponent<StylesEditorFormComponentProperties, string>
    {
        public const string Id = "StylesEditor.FormComponent";

        [BindableProperty]
        public string Styles { get; set; }

        public override string GetValue() => Styles;

        public override void SetValue(string value) => Styles = value;
    }
}