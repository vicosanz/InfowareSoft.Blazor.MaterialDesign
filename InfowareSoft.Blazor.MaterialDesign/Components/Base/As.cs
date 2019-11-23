using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Components.CompilerServices;
using RuntimeHelpers = Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers;

namespace InfowareSoft.Blazor.MaterialDesign.Components.Base
{
    public class As : DOMComponent
    {
        [Parameter] public string Tag { get; set; }

        [Parameter] public ElementReference ElementRef { get; set; }
        [Parameter] public Action<ElementReference> ElementRefChanged { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenElement(0, Tag);
            builder.AddAttribute(1, "class", ClassMapper.Class);
            builder.AddMultipleAttributes(2, 
                RuntimeHelpers.TypeCheck<IEnumerable<
                        KeyValuePair<string, object>>>(Attributes));
            builder.AddAttribute(3, "Id", Id);
            builder.AddElementReferenceCapture(4, captureRef => 
            {
                ElementRef = captureRef;
                ElementRefChanged?.Invoke(ElementRef);
            });
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }
    }
}
