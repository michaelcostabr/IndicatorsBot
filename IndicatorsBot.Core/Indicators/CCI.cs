using IndicatorsBot.Core.Model;
using System;
using System.Collections.Generic;

namespace IndicatorsBot.Core.Indicators
{
    public class CCI
    {
        private List<CCISignal> Values = new List<CCISignal>();
        public EventHandler<CCISignal> IndicatorReady;
        public EventHandler<string> OnError;

        public CCISignal this[int index]
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

        public void Add(DateTime TradeDate, decimal HighPrice, decimal LowPrice, decimal Price)
        {
            try
            {
                var trade = new CCISignal() { CloseDate = TradeDate, ClosePrice = Price, HighPrice = HighPrice, LowPrice = LowPrice};

                trade.TypicalPrice = Math.Round((trade.HighPrice + trade.LowPrice + trade.ClosePrice) / 3, 4);

                 if (this.Values.Count >= 19)
                {
                    //calculate SMA
                    decimal sumOfPrices = trade.TypicalPrice;

                    this.Values.GetRange(this.Values.Count-19, 19).ForEach(i => sumOfPrices += i.TypicalPrice);

                    trade.SMA = Math.Round((double)(sumOfPrices / 20), 4);

                    //calculate MAD
                    double mad = Math.Abs(trade.SMA - (double)trade.TypicalPrice);
                    this.Values.GetRange(this.Values.Count - 19, 19).ForEach(i => mad += Math.Abs(trade.SMA - ((double)i.TypicalPrice)));

                    trade.MAD = Math.Round(mad / 20,4);

                    //calculate 20-period CCI
                    trade.CCI = Math.Round(((double)trade.TypicalPrice - trade.SMA) / (0.015 * trade.MAD), 4); 

                    //calc trend based on the inclination
                    double y1, y2;
                    double x1, x2;

                    x2 = this.Values.Count;
                    x1 = x2 - 14;

                    y2 = this.Values[this.Values.Count - 1].CCI;
                    y1 = this.Values[this.Values.Count - 19].CCI;

                    trade.Inclination = (y2 - y1) / (x2 - x1);

                    trade.UpTrend = trade.Inclination > 0;
                }

                Values.Add(trade);
                IndicatorReady?.Invoke(this, trade);
            }
            catch (Exception ex)
            {
                if (this.OnError != null) OnError(this, ex.Message);
            }
        }

        private void calculateCCI(CCISignal trade)
        {
            
        }

        public int Count
        {
            get => this.Values.Count;
        }
    }
}
