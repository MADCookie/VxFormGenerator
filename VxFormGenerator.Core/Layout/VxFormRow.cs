using System;
using System.Collections.Generic;
using System.Text;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormRow : ICloneable
    {

        public string Name { get; set; }

        public string Id { get; set; }

        public List<VxFormColumn> Columns { get; set; } = new List<VxFormColumn>();

        public VxFormRow(int rowId)
        {
            Id = rowId.ToString();
        }
        public VxFormRow(string rowId)
        {
            Id = rowId;
        }

        public object Clone()
        {
            return new VxFormRow(this.Id) { Name = this.Name, Columns = this.Columns };
        }

        internal static VxFormRow Create(VxFormLayoutAttribute layoutAttr, VxFormRowLayoutAttribute vxFormRowLayoutAttribute)
        {
            // If no rowid is specified use the name instead
            var output = layoutAttr.RowId == 0 ? new VxFormRow(layoutAttr.Name) : new VxFormRow(layoutAttr.RowId);
            // WHen there is a VxFormRowLayout found use the name if specified, this also sets the row to combined labels

            output.Name = vxFormRowLayoutAttribute?.Name;


            return output;
        }
    }
}
