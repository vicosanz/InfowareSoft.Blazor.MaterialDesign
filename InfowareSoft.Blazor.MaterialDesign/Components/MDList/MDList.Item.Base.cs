using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDListItemBase : DOMComponent, IListItem
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Base("mdc-list-item");

            ClassMapperRole
                .If(() => IsListBox(), "option")
                .If(() => IsRadio(), "radio")
                .If(() => IsCheckBox(), "checkbox");

            if (!List.ListItems.Any())
            {
                TabIndex = "0";
            }
            List.ListItems.Add(this);
        }

        protected bool IsListBox() => List?.Role == MDListBase.MDListRole.ListBox;
        protected bool IsRadio() => List?.Role == MDListBase.MDListRole.RadioGroup;
        protected bool IsCheckBox() => List?.Role == MDListBase.MDListRole.CheckBox;

        protected bool IsTwoLine()
        {
            return List?.Style ==  MDListBase.MDListStyle.TwoLine;
        }

        [CascadingParameter(Name = "MDList")] public MDList List { get; set; }

        protected ClassMapper ClassMapperRole = new ClassMapper();

        [Parameter] public string Name { get; set; }
        [Parameter] public string Text { get; set; }
        [Parameter] public string SecondaryText { get; set; }
        [Parameter] public string TabIndex { get; set; }
        [Parameter] public string Value { get; set; }

    }
}
