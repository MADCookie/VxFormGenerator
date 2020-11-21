
using System;
using System.Reflection;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormColumn : ICloneable
    {

        public int ColSpan { get; set; }
        public string Name { get; private set; }
        public int Order { get; private set; }
        public PropertyInfo Property { get; set; }
        public object Model { get; private set; }

        public VxFormColumn(PropertyInfo prop)
        {
            Property = prop;
        }

        public VxFormColumn(PropertyInfo prop, VxFormLayoutAttribute layoutAttr, object modelInstance)
        {
            ColSpan = layoutAttr.ColSpan;
            Name = layoutAttr.Name;
            Order = layoutAttr.Order;

            Property = prop;
            Model = modelInstance;
        }

        public object Clone()
        {
            return new VxFormColumn(this.Property) { ColSpan = this.ColSpan };
        }

        internal static VxFormColumn Create(PropertyInfo prop, VxFormLayoutAttribute layoutAttr, object modelInstance)
        {
            return new VxFormColumn(prop, layoutAttr, modelInstance);
        }
    }
}
