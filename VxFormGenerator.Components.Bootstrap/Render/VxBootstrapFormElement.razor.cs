using System.Collections.Generic;
using VxFormGenerator.Core;

namespace VxFormGenerator.Render.Bootstrap
{

    public class VxBootstrapFormElementComponent<TFormElement> : FormElementBase<TFormElement>
    {
        public VxBootstrapFormElementComponent()
        {
            DefaultFieldClasses = new List<string>() { "form-control"};
            CssClasses = new List<string>() { "form-group", "row" };
        }
    }
}
