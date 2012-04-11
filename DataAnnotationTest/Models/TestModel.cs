using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weber4.Attributes;

namespace DataAnnotationTest.Models
{
    public class TestModel
    {
        [Microdata(Data="test=test, mvc=awesomeness!")]
        public string Test { get; set; }
    }
}