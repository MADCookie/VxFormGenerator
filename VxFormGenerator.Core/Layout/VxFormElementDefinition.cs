
using System;
using System.Reflection;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormElementDefinition : ICloneable
    {

        public int ColSpan { get; set; }
        public string Name { get; private set; }
        public int Order { get; private set; }
        public PropertyInfo Property { get; set; }
        public object Model { get; private set; }

        public VxFormElementDefinition(PropertyInfo prop)
        {
            Property = prop;
        }

        public VxFormElementDefinition(PropertyInfo prop, VxFormLayoutAttribute layoutAttr, object modelInstance)
        {
            ColSpan = layoutAttr.ColSpan;
            Name = layoutAttr.Name;
            Order = layoutAttr.Order;

            Property = prop;
            Model = modelInstance;
        }

        public object Clone()
        {
            return new VxFormElementDefinition(this.Property) { ColSpan = this.ColSpan };
        }

        internal static VxFormElementDefinition Create(PropertyInfo prop, VxFormLayoutAttribute layoutAttr, object modelInstance)
        {
            return new VxFormElementDefinition(prop, layoutAttr, modelInstance);
        }
    }
}
