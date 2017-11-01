using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CustomModelBindingDemo.ValueProviders
{
    public class XmlValueProvider : IValueProvider
    {
        private readonly XDocument _xDocument;

        public XmlValueProvider(string xmlString)
        {
            _xDocument = XDocument.Parse(xmlString);
        }

        public bool ContainsPrefix(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return false;
            }

            var matchingElements = GetMatchingElements(prefix);

            return matchingElements.Any();
        }

        public ValueProviderResult GetValue(string key)
        {
            var matchingElements = GetMatchingElements(key).Select(element => element.Value).ToArray();

            if (matchingElements.Any())
            {
                return new ValueProviderResult(matchingElements, string.Join(", ", matchingElements), CultureInfo.CurrentCulture);
            }

            return null;
        }

        private IEnumerable<XElement> GetMatchingElements(string prefix)
        {
            var parts = prefix.Split('.');

            IEnumerable<XElement> currentElements = _xDocument.Root.Descendants();

            for (int i = 0; i < parts.Length; i++)
            {
                if (!currentElements.Any())
                {
                    break;
                }

                var currentPart = parts[i];

                currentElements = currentElements.DescendantsAndSelf().Where(element => element.Name.LocalName.Equals(currentPart, StringComparison.InvariantCultureIgnoreCase));
            }

            return currentElements;
        }
    }
}