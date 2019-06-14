using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Objects
{
   public  class TMPriceBar
    {
        //price bar
       DateTime[] _Date = new DateTime[Constants.HISTORY_SIZE];
       double[] _Open = new double[Constants.HISTORY_SIZE];
       double[] _Close = new double[Constants.HISTORY_SIZE];
       double[] _High = new double[Constants.HISTORY_SIZE];
       double[] _Low = new double[Constants.HISTORY_SIZE];
       double[] _Volume = new double[Constants.HISTORY_SIZE];

        public DateTime[] Date 
        { 
            get
            {
                return _Date;
            }
           set
           {
               _Date = value;
           }
        }
        public double[] Open
        {
            get
            {
                return _Open;
            }
            set
            {
                _Open = value;
            }
        }
        public double[] Close
        {
            get
            {
                return _Close;
            }
            set
            {
                _Close = value;
            }
        }
        public double[] High
        {
            get
            {
                return _High;
            }
            set
            {
                _High = value;
            }
        }
        public double[] Low
        {
            get
            {
                return _Low;
            }
            set
            {
                _Low = value;
            }
        }
        public double[] Volume
        {
            get
            {
                return _Volume;
            }
            set
            {
                _Volume = value;
            }
        }
    }
}
