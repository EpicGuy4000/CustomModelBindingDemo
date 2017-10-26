using CustomModelBindingDemo.Models;
using System.Web.Mvc;

namespace CustomModelBindingDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Email()
        {
            return View(new EmailDemoModel());
        }

        [HttpPost]
        [ActionName(nameof(Email))]
        public ActionResult EmailPost(EmailDemoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return Content(model.Email);
        }

        public ActionResult AnotherEmail()
        {
            return View(new AnotherEmailDemoModel());
        }

        [HttpPost]
        [ActionName(nameof(AnotherEmail))]
        public ActionResult AnotherEmailPost(AnotherEmailDemoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return Content(model.Email.GetEmail());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}