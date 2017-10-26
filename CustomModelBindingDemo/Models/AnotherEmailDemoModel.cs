using CustomModelBindingDemo.Attributes;

namespace CustomModelBindingDemo.Models
{
    public class AnotherEmailDemoModel
    {
        [AnotherCustomEmail(Domains = new[] { "abc.com", "def.test", "ghi.net" })]
        public EmailModel Email { get; set; }
    }
}