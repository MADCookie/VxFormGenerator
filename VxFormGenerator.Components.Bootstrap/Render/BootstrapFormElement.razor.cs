using System.Collections.Generic;
using VxFormGenerator.Core;

namespace VxFormGenerator.Render
{

    public class BootstrapFormElementComponent<TFormElement> : FormElementBase<TFormElement>
    {
        public BootstrapFormElementComponent()
        {
            DefaultFieldClasses = new List<string>() { "form-control"};
            CssClasses = new List<string>() { "form-group", "row" };
        }
    }
}
