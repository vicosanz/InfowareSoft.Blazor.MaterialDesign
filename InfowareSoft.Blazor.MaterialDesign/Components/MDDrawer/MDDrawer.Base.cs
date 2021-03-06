﻿using InfowareSoft.Blazor.MaterialDesign.Components.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components
{
    public class MDDrawerBase : DOMComponent
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Add("mdc-drawer")
                .Variant(() => Variant.GetName());
        }
        [Parameter] public MDDrawerVariant Variant { get; set; } = MDDrawerVariant.Default;
    }
}
