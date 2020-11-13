using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormDefinition: Attribute
    {
        public string Label { get; protected set; }

        protected List<VxFormGroup> Groups { get; set; } = new List<VxFormGroup>();

        internal static VxFormDefinition CreateFromModel(Type modelType)
        {
            var allProperties = VxHelpers.GetAllProperties(modelType);

            foreach(var prop in allProperties)
            {
                var isFormGroup = prop.GetCustomAttributes(typeof(VxFormGroup));
                if(isFormGroup != null)                {
                    
                }
                    
            }


            return null;
        }
    }
}
