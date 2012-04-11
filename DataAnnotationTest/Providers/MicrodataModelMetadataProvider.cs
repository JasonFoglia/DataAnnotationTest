using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weber4.Attributes;

namespace Weber4.Providers
{
    public class MicrodataModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            ModelMetadata metadata = base.CreateMetadata(
                attributes,
                containerType,
                modelAccessor,
                modelType,
                propertyName);

            // if no property name is specified, use fully qualified name of the Type
            string key = string.IsNullOrEmpty(propertyName) ?
                modelType.FullName :
                propertyName;

            var microdata = attributes.OfType<MicrodataAttribute>().FirstOrDefault();

            if (microdata != null)
                metadata.AdditionalValues[key] = microdata.GetAttributes();

            return metadata;
        }
    }
}