using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EgarDDSEnt;
using CodeEffects.Rule.Attributes;
using CodeEffects.Rule.Common;
using TicTacTec.TA.Library;
using System.IO;
using System.Xml.Serialization;
namespace TM.Objects
{
    [Serializable()]  
    public class TMStockEnt : ITMStockEnt
    {

        #region "===================== Constructor variable===================="
        string _Symbol;
        int _StockId;
        IStocksEnt _stock ;
        double _SMA200d;
        double _SMA50d;
        double _SMA20d;

        double _EMA10d;

        double _ATR;
        double _CCI;

        double _BollingerUpperBand;
        double _BollingerMiddleBand;
        double _BollingerLowerBand;

        double _MACDLine;
        double _MACDSignalLine;
        double _MACDHistogram;

        double _Stochastic;
        double _RSI;

        bool _bullishPatternFormed ;
        bool _bearishPatternFormed ;


        #endregion

        //#region "===================== Entity variable========================="
        [XmlIgnore]
        [ExcludeFromEvaluationAttribute()]
        public string RuleName { get; set; }

        [XmlIgnore]
        [ExcludeFromEvaluationAttribute()]
        public TMPriceBar PriceBar { get; set; }

        [XmlIgnore]
        [ExcludeFromEvaluationAttribute()]
        public int RuleID { get; set; }


        float _AskPrice;
        //[Field(DisplayName = "IsStockMovementUp", ValueInputType = ValueInputType.All)]
        //public bool IsStockMovementUp
        //{
        //    get
        //    {
        //        return this.PriceClose < this.LastPrice;
        //    }
        //}

        //[Field(DisplayName = "IsStockMovementDown", ValueInputType = ValueInputType.All)]
        //public bool IsStockMovementDown
        //{
        //    get
        //    {
        //        return this.PriceClose > this.LastPrice;
        //    }
        //}



        //[ExcludeFromEvaluation()]
        //public bool IsSubSectorUp { get; set; }

        //[ExcludeFromEvaluation()]
        //public bool IsSubSectorDown { get; set; }

        //[ExcludeFromEvaluation()]
        //public bool IsSectorUp { get; set; }

        //[ExcludeFromEvaluation()]
        //public bool IsSectorDown { get; set; }

        //[ExcludeFromEvaluation()]
        //public string Sector { get; set; }

        //[ExcludeFromEvaluation()]
        //public string SubSector { get; set; }
        //#endregion

        public TMStockEnt(string symbol, int stockId, IStocksEnt stk)
        {
            _Symbol = symbol;//constructor
            _stock = stk;
            _StockId = stockId;
        }

        public TMStockEnt(string symbol, int stockId)
        {
            _Symbol = symbol;//constructor
            _StockId = stockId;
        }
        public TMStockEnt()
        {
        }
        public TMStockEnt(string xmlResult )
        {
          
        }

        #region "======================iVolt members======================================"

        //[Field(DisplayName = "Stock Ask Date[Time or Date of ask price]", ValueInputType = ValueInputType.All)]
        //public DateTime AskDate
        //{
        //    get
        //    {
        //        return _stock.AskDate;
        //    }
        //}
        //[Field(DisplayName = "Stock Ask Exchange[Exchange of ask price]", ValueInputType = ValueInputType.User)]
        //public string AskExchange
        //{
        //    get
        //    {
        //        return _stock.AskExchange;
        //    }
        //}

        [Field(DisplayName = "Stock Ask Price", ValueInputType = ValueInputType.All)]
        public   float AskPrice
        {
            get
            {
                return  _stock.AskPrice;
            }
            set { }

        }

        //[Field(DisplayName = "Stock Ask Size", ValueInputType = ValueInputType.All)]
        //public float AskSize
        //{
        //    get
        //    {
        //        return _stock.AskSize;
        //    }
        //}

        //[Field(DisplayName = "Stock Bid Date[Time or date of bid price]", ValueInputType = ValueInputType.All)]
        //public DateTime BidDate
        //{
        //    get
        //    {
        //        return _stock.BidDate;
        //    }
        //}
        //[Field(DisplayName = "Stock Bid Exchange[Exchange of bid price]", ValueInputType = ValueInputType.User)]
        //public string BidExchange
        //{
        //    get
        //    {
        //        return _stock.BidExchange;
        //    }
        //}

        //[Field(DisplayName = "Stock Bid Price", ValueInputType = ValueInputType.All)]
        //public float BidPrice
        //{
        //    get
        //    {
        //        return _stock.BidPrice;
        //    }
        //}
        //[Field(DisplayName = "Stock Bid Size", ValueInputType = ValueInputType.All)]
        //public float BidSize
        //{
        //    get
        //    {
        //        return _stock.BidSize;
        //    }
        //}

        //[Field(DisplayName = "Currency", ValueInputType = ValueInputType.User)]
        //public string Currency
        //{
        //    get
        //    {
        //        return _stock.Currency;
        //    }
        //}
        //[Field(DisplayName = "Stock Div Amount", ValueInputType = ValueInputType.All)]
        //public float DivAmount
        //{
        //    get
        //    {
        //        return _stock.DivAmount;
        //    }
        //}
        //[Field(DisplayName = "Stock Div Freqency", ValueInputType = ValueInputType.User)]
        //public int DivFreq
        //{
        //    get
        //    {
        //        return _stock.DivFreq;
        //    }
        //}

        //[Field(DisplayName = "Stock Div Last Date", ValueInputType = ValueInputType.All)]
        //public DateTime DivLastDate
        //{
        //    get
        //    {
        //        return _stock.DivLastDate;
        //    }
        //}
        //[Field(DisplayName = "Stock Div Yield", ValueInputType = ValueInputType.All)]
        //public float DivYield
        //{
        //    get
        //    {
        //        return _stock.DivYield;
        //    }
        //}

        [Field(DisplayName = "Stock HV 1m[Historical Volatility (HV) 1m as of yesterday]", ValueInputType = ValueInputType.All)]
        public float HV1m
        {
            get
            {
                return _stock.HV1m;
            }
            set { }
        }

        [Field(DisplayName = "Stock HV 1m High 52wk[Highest value of HV 1m for the last year]", ValueInputType = ValueInputType.All)]
        public float HV1mHigh52wk
        {
            get
            {
                return _stock.HV1mHigh52wk;
            }
            set { }
        }

        [Field(DisplayName = "Stock HV 1m Low 52wk[Lowest value of HV 1m for the last year]", ValueInputType = ValueInputType.All)]
        public float HV1mLow52wk
        {
            get
            {
                return _stock.HV1mLow52wk;
            }
            set { }
        }

        [Field(DisplayName = "Stock HV 1m Yest[Day before yesterdays value of HV 1m]", ValueInputType = ValueInputType.All)]
        public float HV1mYest
        {
            get
            {
                return _stock.HV1mYest;
            }
            set { }
        }

        [Field(DisplayName = "Stock IVX 1m[1-m IV Index as of yesterday close]", ValueInputType = ValueInputType.All)]
        public float IVX1m
        {
            get
            {
                return _stock.IVX1m;
            }
            set { }
        }

        [Field(DisplayName = "Stock IVX 1m High 52wk[Highest value of 1m IV Index for the last year]", ValueInputType = ValueInputType.All)]
        public float IVX1mHigh52wk
        {
            get
            {
                return _stock.IVX1mHigh52wk;
            }
            set { }
        }

        [Field(DisplayName = "Stock IVX 1m Low 52wk[Lowest value of 1m IV Index for the last year]", ValueInputType = ValueInputType.All)]
        public float IVX1mLow52wk
        {
            get
            {
                return _stock.IVX1mLow52wk;
            }
            set { }
        }

        [Field(DisplayName = "Stock IVX 1m Yest[Day before yesterdays value of IV Index]", ValueInputType = ValueInputType.All)]
        public float IVX1mYest
        {
            get
            {
                return _stock.IVX1mYest;
            }
            set { }
        }

        [Field(DisplayName = "Stock Last Date[Time or date of last price]", ValueInputType = ValueInputType.All)]
        public DateTime LastDate
        {
            get
            {
                return _stock.LastDate;
            }
            set { }
        }

        //[Field(DisplayName = "Stock Last Exchange[Exchange of last price]", ValueInputType = ValueInputType.User)]
        //public string LastExchange
        //{
        //    get
        //    {
        //        return _stock.LastExchange;
        //    }
        //}

        [Field(DisplayName = "Stock Last Price", ValueInputType = ValueInputType.All)]
        public float LastPrice
        {
            get
            {
                return _stock.LastPrice;
            }
            set { }
        }

        [Field(DisplayName = "Stock Last Size", ValueInputType = ValueInputType.All)]
        public float LastSize
        {
            get
            {
                return _stock.LastSize;
            }
            set { }
        }

        [Field(DisplayName = "Option Volume Avg[One month average of total Calls and Puts Volume]", ValueInputType = ValueInputType.All)]
        public float OptionVolumeAvg
        {
            get
            {
                return _stock.OptionVolumeAvg;
            }
            set { }
        }

        [Field(DisplayName = "Option Volume Call[Total Calls Volume]", ValueInputType = ValueInputType.All)]
        public float OptionVolumeCall
        {
            get
            {
                return _stock.OptionVolumeCall;
            }
            set { }
        }

        [Field(DisplayName = "Option Volume Put[Total Puts Volume]", ValueInputType = ValueInputType.All)]
        public float OptionVolumePut
        {
            get
            {
                return _stock.OptionVolumePut;
            }
            set { }
        }

        [Field(DisplayName = "Outstanding Shares", ValueInputType = ValueInputType.All)]
        public float OutstandingShares
        {
            get
            {
                return _stock.OutstandingShares;
            }
            set { }
        }

        [Field(DisplayName = "Stock Price Close", ValueInputType = ValueInputType.All)]
        public float PriceClose
        {
            get
            {
                return _stock.PriceClose;
            }
            set { }
        }

        [Field(DisplayName = "Price High 52wk", ValueInputType = ValueInputType.All)]
        public float PriceHigh52wk
        {
            get
            {
                return _stock.PriceHigh52wk;
            }
            set { }
        }

        [Field(DisplayName = "Price Low 52wk", ValueInputType = ValueInputType.All)]
        public float PriceLow52wk
        {
            get
            {
                return _stock.PriceLow52wk;
            }
            set { }
        }


        //[Field(DisplayName = "StockType", ValueInputType = ValueInputType.All)]
        //public StockTypeEnum StockType
        //{
        //    get
        //    {
        //        return _stock.StockType;
        //    }
        //}

        [Field(DisplayName = "Bullish Candlestick Pattern Formed", ValueInputType = ValueInputType.User)]
        public bool BullishCandlestickPatternFormed
        {
            get
            {
                return Reader.IfBullishCandleFormed(_StockId);
            }
            set { }
        }

        [Field(DisplayName = "Bearish Candlestick Pattern Formed", ValueInputType = ValueInputType.User)]
        public bool BearishCandlestickPatternFormed
        {
            get
            {
                return Reader.IfBearishCandleFormed(_StockId);
            }
            set { }
        }

        [Field(DisplayName = "Symbol", ValueInputType = ValueInputType.User)]
        public string Symbol
        {
            get
            {
                return _Symbol;
            }
            set { }
        }

        [Field(DisplayName = "Stock Volume", ValueInputType = ValueInputType.All)]
        public int Volume
        {
            get
            {
                return _stock.Volume;
            }
            set { }
        }

        #endregion

        #region "============ custom members =========="

        [Field(DisplayName = "RSI", ValueInputType = ValueInputType.All)]
        public double RSI
        {
            get
            {
                return _RSI;
            }
            set { }
        }

        [Field(DisplayName = "Stochastic", ValueInputType = ValueInputType.All)]
        public double Stochastic
        {
            get
            {
                return _Stochastic;
            }
            set { }
        }

        [Field(DisplayName = "MACD Histogram", ValueInputType = ValueInputType.All)]
        public double MACDHistogram
        {
            get
            {
                return _MACDHistogram;
            }
            set { }
        }

        [Field(DisplayName = "MACD Signal Line", ValueInputType = ValueInputType.All)]
        public double MACDSignalLine
        {
            get
            {
                return _MACDSignalLine;
            }
            set { }
        }

        [Field(DisplayName = "MACD Line", ValueInputType = ValueInputType.All)]
        public double MACDLine
        {
            get
            {
                return _MACDLine;
            }
            set { }
        }

        [Field(DisplayName = "CCI", ValueInputType = ValueInputType.All)]
        public double CCI
        {
            get
            {
                return _CCI;
            }
            set { }
        }

        [Field(DisplayName = "ATR", ValueInputType = ValueInputType.All)]
        public double ATR
        {
            get
            {
                return _ATR;
            }
            set { }
        }

        [Field(DisplayName = "10 days EMA", ValueInputType = ValueInputType.All)]
        public double EMA10d
        {
            get
            {
                return _EMA10d;
            }
            set { }
        }

        [Field(DisplayName = "Bollinger Upper Band", ValueInputType = ValueInputType.All)]
        public double BollingerUpperBand
        {
            get
            {
                return _BollingerUpperBand;
            }
            set { }
        }

        [Field(DisplayName = "Bollinger Middle Band", ValueInputType = ValueInputType.All)]
        public double BollingerMiddleBand
        {
            get
            {
                return _BollingerMiddleBand;
            }
            set { }
        }

        [Field(DisplayName = "Bollinger Lower Band", ValueInputType = ValueInputType.All)]
        public double BollingerLowerBand
        {
            get
            {
                return _BollingerLowerBand;
            }
            set { }
        }

        [Field(DisplayName = "200 Days SMA", ValueInputType = ValueInputType.All)]
        public double SMA200day
        {
            get
            {
                return _SMA200d;
            }
            set { }
        }

        [Field(DisplayName = "50 Days SMA", ValueInputType = ValueInputType.All)]
        public double SMA50day
        {
            get
            {
                return _SMA50d;
            }
            set { }
        }

        [Field(DisplayName = "20 Days SMA", ValueInputType = ValueInputType.All)]
        public double SMA20day
        {
            get
            {
                return _SMA20d;
            }
            set { }
        }
               
      
        #endregion

        #region "============== Actions============"

        [Action]
        public void AddThisStockToList()
        {
            string serializedText = Utility.SerializeToXml(this);

            Storage.InsertRuleResults(this.RuleID, this._StockId, serializedText, DateTime.Now, 0);//0= stock entity


        }
              
        #endregion

         
        public  void GenerateIndicators()
        {
            TicTacTec.TA.Library.Core.RetCode retCode;
            int outBegIndex;
            int outNBElement;
            double[] output = new double[1];
            int[] Cdloutput = new int[1];

            double[] realUpperBand = new double[1];
            double[] realMiddleBand = new double[1];
            double[] realLowerBand = new double[1];

            double[] macd = new double[1];
            double[] macdSignal = new double[1];
            double[] macdHist = new double[1];

            double[] StochSlowK = new double[1];
            double[] StochSlowD = new double[1];
           //200 sma
            retCode = Core.Sma(0, 199, PriceBar.Close, 200, out outBegIndex, out outNBElement, output);
            _SMA200d = output[0];
            //50 sma
            retCode = Core.Sma(0, 49, PriceBar.Close, 50, out outBegIndex, out outNBElement, output);
            _SMA50d = output[0];
            //20 sma
            retCode = Core.Sma(0, 19, PriceBar.Close, 20, out outBegIndex, out outNBElement, output);
            _SMA20d = output[0];

            //10 day EMA
            retCode = Core.Ema(0, 19, PriceBar.Close, 20, out outBegIndex, out outNBElement, output);
            _EMA10d = output[0];
          
            //ATR (Average True Range):
            retCode = Core.Atr(0, 14,PriceBar.High,PriceBar.Low, PriceBar.Close, 14, out outBegIndex, out outNBElement, output);
            _ATR = output[0];

            //bollinger bands //ok
            retCode = Core.Bbands(0, 19, PriceBar.Close, 20, 2, 2, Core.MAType.Sma, out outBegIndex, out outNBElement, realUpperBand, realMiddleBand, realLowerBand);
            _BollingerUpperBand = realUpperBand[0];
            _BollingerMiddleBand = realMiddleBand[0];
            _BollingerLowerBand = realLowerBand[0];

            //CCI (Commodity Channel Index) for 20 period
            retCode = Core.Cci(0, 19, PriceBar.High, PriceBar.Low, PriceBar.Close, 20, out outBegIndex, out outNBElement, output);
            _CCI = output[0];

            //MACD(Moving Average Convergence Divergence)//ok
            retCode = Core.Macd(0, 25, PriceBar.Close,12, 26, 9, out outBegIndex, out outNBElement, macd, macdSignal, macdHist);
            _MACDLine = macd[0];
            _MACDSignalLine = macdSignal[0];
            _MACDHistogram = macdHist[0];//oscillators

            //Relative Strength Index (RSI)
            retCode = Core.Rsi(0, 13, PriceBar.Close,14, out outBegIndex, out outNBElement, output);
            _RSI = output[0];

            //Stochastic Oscillator//ok
          //  retCode = Core.Stoch(0, 19, PriceBar.High, PriceBar.Low, PriceBar.Close, 14, 3, Core.MAType.Sma, 3, Core.MAType.Sma, out outBegIndex, out outNBElement, StochSlowK, StochSlowD);
           // _Stochastic = StochSlowK[0];

            TMCandlePattern candle= new TMCandlePattern(this.PriceBar);
            _bullishPatternFormed = candle.BullishPatternFormed;
            _bearishPatternFormed = candle.BearishPatternFormed;
            candle = null;

             }





    }
}
