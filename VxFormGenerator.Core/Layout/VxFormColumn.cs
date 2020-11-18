
using System;
using System.Reflection;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormColumn : ICloneable
    {

        public int ColSpan { get; set; }

        public PropertyInfo Property { get; set; }

        public VxFormColumn(int colSpan, PropertyInfo prop)
        {
            ColSpan = colSpan;
            Property = prop;
        }

        internal static VxFormColumn CreateFromProperty(PropertyInfo prop)
        {
            var columnAnnotation = prop.GetCustomAttribute<VxFormLayout>();
            return columnAnnotation == null ? new VxFormColumn(0, prop) : new VxFormColumn(columnAnnotation.ColSpan, prop);
        }

        public object Clone()
        {
            return new VxFormColumn(this.ColSpan, this.Property);
        }
    }
}
