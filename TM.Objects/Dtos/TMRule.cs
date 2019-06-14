using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Objects
{
    public class TMRule
    {
        public int RuleID { get; set; }
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public string RuleXml { get; set; }
        public string RuleText { get; set; }
        public string RuleType { get; set; }
        public int ExecutionOrder { get; set; }
    }

}

