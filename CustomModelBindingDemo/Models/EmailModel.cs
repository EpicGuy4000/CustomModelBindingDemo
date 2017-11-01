namespace CustomModelBindingDemo.Models
{
    public class EmailModel
    {
        public string Username { get; set; }
        
        public string Domain { get; set; }

        public string GetEmail() => $"{Username}@{Domain}";
    }
}