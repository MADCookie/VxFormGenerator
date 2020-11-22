using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VxFormGenerator.Core.Components
{
    public class VxFormColumnComponent : OwningComponentBase
    {
        [Parameter] public Layout.VxFormColumn FormColumnDefinition { get; set; }

        public RenderFragment CreateFormElement() => builder =>
        {
            if (FormColumnDefinition.Model.GetType() == typeof(ExpandoObject))
            {
                // Accesing a ExpandoObject requires to cast the model as a dictionary, so it's accesable by a key of type string
                var accessor = ((IDictionary<string, object>)FormColumnDefinition.Model);

                foreach (var key in accessor.Keys)
                {
                    // get the value of the object
                    var value = accessor[key];

                    // Get the generic CreateFormComponent and set the property type of the model and the elementType that is rendered
                    MethodInfo method = typeof(VxFormColumnComponent).GetMethod(nameof(VxFormColumnComponent.CreateFormElementReferenceExpando), BindingFlags.NonPublic | BindingFlags.Instance);
                    MethodInfo genericMethod = method.MakeGenericMethod(value.GetType());
                    // Execute the method with the following parameters
                    genericMethod.Invoke(this, new object[] { accessor, key, builder });
                }
            }
            else // Assume it's a regular class, could be tighter scoped
            {
                // Get the generic CreateFormComponent and set the property type of the model and the elementType that is rendered
                MethodInfo method = typeof(VxFormColumnComponent).GetMethod(nameof(VxFormColumnComponent.CreateFormElementReferencePoco), BindingFlags.NonPublic | BindingFlags.Instance);
                MethodInfo genericMethod = method.MakeGenericMethod(FormColumnDefinition.Property.PropertyType);
                // Execute the method with the following parameters
                genericMethod.Invoke(this, new object[] { FormColumnDefinition.Model, FormColumnDefinition.Property, builder });
            }
        };

          private void CreateFormElementReferencePoco<TValue>(object model, PropertyInfo propertyInfo, RenderTreeBuilder builder)
        {
            var valueChanged = Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck(
                        EventCallback.Factory.Create<TValue>(
                            this, EventCallback.Factory.
                            CreateInferred(this, __value => propertyInfo.SetValue(model, __value),

                            (TValue)propertyInfo.GetValue(model))));
            // Create an expression to set the ValueExpression-attribute.
            var constant = Expression.Constant(model, model.GetType());
            var exp = Expression.Property(constant, propertyInfo.Name);
            var lamb = Expression.Lambda<Func<TValue>>(exp);

            var formElementReference = new FormElementReference<TValue>()
            {
                Value = (TValue)propertyInfo.GetValue(model),
                ValueChanged = valueChanged,
                ValueExpression = lamb,
                Key = propertyInfo.Name,
                Model = model
            };


            var elementType = typeof(VxFormElementLoader<TValue>);

            builder.OpenComponent(0, elementType);
            builder.AddAttribute(1, nameof(VxFormElementLoader<TValue>.ValueReference), formElementReference);
            builder.CloseComponent();
        }

        /// <summary>
        /// Create a <see cref="VxFormElementLoader{TValue}"/> that will create a <see cref="FormElement"/>
        /// based on the dynamic <see cref="ExpandoObject"/>. This allows for dynamic usage of the form-generator.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="model"></param>
        /// <param name="key"></param>
        /// <param name="builder"></param>
        private void CreateFormElementReferenceExpando<TValue>(ExpandoObject model, string key, RenderTreeBuilder builder)
        {
            // cast the model to a dictionary so it's accessable
            var accessor = ((IDictionary<string, object>)model);

            object value = default(TValue);
            accessor.TryGetValue(key, out value);

            var valueChanged = Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck(
                        EventCallback.Factory.Create<TValue>(
                            this, EventCallback.Factory.
                            CreateInferred(this, __value => accessor[key] = __value,
                            (TValue)accessor[key])));

            var formElementReference = new FormElementReference<TValue>()
            {
                Value = (TValue)value,
                ValueChanged = valueChanged,
                Key = key,
                Model = model
            };

            var elementType = typeof(VxFormElementLoader<TValue>);

            builder.OpenComponent(0, elementType);
            builder.AddAttribute(1, nameof(VxFormElementLoader<TValue>.ValueReference), formElementReference);
            builder.CloseComponent();
        }

    }
}
