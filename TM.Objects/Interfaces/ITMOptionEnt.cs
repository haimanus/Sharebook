using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EgarDDSEnt;

namespace TM.Objects
{
    interface ITMOptionEnt
    {
        float OptionAskPrice
        {
            get;

        }

        float OptionBidPrice
        {
            get;

        }
        float OptionDelta
        {
            get;

        }

        DateTime OptionExpirationDate
        {
            get;

        }
        float OptionGamma
        {
            get;

        }
        float OptionIV
        {
            get;

        }
        float OptionLastPrice
        {
            get;

        }
        int OptionOpenInterest
        {
            get;

        }
        OptionTypeEnum OptionOptionType
        {
            get;

        }
        float OptionPreIV
        {
            get;

        }
        float OptionRho
        {
            get;

        }
        float OptionStrikePrice
        {
            get;

        }
        float OptionTheta
        {
            get;

        }
        float OptionVega
        {
            get;

        }
        int OptionVolume
        {
            get;

        }
    }
}
