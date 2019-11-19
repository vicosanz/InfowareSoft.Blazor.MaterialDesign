using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDListBase : DOMComponent
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Base("mdc-list")
                .Style(() => Style.GetCssName());
        }

        [Parameter] public MDListStyle Style { get; set; } = MDListStyle.Default;
        [Parameter] public MDListRole Role { get; set; } = MDListRole.ListBox;
        public List<IListItem> ListItems { get; } = new List<IListItem>();

        public enum MDListStyle
        {
            [Html]
            Default,
            [Html("mdc-list--two-line")]
            TwoLine
        }
        public enum MDListRole
        {
            [Html(rolName: "listbox")]
            ListBox,
            [Html(rolName: "radiogroup")]
            RadioGroup,
            [Html(rolName: "group")]
            CheckBox
        }
    }
}
