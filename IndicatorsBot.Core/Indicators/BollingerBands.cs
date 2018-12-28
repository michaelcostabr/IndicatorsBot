
using IndicatorsBot.Core.Model;
using System;
using System.Collections.Generic;

namespace IndicatorsBot.Core.Indicators
{
    public class BollingerBands
    {
        private readonly List<BBandSignal> Values = new List<BBandSignal>();
        private EventHandler<BBandSignal> indicatorReady;
        private EventHandler<string> onError;

        public BBandSignal this[int index]
        {
            get
            {
                return this.Values[index];
            }

            set
            {
                this.Values[index] = value;
            }
        }

        public void Add(DateTime TradeDate, decimal Price)
        {
            try
            {
                var trade = new BBandSignal() { Price = Price, CloseDate = TradeDate};

                if (this.Values.Count >= 19)
                {
                    decimal sumOfPrices = trade.Price;
                    this.Values.GetRange(this.Values.Count - 19, 19).ForEach(i => sumOfPrices += i.Price);

                    //Middle Band 20-Day SMA
                    trade.SMA = Math.Round((double)(sumOfPrices / 20), 4);

                    //Standard Deviation formula
                    //SD = Sqrt((∑∣x−μ∣²)/N)
                    double aux = Math.Pow(Math.Abs((double)Price - trade.SMA), 2);
                    this.Values.GetRange(this.Values.Count - 19, 19).ForEach(i => aux += Math.Pow(((double)i.Price - trade.SMA), 2));
                    trade.SD = Math.Round(Math.Sqrt(aux / 20), 4);

                    trade.UpperBandSMA = Math.Round(trade.SMA + trade.SD * 2, 2);

                    trade.LowerBandSMA = Math.Round(trade.SMA - trade.SD * 2, 2);

                    trade.BandWidth = Math.Round(trade.UpperBandSMA - trade.LowerBandSMA, 2);

                    //calc trend based on the inclination
                    decimal y1, y2;
                    decimal x1, x2;

                    x2 = this.Values.Count;
                    x1 = x2 - 19;

                    y2 = this.Values[this.Values.Count - 1].Price;
                    y1 = this.Values[this.Values.Count - 19].Price;

                    trade.Inclination = (y2 - y1) / (x2 - x1);

                    trade.UpTrend = trade.Inclination > 0;

                    var pos = (trade.Price - (decimal)trade.LowerBandSMA) / (decimal)(trade.UpperBandSMA - trade.LowerBandSMA);
                    trade.Position = Math.Round(pos * 100, 4);
                }

                Values.Add(trade);
                if (this.Values.Count >= 19)
                {
                    IndicatorReady?.Invoke(this, trade);
                }
            }
            catch (Exception ex)
            {
                if (this.OnError != null) OnError(this, ex.Message);
            }
        }

        public int Count
        {
            get => this.Values.Count;
        }
        public EventHandler<string> OnError { get => onError; set => onError = value; }
        public EventHandler<BBandSignal> IndicatorReady { get => indicatorReady; set => indicatorReady = value; }
    }
}
