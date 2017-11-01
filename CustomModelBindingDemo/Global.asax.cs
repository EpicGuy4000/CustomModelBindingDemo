using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CustomModelBindingDemo.ModelBinders;
using CustomModelBindingDemo.ValueProviders;

namespace CustomModelBindingDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ValueProviderFactories.Factories.Insert(0, new XmlValueProviderFactory());

            System.Web.Mvc.ModelBinders.Binders.Add(typeof(string), new CustomEmailModelBinder());
        }
    }
}
