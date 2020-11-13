
using System;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormColumn : Attribute
    {

        public int ColSpan { get; set; }

        public string FieldName { get; set; }

        public VxFormColumn(int colSpan)
        {
            ColSpan = colSpan;
        }
    }
}
