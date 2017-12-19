using IndicatorsBot.Core.Exchanges.Interfaces;
using IndicatorsBot.Core.Indicators;
using IndicatorsBot.Core.Model;
using System;

namespace IndicatorsBot.Core
{
    public class TickerHandler
    {
        private RSI _trades = null;
        private IExchangeTickerReader _tickerReader = null;
        public EventHandler<RSISignal> RSIReady;
        public EventHandler<string> OnError;

        public TickerHandler(IExchangeTickerReader tickerReader, RSI trades)
        {
            _trades = trades;
            _tickerReader = tickerReader;

            _tickerReader.PoolingInterval = 4280; //provides 14 readings in a minute
            _tickerReader.TickerReady += _tickerReader_TickerReady;
            _tickerReader.OnError += _tickerReader_OnError;
            _trades.IndicatorReady += _trades_IndicatorReady;
        }

        private void _tickerReader_OnError(object sender, string e)
        {
            if (this.OnError != null) OnError(this, e);
        }

        private void _tickerReader_TickerReady(object sender, Ticker e) => _trades.Add(DateTime.Now, e.last_price);

        private void _trades_IndicatorReady(object sender, RSISignal e)
        {            
            RSIReady(this, e);
        }
    }
}
