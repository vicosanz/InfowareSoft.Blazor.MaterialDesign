using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public enum MDCardMediaVariant
    {
        [Html]
        Default,
        [Html("mdc-card__media--square")]
        Square,
        [Html("mdc-card__media--16-9")]
        Aspect16_9,
    }
}
