using System;
using System.Collections.Generic;
using System.Text;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormRow : Attribute
    {

        public string Label { get; set; }

        public string Id { get; set; }

        public LabelPositions LabelPosition { get; set; }

        public List<VxFormColumn> Columns { get; set; }

        public VxFormRow(int rowId)
        {
            Id = rowId.ToString();
        }

    }
}
