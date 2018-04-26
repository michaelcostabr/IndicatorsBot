using System;

namespace IndicatorsBot.Core.Model
{
    public class Ticker
    {
        public decimal mid;
        public decimal bid;
        public decimal ask;
        public decimal last_price;
        public decimal low;
        public decimal high;
        public decimal volume;
        public decimal timestamp;
        public DateTime UtcDateTime;
    }

}
