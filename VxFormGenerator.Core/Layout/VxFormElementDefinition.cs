
using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormElementDefinition<TProperty> : ICloneable
    {

        public int ColSpan { get; set; }
        public string Name { get; private set; }
        public int Order { get; private set; }
        public PropertyInfo Property { get; set; }
        public object Model { get; private set; }

        private TProperty _value;

        public TProperty Value
        {
            get
            {

                return _value;
            }
            set
            {
                _value = value;
                if (ValueChanged.HasDelegate)
                    ValueChanged.InvokeAsync(_value);
            }

        }

        public EventCallback<TProperty> ValueChanged { get; set; }
        public string Key { get; internal set; }
        public Expression<Func<TProperty>> ValueExpression { get; internal set; }
        

        public static void SetValue(object model, string key, TProperty value)
        {
            var modelType = model.GetType();

            if (modelType == typeof(ExpandoObject))
            {
                var accessor = ((IDictionary<string, object>)model);
                accessor[key] = value;
            }
            else
            {
                var propertyInfo = modelType.GetProperty(key);
                propertyInfo.SetValue(model, value);
            }
        }

        public static TValue GetValue(object model, string key)
        {
            var modelType = model.GetType();

            if (modelType == typeof(ExpandoObject))
            {
                var accessor = ((IDictionary<string, object>)model);
                return (TValue)accessor[key];
            }
            else
            {
                var propertyInfo = modelType.GetProperty(key);
                return (TValue)propertyInfo.GetValue(model);
            }

        }

    }

    public VxFormElementDefinition(PropertyInfo prop)
        {
            Property = prop;
        }

        public VxFormElementDefinition(PropertyInfo prop, VxFormLayoutAttribute layoutAttr, object modelInstance)
        {
            ColSpan = layoutAttr.ColSpan;
            Name = layoutAttr.Name;
            Order = layoutAttr.Order;

            Property = prop;
            Model = modelInstance;
        }

        public object Clone()
        {
            return new VxFormElementDefinition(this.Property) {
                ColSpan = this.ColSpan
            };
        }

        internal static VxFormElementDefinition Create(PropertyInfo prop, VxFormLayoutAttribute layoutAttr, object modelInstance)
        {
            return new VxFormElementDefinition(prop, layoutAttr, modelInstance);
        }
    }
}
