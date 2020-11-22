using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VxFormGenerator.Core.Layout;

namespace VxFormGenerator.Core.Components
{
    public class VxFormRowComponent: OwningComponentBase
    {
        [Parameter] public Layout.VxFormRow FormRowDefinition { get; set; }
    }
}

