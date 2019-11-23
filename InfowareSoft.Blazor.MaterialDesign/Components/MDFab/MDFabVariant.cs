using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDFabVariant
    {
        [Html]
        Default,
        [Html("mdc-fab--mini")]
        Mini,
        [Html("mdc-fab--extended")]
        Extended
    }
}
