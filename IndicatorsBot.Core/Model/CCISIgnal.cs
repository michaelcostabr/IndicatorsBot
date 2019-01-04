using System;

namespace IndicatorsBot.Core.Model
{
    public class CCISignal
    {
        public DateTime CloseDate { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal TypicalPrice { get; set; }
        public double SMA { get; set; } //Simple Moving Average
        public double MAD { get; set; } //Moving Average Deviation
        public double CCI { get; set; }
        public double Inclination { get; set; }
        public bool UpTrend { get; set; }
    }
}
