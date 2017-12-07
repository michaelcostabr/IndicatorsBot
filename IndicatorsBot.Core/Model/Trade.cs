using System;

namespace IndicatorsBot.Core.Model
{
    public class Trade
    {
        public string Ticker { get; set; }
        public DateTime CloseDate { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal Change { get; set; }
        public decimal Gain { get; set; }
        public decimal Loss { get; set; }
        public decimal AverageGain { get; set; }
        public decimal AverageLoss { get; set; }
        public double RS { get; set; }
        public double RSI { get; set; }
    }
}
