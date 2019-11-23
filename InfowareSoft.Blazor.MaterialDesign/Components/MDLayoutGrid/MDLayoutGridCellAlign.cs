using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDLayoutGridCellAlign
    {
        [Html]
        Default,
        [Html("mdc-layout-grid__cell--align-top")]
        Top,
        [Html("mdc-layout-grid__cell--align-middle")]
        Middle,
        [Html("mdc-layout-grid__cell--align-bottom")]
        Bottom,
    }
}
