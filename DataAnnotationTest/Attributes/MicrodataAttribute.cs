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

            if (!String.IsNullOrEmpty(this.Data))
            {
                try
                {
                    string[] data = this.Data.Split(',');
                    foreach (string str in data)
                    {
                        string[] kv = str.Split('=');
                        try
                        {
                            attributes.Add("data-" + kv[0].Trim(), kv[1].Trim());
                        }
                        catch { }
                    }
                }
                catch { }
            }
            return attributes;
        }
    }
}