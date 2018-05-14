using IndicatorsBot.Core.Indicators;
using System;

namespace IndicatorsBot.Core.Model
{
    public class BBandSignal : ISignal
    {
        public DateTime CloseDate { get; set; }
        public decimal Price { get; set; }
        public double SMA { get; set; } //Middle Band 20-Day SMA
        public double SD { get; set; } //20-Day Standard Deviation
        public double UpperBandSMA { get; set; } //Upper Band 20-Day SMA + STDEV x 2
        public double LowerBandSMA { get; set; } //Lower Band 20-Day SMA - STDEV x 2
        public double BandWidth { get; set; } 
    }
}
