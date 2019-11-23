using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDDataTablerHeaderCellStyle
    {
        [Html]
        Default,
        [Html("mdc-data-table__header-cell--checkbox")]
        CheckBox,
        [Html("mdc-data-table__header-cell--numeric")]
        Numeric,
    }
}
