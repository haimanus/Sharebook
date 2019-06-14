using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Objects
{
    public class TMStockInfo : ITMStockEnt
    {
       //specific stock related parameters

        public TMStockInfo()
        {
           
        }

        public string Symbol { get; set; }


        public int StockID { get; set; }


        public float AskPrice { get; set; }

      
        public float HV1m { get; set; }

       
        public float HV1mHigh52wk { get; set; }


        public float HV1mLow52wk { get; set; }


        public float HV1mYest { get; set; }


        public float IVX1m { get; set; }


        public float IVX1mHigh52wk { get; set; }


        public float IVX1mLow52wk { get; set; }


        public float IVX1mYest { get; set; }


        public DateTime LastDate { get; set; }


        public float LastPrice { get; set; }


        public float LastSize { get; set; }


        public float OptionVolumeAvg { get; set; }


        public float OptionVolumeCall { get; set; }


        public float OptionVolumePut { get; set; }


        public float OutstandingShares { get; set; }


        public float PriceClose { get; set; }


        public float PriceHigh52wk { get; set; }


        public float PriceLow52wk { get; set; }


        public bool BullishCandlestickPatternFormed { get; set; }


        public bool BearishCandlestickPatternFormed { get; set; }


        public int Volume { get; set; }


        public double RSI { get; set; }


        public double Stochastic { get; set; }


        public double MACDHistogram { get; set; }


        public double MACDSignalLine { get; set; }


        public double MACDLine { get; set; }


        public double CCI { get; set; }


        public double ATR { get; set; }


        public double EMA10d { get; set; }


        public double BollingerUpperBand { get; set; }


        public double BollingerMiddleBand { get; set; }


        public double BollingerLowerBand { get; set; }


        public double SMA200day { get; set; }


        public double SMA50day { get; set; }


        public double SMA20day { get; set; }


        public bool IsBullishCandleFormed { get; set; }


        public bool IsBearishCandleFormed { get; set; }
       
    }
}
