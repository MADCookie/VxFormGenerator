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

            return new VxFormGroup();
            // 
        }
    }
}
