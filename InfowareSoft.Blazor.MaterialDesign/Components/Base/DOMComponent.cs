using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfowareSoft.Blazor.MaterialDesign.Components.Base
{
    public abstract class DOMComponent : BaseComponent
    {
        [Parameter]
        public string Id { get; set; } = $"mdid_{Guid.NewGuid().ToString()}";

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }
        public ElementReference Ref { get; set; }

        protected ClassMapper ClassMapper { get; } = new ClassMapper();

        [Parameter]
        public string Class { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Add(Class);
        }
    }
}
