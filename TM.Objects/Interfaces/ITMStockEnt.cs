using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Objects
{
    interface ITMStockEnt
    {
        float AskPrice
        {
            get;
        }

         float HV1m
        {
            get;
        }

         float HV1mHigh52wk
        {
            get;
        }
         float HV1mLow52wk
        {
            get;
        }
         float HV1mYest
        {
            get;
        }
         float IVX1m
        {
            get;
        }
         float IVX1mHigh52wk
        {
            get;
        }
         float IVX1mLow52wk
        {
            get;
        }
         float IVX1mYest
        {
            get;
        }
         DateTime LastDate
        {
            get;
        }
         float LastPrice
        {
            get;
        }
         float LastSize
        {
            get;
        }
         float OptionVolumeAvg
        {
            get;
        }
         float OptionVolumeCall
        {
            get;
        }
         float OptionVolumePut
        {
            get;
        }
         float OutstandingShares
        {
            get;
        }
         float PriceClose
        {
            get;
        }
         float PriceHigh52wk
        {
            get;
        }
         float PriceLow52wk
        {
            get;
        }
         bool BullishCandlestickPatternFormed
        {
            get;
        }
         bool BearishCandlestickPatternFormed
        {
            get;
        }
         int Volume
        {
            get;
        }
         double RSI
        {
            get;
        }
         double Stochastic
        {
            get;
        }
         double MACDHistogram
        {
            get;
        }
         double MACDSignalLine
        {
            get;
        }
         double MACDLine
        {
            get;
        }
         double CCI
        {
            get;
        }
         double ATR
        {
            get;
        }
         double EMA10d
        {
            get;
        }
         double BollingerUpperBand
        {
            get;
        }
         double BollingerMiddleBand
        {
            get;
        }
         double BollingerLowerBand
        {
            get;
        }
         double SMA200day
        {
            get;
        }
         double SMA50day
        {
            get;
        }
         double SMA20day
        {
            get;
        }
      
    }
}
