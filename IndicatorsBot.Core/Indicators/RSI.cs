using IndicatorsBot.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndicatorsBot.Core.Indicators
{
    public class RSI
    {
        private List<RSISignal> Values = new List<RSISignal>();
        public string Ticker { get; set; }
        public EventHandler<RSISignal> IndicatorReady;
        public EventHandler<string> OnError;

        public RSISignal this[int index]
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
                var trade = new RSISignal() { CloseDate = TradeDate, ClosePrice = Price };
                if (this.Values.Count > 0)
                {

                    trade.Change = trade.ClosePrice - this.Values[this.Values.Count - 1].ClosePrice;

                    if (trade.Change > 0)
                    {
                        trade.Gain = trade.Change;
                        trade.Loss = 0;
                    }
                    else
                    {
                        trade.Gain = 0;
                        trade.Loss = -trade.Change;
                    }
                }

                if (this.Values.Count == 14)
                {
                    decimal averageGain = 0;
                    decimal averageLoss = 0;

                    this.Values.ForEach(i => averageGain += i.Gain);
                    trade.AverageGain = averageGain / 14;

                    this.Values.ForEach(i => averageLoss += i.Loss);
                    trade.AverageLoss = averageLoss / 14;

                    calculateRSI(trade);
                }
                else if (this.Values.Count > 14)
                {
                    trade.AverageGain = ((this.Values[this.Values.Count - 1].AverageGain * 13) + trade.Gain) / 14;
                    trade.AverageLoss = ((this.Values[this.Values.Count - 1].AverageLoss * 13) + trade.Loss) / 14;

                    calculateRSI(trade);
                    //calc trend based on the inclination
                    double y1, y2;
                    double x1, x2;

                    x2 = this.Values.Count;
                    x1 = x2 - 14;

                    y2 = this.Values[this.Values.Count - 1].RSI;
                    y1 = this.Values[this.Values.Count - 15].RSI;

                    trade.Inclination = (y2 - y1) / (x2 - x1);

                    trade.UpTrend = trade.Inclination > 0;
                }

                Values.Add(trade);

                if (this.Values.Count > 27)
                {
                    calculateStochRSI(Values.Last());
                    //calc trend based on the inclination
                    double y1, y2;
                    double x1, x2;

                    x2 = this.Values.Count;
                    x1 = x2 - 14;

                    y2 = this.Values[this.Values.Count - 1].StochRSI;
                    y1 = this.Values[this.Values.Count - 15].StochRSI;

                    trade.Inclination = (y2 - y1) / (x2 - x1);

                    trade.UpTrendSRSI = trade.Inclination > 0;
                }

                if (this.Values.Count > 14)
                {
                    IndicatorReady?.Invoke(this, trade);
                }
            }
            catch (Exception ex)
            {
                if (this.OnError != null) OnError(this, ex.Message);
            }
        }

        private void calculateStochRSI(RSISignal trade)
        {
            var last14 = this.Values.TakeLast(14);

            double highestRSI = (from x in last14 select x.RSI).Max();
            double lowestRSI = (from x in last14 select x.RSI).Min();

            trade.StochRSI = Math.Round((trade.RSI - lowestRSI) / (highestRSI - lowestRSI), 2);
        }

        private void calculateRSI(RSISignal trade)
        {
            var rs = (double)(trade.AverageGain / trade.AverageLoss);

            trade.RS = Math.Round(rs, 2);

            trade.RSI = trade.AverageLoss == 0 ? 100 : Math.Round(100 - (100 / (1 + rs)), 2);
        }

        public int Count
        {
            get => this.Values.Count;
        }

    }
}
