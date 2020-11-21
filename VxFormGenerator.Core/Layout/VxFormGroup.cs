using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace VxFormGenerator.Core.Layout
{

    public class VxFormGroup
    {

        public string Label { get; set; }

        public string Id { get; set; }

        public List<VxFormRow> Rows { get; set; } = new List<VxFormRow>();

        internal static bool IsFormGroup(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<VxFormGroupAttribute>() != null;
        }

        internal static VxFormGroup CreateFromModel(object modelInstance)
        {
            var typeToCheck = modelInstance.GetType();
            // check for generics
            if (typeToCheck.IsGenericType)
                typeToCheck = typeToCheck.GetGenericTypeDefinition();

            var allProperties = VxHelpers.GetModelProperties(typeToCheck);

            var rootGroup = VxFormGroup.Create();

            foreach (var prop in allProperties)
            {
                VxFormGroup.Add(prop, rootGroup, modelInstance);
            }
            return rootGroup;
        }

        internal static void Add(PropertyInfo prop, VxFormGroup group, object modelInstance)
        {
            var layoutAttr = prop.GetCustomAttribute<VxFormLayoutAttribute>();
            var allRowLayoutAttributes = VxHelpers.GetAllAttributes<VxFormRowLayoutAttribute>(prop.DeclaringType);

            // If no attribute is found use the name of the property
            if (layoutAttr == null)
                layoutAttr = new VxFormLayoutAttribute() { Name = prop.Name };

            // Check if row already exists
            var foundRow = group.Rows.Find(value => value.Id == layoutAttr.RowId.ToString());

            if (foundRow == null)
            {
                foundRow = VxFormRow.Create(layoutAttr, allRowLayoutAttributes.Find(x => x.Id == layoutAttr.RowId));
                group.Rows.Add(foundRow); ;
            }

            var formColumn = VxFormColumn.Create(prop, layoutAttr, modelInstance);
            foundRow.Columns.Add(formColumn);
        }

        internal static VxFormGroup Create()
        {
            return new VxFormGroup();
        }
    }
}
