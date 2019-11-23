using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDLayoutGridAlign
    {
        [Html]
        Default,
        [Html("mdc-layout-grid--align-left")]
        Left,
        [Html("mdc-layout-grid--align-right")]
        Right,
    }
}
