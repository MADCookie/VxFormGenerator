using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VxFormGenerator.Core
{
    public static class VxHelpers
    {
        public static bool IsTypeDerivedFromGenericType(Type typeToCheck, Type genericType)
        {
            if (typeToCheck == typeof(object))
            {
                return false;
            }
            else if (typeToCheck == null)
            {
                return false;
            }
            else if (typeToCheck.IsGenericType && typeToCheck.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }
            else
            {
                return IsTypeDerivedFromGenericType(typeToCheck.BaseType, genericType);
            }
        }

        internal static IEnumerable<PropertyInfo> GetModelProperties(Type modelType)
        {
            return modelType.GetProperties()
                     .Where(w => w.GetCustomAttribute<VxIgnoreAttribute>() == null);
        }

        internal static List<T> GetAllAttributes<T>(Type modelType) where T : Attribute => modelType.GetCustomAttributes<T>().ToList();

        internal static bool TypeImplementsInterface(Type type, Type typeToImplement)
        {
            Type foundInterface = type
                .GetInterfaces()
                .Where(i =>
                {
                    return i.Name == typeToImplement.Name;
                })
                .Select(i => i)
                .FirstOrDefault();

            return foundInterface != null;
        }
    }
}
