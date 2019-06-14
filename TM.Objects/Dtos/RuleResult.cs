using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Objects
{
 public    class TMRuleResult
    {
        public int RuleID { get; set; }
        public int EntityType { get; set; } //0=stock;1=option
        public int StockID { get; set; }
        public string StockSymbol { get; set; }
        public string Company { get; set; }
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public string XmlResult { get; set; }
        public DateTime CreatedDate { get; set; }

        public TMStockInfo StockInfo //if EntityType =0
        {
            get
            {
                return Utility.DeserializeFromXml<TMStockInfo>(XmlResult); 
                
            }
        }
        public TMOptionInfo TMOptionEntity  //if EntityType =1
        {
            get
            {
                return Utility.DeserializeFromXml<TMOptionInfo>(XmlResult); 

            }
        }
    }
}
