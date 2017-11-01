using CustomModelBindingDemo.Data;
using System.ComponentModel.DataAnnotations;

namespace CustomModelBindingDemo.Models
{
    public class UserModel
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public User ToUser()
            => new User
        {
            Email = Email,
            FirstName = FirstName,
            LastName = LastName
        };
    }
}