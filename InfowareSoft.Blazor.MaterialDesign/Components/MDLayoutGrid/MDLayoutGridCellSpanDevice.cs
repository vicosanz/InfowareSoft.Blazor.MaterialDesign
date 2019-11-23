using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDLayoutGridCellSpanDevice
    {
        [Html]
        Default,
        [Html("desktop")]
        Desktop,
        [Html("tablet")]
        Tablet,
        [Html("phone")]
        Phone,
    }
}
