using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDRadioUnmanagedBase : DOMComponent, IFormField
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Base("mdc-radio")
                .If(() => Disabled, "mdc-radio--disabled")
                .If(() => TouchWrapper != null, "mdc-radio--touch");
        }

        [CascadingParameter(Name = "MDTouchWrapper")] public MDTouchWrapper TouchWrapper { get; set; }
        [CascadingParameter(Name = "MDFormField")] public MDForm_Field ContainerFormField { get; set; }
        [CascadingParameter(Name = "MDListItem")] public MDList_Item MDListItem { get; set; }

        [Parameter] public string LabelledBy { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public bool Checked { get; set; } = false;

        [Parameter] public bool Disabled { get; set; }
        protected string DisabledInput => Disabled ? "disabled" : null;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (MDListItem != null)
                {
                    await JsInvokeAsync<object>("mdcjs.mdRadio.init", Ref, ContainerFormField?.Ref);
                }
            }
        }
    }
}
