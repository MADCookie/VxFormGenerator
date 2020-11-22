using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using VxFormGenerator.Core.Layout;

namespace VxFormGenerator.Core
{
    public class RenderFormElements : OwningComponentBase
    {
        /// <summary>
        /// Get the <see cref="EditForm.EditContext"/> instance. This instance will be used to fill out the values inputted by the user
        /// </summary>
        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        [Inject]
        IFormGeneratorOptions FormGeneratorOptions { get; set; }

        /// <summary>
        /// Override the default render method, determining if the <see cref="EditContext.Model"/> 
        /// is a regular class or a dynamic <see cref="ExpandoObject"/>
        /// </summary>
        /// <param name="builder">Instance of the page builder</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            // Check the type of the model
            var modelType = CascadedEditContext.Model.GetType();
            var formDefinition = VxFormDefinition.CreateFromModel(CascadedEditContext.Model);


            foreach (var group in formDefinition.Groups)
            {
                builder.OpenComponent<Components.VxFormGroup>(0);
                builder.AddAttribute(1, nameof(Components.VxFormGroup.FormGroupDefinition), group);
                builder.CloseComponent();
            }


        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetupFramework();
        }

        private void SetupFramework()
        {
            if (FormGeneratorOptions.FormElementComponent != null)
                CascadedEditContext.SetFieldCssClassProvider(FormGeneratorOptions.FieldCssClassProvider);
        }



    }
}
