using CustomModelBindingDemo.Attributes;

namespace CustomModelBindingDemo.Models
{
    public class EmailDemoModel
    {
        [CustomEmail(Domains = new[] { "abc.com", "def.test", "ghi.net" })]
        public string Email { get; set; }
    }
}