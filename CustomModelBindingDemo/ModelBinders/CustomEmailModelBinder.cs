using System.Globalization;
using System.Web.Mvc;

namespace CustomModelBindingDemo.ModelBinders
{
    public class CustomEmailModelBinder : DefaultModelBinder
    {
        public const string BinderType = "CustomEmail";

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var metadata = bindingContext.ModelMetadata;

            if (!metadata.AdditionalValues.ContainsKey(Constants.ModelBinding.BinderType) || metadata.AdditionalValues[Constants.ModelBinding.BinderType] as string != BinderType)
            {
                return base.BindModel(controllerContext, bindingContext);
            }

            var username = bindingContext.ValueProvider.GetValue($"{bindingContext.ModelName}.{Constants.ModelBinding.CustomEmail.UsernameKey}").AttemptedValue;
            var domain = bindingContext.ValueProvider.GetValue($"{bindingContext.ModelName}.{Constants.ModelBinding.CustomEmail.DomainKey}").AttemptedValue;

            var email = $"{username}@{domain}";
            var prefix = bindingContext.ModelName;

            bindingContext.ModelState.SetModelValue(prefix, new ValueProviderResult(email, email, CultureInfo.CurrentCulture));
            
            return email;
        }
    }
}