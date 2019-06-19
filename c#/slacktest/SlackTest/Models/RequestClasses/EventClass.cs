using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackTest.Models
{
    public class EventClass
    {
        public string User { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Channel { get; set; }
    }
}