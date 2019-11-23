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
            ClassMapper.Add("mdc-list-item");

            ClassMapperRole
                .If(() => IsListBox(), "option")
                .If(() => IsRadio(), "radio")
                .If(() => IsCheckBox(), "checkbox");

            if (List != null)
            {
                if (List.Tag == MDListAs.ul)
                {
                    Tag = MDListItemAs.li;
                }
                if (List.Tag == MDListAs.nav)
                {
                    Tag = MDListItemAs.a;
                }

                Name = List.Name;
                if (!List.ListItems.Any())
                {
                    TabIndex = "0";
                }
                List.ListItems.Add(this);
            }
        }
        protected MDListItemAs Tag { get; set; } = MDListItemAs.li;
        protected bool IsListBox() => List?.Role == MDListRole.ListBox;
        protected bool IsRadio() => List?.Role == MDListRole.RadioGroup;
        protected bool IsCheckBox() => List?.Role == MDListRole.CheckBox;

        protected bool IsTwoLine()
        {
            return List?.Variant == MDListVariant.TwoLine;
        }

        [CascadingParameter(Name = "MDList")] public MDList List { get; set; }

        protected ClassMapper ClassMapperRole = new ClassMapper();

        protected string Name { get; set; } = "Name" + Guid.NewGuid().ToString();
        [Parameter] public MDIconEnum? Icon { get; set; }
        [Parameter] public MDIconEnum? TrailingIcon { get; set; }

        [Parameter] public string Text { get; set; }
        [Parameter] public string SecondaryText { get; set; }
        [Parameter] public string TabIndex { get; set; }
        [Parameter] public string Value { get; set; }
    }
}
