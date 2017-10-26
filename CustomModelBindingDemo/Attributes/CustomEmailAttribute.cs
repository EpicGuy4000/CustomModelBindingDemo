using CustomModelBindingDemo.ModelBinders;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CustomModelBindingDemo.Attributes
{
    public class CustomEmailAttribute : ValidationAttribute, IMetadataAware
    {
        private readonly EmailAddressAttribute emailAddressValidationAttribute;

        public string[] Domains { get; set; }

        public CustomEmailAttribute()
        {
            emailAddressValidationAttribute = new EmailAddressAttribute();
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = "CustomEmail";
            metadata.AdditionalValues[Constants.ModelBinding.CustomEmail.Domains] = Domains;
            metadata.AdditionalValues[Constants.ModelBinding.BinderType] = CustomEmailModelBinder.BinderType;
        }

        public override bool IsValid(object value)
        {
            return emailAddressValidationAttribute.IsValid(value);
        }
    }
}