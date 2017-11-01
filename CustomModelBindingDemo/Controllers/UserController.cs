using CustomModelBindingDemo.Data;
using CustomModelBindingDemo.ModelBinders;
using CustomModelBindingDemo.Models;
using System.Web.Mvc;

namespace CustomModelBindingDemo.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index([ModelBinder(typeof(UserFromDatabaseModelBinder))]User user)
        {
            return View(new UserModel(user));
        }

        [HttpPost]
        [ActionName(nameof(Index))]
        public ActionResult IndexPost(UserModel model)
        {
            var userRepository = new UserRepositoryDictionary();

            userRepository.Update(model.ToUser());

            return View(model);
        }
    }
}