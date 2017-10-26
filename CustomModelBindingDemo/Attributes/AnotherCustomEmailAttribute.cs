using CustomModelBindingDemo.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CustomModelBindingDemo.Attributes
{
    public class AnotherCustomEmailAttribute : ValidationAttribute, IMetadataAware
    {
        private readonly EmailAddressAttribute emailAddressValidationAttribute;

        public string[] Domains { get; set; }

        public AnotherCustomEmailAttribute()
        {
            emailAddressValidationAttribute = new EmailAddressAttribute();
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = "AnotherCustomEmail";
            metadata.AdditionalValues[Constants.ModelBinding.CustomEmail.Domains] = Domains;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (!typeof(EmailModel).IsAssignableFrom(value.GetType()))
            {
                return false;
            }

            var emailModelValue = value as EmailModel;

            return emailAddressValidationAttribute.IsValid(emailModelValue.GetEmail());
        }
    }
}