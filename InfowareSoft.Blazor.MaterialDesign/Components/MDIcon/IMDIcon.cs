using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public interface IMDIcon
    {
        [Parameter] MDIconEnum Icon { get; set; }

    }
}
