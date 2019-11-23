using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDDrawerVariant
    {
        [Html]
        Default,
        [Html("mdc-drawer--dismissible")]
        Dismisable,
        [Html("mdc-drawer--modal")]
        Modal,
    }
}
