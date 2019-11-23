using InfowareSoft.Blazor.MaterialDesign.Components.Base;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDButtonStyle
    {
        [Html]
        Default,
        [Html("mdc-button--raised")]
        Raised,
        [Html("mdc-button--unelevated")]
        Unelevated,
        [Html("mdc-button--outlined")]
        Outlined
    }
}
