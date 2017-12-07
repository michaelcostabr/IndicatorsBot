using IndicatorsBot.Core.Model;
using System;
using System.Collections.Generic;

namespace IndicatorsBot.Core.Indicators
{
    public class Trades
    {
        private List<Trade> Values = new List<Trade>();
        public EventHandler<Trade> IndicatorReady;
        public EventHandler<string> OnError;

        public Trade this[int index]
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
                var trade = new Trade() { CloseDate = TradeDate, ClosePrice = Price };
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
                }

                Values.Add(trade);
                IndicatorReady(this, trade);
            }
            catch (Exception ex)
            {
                if (this.OnError != null) OnError(this, ex.Message);
            }
        }

        private void calculateRSI(Trade trade)
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
