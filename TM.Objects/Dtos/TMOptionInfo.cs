using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Objects
{
    public class TMOptionInfo : ITMOptionEnt
    {
        public float OptionAskPrice
        { get; set; }

        public float OptionBidPrice
        { get; set; }

        public float OptionDelta
        { get; set; }

        public DateTime OptionExpirationDate
        { get; set; }

        public float OptionGamma
        { get; set; }

        public float OptionIV
        { get; set; }

        public float OptionLastPrice
        { get; set; }

        public int OptionOpenInterest
        { get; set; }

        public EgarDDSEnt.OptionTypeEnum OptionOptionType
        { get; set; }

        public float OptionPreIV
        { get; set; }

        public float OptionRho
        { get; set; }

        public float OptionStrikePrice
        { get; set; }

        public float OptionTheta
        { get; set; }

        public float OptionVega
        { get; set; }

        public int OptionVolume
        { get; set; }
    }
}
