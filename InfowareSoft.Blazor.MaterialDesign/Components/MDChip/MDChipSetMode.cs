using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDChipSetMode
    {
        [Html]
        Default,
        [Html("mdc-chip-set--choice")]
        Choose,
        [Html("mdc-chip-set--filter")]
        Filter,
        [Html("mdc-chip-set--input")]
        Input
    }
}
