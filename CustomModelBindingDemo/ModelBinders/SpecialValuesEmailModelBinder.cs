using CustomModelBindingDemo.Models;
using System.Web.Mvc;

namespace CustomModelBindingDemo.ModelBinders
{
    public class SpecialValuesEmailModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var emailModel = (EmailModel)bindingContext.Model ?? new EmailModel();

            if (!string.IsNullOrEmpty(bindingContext.ModelName) && !bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName))
            {
                // We couldn't find any entry that began with the prefix. If this is the top-level element, fall back
                // to the empty prefix.
                if (bindingContext.FallbackToEmptyPrefix)
                {
                    bindingContext = new ModelBindingContext()
                    {
                        ModelMetadata = bindingContext.ModelMetadata,
                        ModelState = bindingContext.ModelState,
                        PropertyFilter = bindingContext.PropertyFilter,
                        ValueProvider = bindingContext.ValueProvider
                    };
                }
            }

            emailModel.Username = GetValue(bindingContext, nameof(emailModel.Username), "john_doe");
            emailModel.Domain = GetValue(bindingContext, nameof(emailModel.Domain), "example.com");

            return emailModel;
        }

        private string GetValue(ModelBindingContext context, string name, string defaultValue)
        {
            name = (context.ModelName == string.Empty ? string.Empty : context.ModelName + ".") + name;

            ValueProviderResult result = context.ValueProvider.GetValue(name);
            
            if (string.IsNullOrEmpty(result?.AttemptedValue))
            {
                return defaultValue;
            }
            else
            {
                return result.AttemptedValue;
            }
        }
    }
}