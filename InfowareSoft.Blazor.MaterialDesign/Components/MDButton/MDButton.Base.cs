using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public partial class MDButtonBase: DOMComponent
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Base("mdc-button")
                .Style(() => Style.GetName())
                .If(() => Disabled, "Disabled");
        }

        [CascadingParameter(Name = "MDTouchWrapper")] public MDTouchWrapper TouchWrapper { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public MDIconEnum? Icon { get; set; }
        [Parameter] public MDIconEnum? TrailingIcon { get; set; }

        [Parameter] public bool Disabled { get; set; }
        protected string DisabledCss => Disabled ? "Disabled" : null;

        [Parameter] public MDButtonStyle Style { get; set; } = MDButtonStyle.Default;

        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        protected void OnClickHandler(MouseEventArgs ev)
        {
            OnClick.InvokeAsync(ev);
        }

        [Parameter] public string DialogAction { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsInvokeAsync<object>("mdcjs.mdButton.init", Ref);
            }
        }

    }
}
