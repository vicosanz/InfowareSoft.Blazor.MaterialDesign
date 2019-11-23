using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDCheckBoxUnmanagedBase : DOMComponent, IFormField
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Add("mdc-checkbox")
                .If(() => Disabled, "mdc-checkbox--disabled")
                .If(() => TouchWrapper != null, "mdc-checkbox--touch");
        }

        [CascadingParameter(Name = "MDTouchWrapper")] public MDTouchWrapper TouchWrapper { get; set; }
        [CascadingParameter(Name = "MDFormField")] public MDForm_Field ContainerFormField { get; set; }
        [CascadingParameter(Name = "MDListItem")] public MDList_Item MDListItem { get; set; }

        [Parameter] public string LabelledBy { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool? Value { get; set; } = false;
        protected string ValueIndeterminate => !Value.HasValue ? "true" : null;

        [Parameter] public bool Disabled { get; set; }
        protected string DisabledInput => Disabled ? "disabled" : null;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (MDListItem != null)
                {
                    await JsInvokeAsync<object>("mdcjs.mdCheckBox.init", Ref, ContainerFormField?.Ref, !Value.HasValue);
                }
            }
        }
    }
}
