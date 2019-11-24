using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDLinearProgressVariant
    {
        [Html]
        Default,
        [Html("mdc-linear-progress--indeterminate")]
        Indeterminate,
        [Html("mdc-linear-progress--reversed")]
        Reversed,
    }
}
