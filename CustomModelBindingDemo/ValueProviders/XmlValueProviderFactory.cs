using System.Web.Mvc;
using System.Xml;

namespace CustomModelBindingDemo.ValueProviders
{
    public class XmlValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext
                controllerContext)
        {
            if (controllerContext.HttpContext.Request.ContentType != "text/xml")
            {
                return null;
            }

            var xmlDocument = new XmlDocument();

            xmlDocument.Load(controllerContext.HttpContext.Request.InputStream);
            return new XmlValueProvider(xmlDocument.InnerXml);
        }
    }
}