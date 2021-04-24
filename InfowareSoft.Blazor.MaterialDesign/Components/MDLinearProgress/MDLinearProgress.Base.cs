using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDLinearProgressBase : DOMComponent
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Add("mdc-linear-progress")
                .Variant(() => Variant.GetName())
                .If(() => IsClosed, "mdc-linear-progress--closed");
        }

        [Parameter] public MDLinearProgressVariant Variant { get; set; } = MDLinearProgressVariant.Default;
        [Parameter] public bool IsClosed { get; set; }

        private int mProgress = 0;
        [Parameter]
        public int Progress
        {
            get => mProgress;
            set
            {
                mProgress = value;
                WhenRenderFinished(async () =>
                {
                    await JsInvokeAsync<object>("mdcjs.mdLinearProgress.setProgress", Ref, (decimal)value / 100);
                });
            }
        }

        private int mBuffer = 0;
        [Parameter]
        public int Buffer
        {
            get => mBuffer;
            set
            {
                mBuffer = value;
                WhenRenderFinished(async () =>
                {
                    await JsInvokeAsync<object>("mdcjs.mdLinearProgress.setBuffer", Ref, (decimal)value / 100);
                });
            }
        }

        private DotNetObjectReference<MDLinearProgressBase> mDotNetObjectRef = null;
        public DotNetObjectReference<MDLinearProgressBase> DotNetObjectRef => mDotNetObjectRef ??= CreateDotNetObjectRef(this);

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(mDotNetObjectRef);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsInvokeAsync<object>("mdcjs.mdLinearProgress.init", Ref);
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
