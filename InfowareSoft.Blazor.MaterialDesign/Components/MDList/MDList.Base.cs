using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDListBase : DOMComponent
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Base("mdc-list")
                .Style(() => Style.GetName());
        }

        [Parameter] public string Name { get; set; } = "Name" + Guid.NewGuid().ToString();
        [Parameter] public MDListStyle Style { get; set; } = MDListStyle.Default;
        [Parameter] public MDListRole Role { get; set; } = MDListRole.ListBox;
        private int mSelectedIndex = -1;
        [Parameter]
        public int SelectedIndex
        {
            get => mSelectedIndex;
            set
            {
                mSelectedIndex = value;

                WhenRenderFinished(async () =>
                {
                    await JsInvokeAsync<object>("mdcjs.mdList.setSelectedIndex", Ref, mSelectedIndex);
                });
            }
        }
        private int[] mSelectedIndexes = new List<int>().ToArray();
        [Parameter]
        public int[] SelectedIndexes
        {
            get => mSelectedIndexes;
            set
            {
                mSelectedIndexes = value;

                WhenRenderFinished(async () =>
                {
                    await JsInvokeAsync<object>("mdcjs.mdList.setSelectedIndex", Ref, mSelectedIndexes);
                });
            }
        }
        public List<IListItem> ListItems { get; } = new List<IListItem>();

        private DotNetObjectReference<MDListBase> mDotNetObjectRef = null;

        public DotNetObjectReference<MDListBase> DotNetObjectRef => mDotNetObjectRef = mDotNetObjectRef ?? CreateDotNetObjectRef(this);

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(mDotNetObjectRef);
        }

        [JSInvokable]
        public async Task ActionItemHandler(int index, params int[] selectedIndexes)
        {
            mSelectedIndex = index;
            mSelectedIndexes = selectedIndexes;
            await Task.CompletedTask;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsInvokeAsync<object>("mdcjs.mdList.init", Ref);
                await JsInvokeAsync<object>("mdcjs.mdList.onActionItem", Ref, DotNetObjectRef);
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public enum MDListStyle
        {
            [Html]
            Default,
            [Html("mdc-list--two-line")]
            TwoLine
        }
        public enum MDListRole
        {
            [Html("listbox")]
            ListBox,
            [Html("radiogroup")]
            RadioGroup,
            [Html("group")]
            CheckBox
        }
    }
}
