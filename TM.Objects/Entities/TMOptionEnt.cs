using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EgarDDSEnt;
using CodeEffects.Rule.Attributes;
using CodeEffects.Rule.Common;
using System.IO;
using System.Xml.Serialization;
namespace TM.Objects
{
     [Serializable()]  
    public class TMOptionEnt : ITMOptionEnt
    {
        IOptionsEnt _option;
     //   StockDTO _dto;

      
        string _Symbol;
        int _StockId;

        
        public TMStockEnt StockEnt { get; set; }
          [XmlIgnore]
          [ExcludeFromEvaluationAttribute()]
        public int RuleID { get; set; }

          [XmlIgnore]
          [ExcludeFromEvaluationAttribute()]
        public float BuyPrice { get; set; }

          [XmlIgnore]
          [ExcludeFromEvaluationAttribute()]
        public float SellPrice { get; set; }

          [XmlIgnore]
          [ExcludeFromEvaluationAttribute()]
        public float StopLoss { get; set; }

          [XmlIgnore]
          [ExcludeFromEvaluationAttribute()]
        public string RuleName { get; set; }

        public TMOptionEnt()
        {
        }
        public TMOptionEnt(string xmlResult)
        {
        }
        public TMOptionEnt(string symbol,int stockId, IOptionsEnt option)
        {
            _option = option;
            _Symbol = symbol;
            _StockId = stockId;
          //  _dto = Reader.GetStockInfo(_StockId);
        }

       
        #region "============== Ivolatality members =========="
        /*
         * 
         *  Symbol
            Option Type -done
            Option Strike Price -done
            Option Expiration Date -done
            Option Ask Price - done
            Option Bid Price - done
            Option Delta -done
            Option Gamma (Not important, but can keep it for the time being) -done
            Option Implied volatility -done
            Option Last Price (Not important, but can keep it for the time being)-done
            Option last price (Need to check what we receive)
         * */

       

        [Field(DisplayName = "Option Ask Price", ValueInputType = ValueInputType.All)]
        public float OptionAskPrice
        {
            get
            {
                return _option.AskPrice;
            }
            set { }
        }
              
        [Field(DisplayName = "Option Bid Price", ValueInputType = ValueInputType.All)]
        public float OptionBidPrice
        {
            get
            {
                return _option.BidPrice;
            }
            set { }
        }
      
        [Field(DisplayName = "Option Delta", ValueInputType = ValueInputType.User)]
        public float OptionDelta
        {
            get
            {
                return _option.Delta;
            }
            set { }
        }

        [Field(DisplayName = "Option Expiration Date", ValueInputType = ValueInputType.All)]
        public DateTime OptionExpirationDate
        {
            get
            {
                return _option.ExpirationDate;
            }
            set { }
        }

        [Field(DisplayName = "Option Gamma", ValueInputType = ValueInputType.User)]
        public float OptionGamma
        {
            get
            {
                return _option.Gamma;
            }
            set { }
        }

        [Field(DisplayName = "Option IV[Implied Volatility (interpolated value)]", ValueInputType = ValueInputType.All)]
        public float OptionIV
        {
            get
            {
                return _option.IV;
            }
            set { }
        }
       
        [Field(DisplayName = "Option Last Price", ValueInputType = ValueInputType.All)]
        public float OptionLastPrice
        {
            get
            {
                return _option.LastPrice;
            }
            set { }
        }
      
        [Field(DisplayName = "Option Open Interest", ValueInputType = ValueInputType.All)]
        public int OptionOpenInterest
        {
            get
            {
                return _option.OpenInterest;
            }
            set { }
        }
      
        [Field(DisplayName = "Option Type", ValueInputType = ValueInputType.All)]
        public OptionTypeEnum OptionOptionType
        {
            get
            {
                return _option.OptionType;
            }
            set { }
        }

        [Field(DisplayName = "Option PreIV", ValueInputType = ValueInputType.All)]
        public float OptionPreIV
        {
            get
            {
                return _option.PreIV;
            }
            set { }
        }

        [Field(DisplayName = "Option Rho", ValueInputType = ValueInputType.All)]
        public float OptionRho
        {
            get
            {
                return _option.Rho;
            }
            set { }
        }

        [Field(DisplayName = "Option Strike Price", ValueInputType = ValueInputType.All)]
        public float OptionStrikePrice
        {
            get
            {
                return _option.StrikePrice;
            }
            set { }
        }

        [Field(DisplayName = "Option Theta", ValueInputType = ValueInputType.User)]
        public float OptionTheta
        {
            get
            {
                return _option.Theta;
            }
            set { }
        }

        [Field(DisplayName = "Option Vega", ValueInputType = ValueInputType.All)]
        public float OptionVega
        {
            get
            {
                return _option.Vega;
            }
            set { }
        }

        [Field(DisplayName = "Option Volume", ValueInputType = ValueInputType.All)]
        public int OptionVolume
        {
            get
            {
                return _option.Volume;
            }
            set { }
        }


        #endregion
        #region "===== ivolatality memebers commneted out ==="
        //[Field(DisplayName = "Option Ask Date[Time or Date of ask price]", ValueInputType = ValueInputType.All)]
        //public DateTime OptionAskDate
        //{
        //    get
        //    {
        //        return _option.AskDate;
        //    }
        //}
        //[Field(DisplayName = "Option Ask Exchange[Exchange of ask price]", ValueInputType = ValueInputType.User)]
        //public string OptionAskExchange
        //{
        //    get
        //    {
        //        return _option.AskExchange;
        //    }
        //}

        //[Field(DisplayName = "Option Ask Size", ValueInputType = ValueInputType.All)]
        //public int OptionAskSize
        //{
        //    get
        //    {
        //        return _option.AskSize;
        //    }
        //}

        //[Field(DisplayName = "Option Bid Date[Time or date of bid price]", ValueInputType = ValueInputType.All)]
        //public DateTime OptionBidDate
        //{
        //    get
        //    {
        //        return _option.BidDate;
        //    }
        //}
        //[Field(DisplayName = "Option Bid Exchange[Exchange of bid price]", ValueInputType = ValueInputType.User)]
        //public string OptionBidExchange
        //{
        //    get
        //    {
        //        return _option.BidExchange;
        //    }
        //}

        //[Field(DisplayName = "Option Style", ValueInputType = ValueInputType.All)]
        //public OptionStyleEnum OptionStyle
        //{
        //    get
        //    {
        //        return _option.OptionStyle;
        //    }
        //}
        //[Field(DisplayName = "Option BidS ize", ValueInputType = ValueInputType.All)]
        //public int OptionBidSize
        //{
        //    get
        //    {
        //        return _option.BidSize;
        //    }
        //}
        //[Field(DisplayName = "Option Last Date", ValueInputType = ValueInputType.All)]
        //public DateTime OptionLastDate
        //{
        //    get
        //    {
        //        return _option.LastDate;
        //    }
        //}
        //[Field(DisplayName = "Option Last Exchange", ValueInputType = ValueInputType.All)]
        //public string OptionLastExchange
        //{
        //    get
        //    {
        //        return _option.LastExchange;
        //    }
        //}
        //[Field(DisplayName = "Option Last Size", ValueInputType = ValueInputType.All)]
        //public int OptionLastSize
        //{
        //    get
        //    {
        //        return _option.LastSize;
        //    }
        //}
        #endregion


        [Action]
        public void AddThisOptionToList()
        {
            //put as buy order in DB    

            string serializedText = Utility.SerializeToXml(this);

            Storage.InsertRuleResults(this.RuleID, this._StockId, serializedText, DateTime.Now, 1);//1= option entity

                    
        }

       
    }
}
