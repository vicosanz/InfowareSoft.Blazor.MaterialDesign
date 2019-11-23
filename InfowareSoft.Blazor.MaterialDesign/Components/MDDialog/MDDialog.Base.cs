using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDDialogBase : DOMComponent
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Add("mdc-dialog");
        }

        [Parameter] public string Title { get; set; }
        [Parameter] public string LabelledBy { get; set; }
        [Parameter] public string DescribedBy { get; set; }
        [Parameter] public Action<bool> OnDialogOpenChange { get; set; }

        private bool mIsOpen = false;
        [Parameter]
        public bool IsOpen
        {
            get => mIsOpen;
            set
            {
                mIsOpen = value;

                WhenRenderFinished(async () =>
                {
                    await JsInvokeAsync<object>("mdcjs.mdDialog.isOpen", Ref, mIsOpen);
                });
            }
        }

        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }

        private bool mIsEnableEscKey = false;
        [Parameter]
        public bool IsEnableEscKey
        {
            get => mIsEnableEscKey;
            set
            {
                if (IsEnableEscKey != value)
                {
                    mIsEnableEscKey = value;
                    WhenRenderFinished(async () =>
                    {
                        await JsInvokeAsync<object>("matBlazor.matDialog.setCanBeClosed", Ref, value);
                    });
                }
            }
        }

        private DotNetObjectReference<MDDialogBase> mDotNetObjectRef = null;
        public DotNetObjectReference<MDDialogBase> DotNetObjectRef => mDotNetObjectRef = mDotNetObjectRef ?? CreateDotNetObjectRef(this);

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(mDotNetObjectRef);
        }

        [JSInvokable]
        public async Task ClosedHandler()
        {
            mIsOpen = false;
            await IsOpenChanged.InvokeAsync(false);
            OnDialogOpenChange?.Invoke(mIsOpen);
        }

        [JSInvokable]
        public async Task OpenedHandler()
        {
            mIsOpen = true;
            await IsOpenChanged.InvokeAsync(true);
            OnDialogOpenChange?.Invoke(mIsOpen);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsInvokeAsync<object>("mdcjs.mdDialog.init", Ref);
                await JsInvokeAsync<object>("mdcjs.mdDialog.onEventsListener", Ref, DotNetObjectRef);
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
