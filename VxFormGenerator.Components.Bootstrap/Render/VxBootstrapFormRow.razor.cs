using Microsoft.AspNetCore.Components;
using VxFormGenerator.Core.Layout;

namespace VxFormGenerator.Render.Bootstrap
{
    public class VxBootstrapFormRowComponent : OwningComponentBase
    {
        [Parameter] public Core.Layout.VxFormRow FormRowDefinition { get; set; }
    }
}

