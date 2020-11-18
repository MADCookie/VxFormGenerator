using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace VxFormGenerator.Core.Layout
{

    public class VxFormGroup : Attribute
    {

        public string Label { get; set; }

        public string Id { get; set; }

        public List<VxFormRow> Rows { get; set; }

        internal static bool IsFormGroup(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(VxFormGroup), false) != null;
        }

        internal static VxFormGroup CreateFromModel(Type propertyType)
        {
            var typeToCheck = propertyType;
            // check for generics
            if (propertyType.IsGenericType)
                typeToCheck = propertyType.GetGenericTypeDefinition();

            var allProperties = VxHelpers.GetAllProperties(typeToCheck);

            var defaultGroup = VxFormGroup.Create();

            foreach (var prop in allProperties)
            {

                var formRowAttr = prop.GetCustomAttribute<VxFormRow>();

                if (formRowAttr != null)
                {
                    if (defaultGroup.Rows.Contains(formRowAttr))
                    {
                        var foundRow = defaultGroup.Rows.Find(value => value.Id == formRowAttr.Id);
                        var formColumn = VxFormColumn.CreateFromProperty(prop);
                        foundRow.Columns.Add(formColumn);
                    }
                    else
                        defaultGroup.Rows.Add((VxFormRow)formRowAttr.Clone());
                }
            }
            return new VxFormGroup();
            // 
        }

        private static VxFormGroup Create()
        {
            return new VxFormGroup();
        }
    }
}
