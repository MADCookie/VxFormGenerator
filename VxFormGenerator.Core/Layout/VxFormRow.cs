using System;
using System.Collections.Generic;
using System.Text;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormRow :  ICloneable
    {

        public string Label { get; set; }

        public int Id { get; set; }

        public LabelPositions LabelPosition { get; set; }

        public List<VxFormColumn> Columns { get; set; }

        public VxFormRow(int rowId)
        {
            Id = rowId;
        }

        public object Clone()
        {
            return new VxFormRow(this.Id) { LabelPosition = this.LabelPosition, Label = this.Label, Columns = this.Columns };
        }
    }
}
