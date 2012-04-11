using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Weber4.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MicrodataAttribute : Attribute
    {
        public string Data { get; set; }
        
        public RouteValueDictionary GetAttributes()
        {
            var attributes = new RouteValueDictionary();

            if (this.Data != null)
            {
                string[] kv = this.Data.Split('=');
                attributes.Add(kv[0], kv[1]);
            }
            return attributes;
        }
    }
}