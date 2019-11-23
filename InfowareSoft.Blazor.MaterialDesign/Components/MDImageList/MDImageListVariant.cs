using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDImageListVariant
    {
        [Html]
        Default,
        [Html("mdc-image-list--masonry")]
        Masonry,
        [Html("mdc-image-list--with-text-protection")]
        WithTextProtection,
    }
}
