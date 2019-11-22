using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDCheckBoxBase : MDCheckBoxUnmanagedBase
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        [Parameter] public Action<bool> OnCheckedChange { get; set; }
        protected void OnChangeHandler(ChangeEventArgs ev)
        {
            Value = (bool)ev.Value;
            if (OnCheckedChange != null)
            {
                OnCheckedChange.Invoke(Value.Value);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
