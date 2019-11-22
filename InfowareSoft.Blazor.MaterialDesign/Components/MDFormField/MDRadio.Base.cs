using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDRadioBase : MDRadioUnmanagedBase
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        [Parameter] public Action<bool> OnCheckedChange { get; set; }
        protected void OnChangeHandler(ChangeEventArgs ev)
        {
            Checked = ev.Value.ToString() == "on";
            if (OnCheckedChange != null)
            {
                OnCheckedChange.Invoke(Checked);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
