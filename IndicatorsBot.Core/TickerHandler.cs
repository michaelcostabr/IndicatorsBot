using IndicatorsBot.Core.Exchanges.Bitfinex;
using IndicatorsBot.Core.Exchanges.Interfaces;
using IndicatorsBot.Core.Indicators;
using IndicatorsBot.Core.Model;
using System;

namespace IndicatorsBot.Core
{
    public class TickerHandler
    {
        //on the next verion, it's gonna be an interface
        private RSI _rsi = null;
        private CCI _cci = null;
        private IExchangeTickerReader _tickerReader = null;
        public EventHandler<RSISignal> RSIReady;
        public EventHandler<CCISignal> CCIReady;
        public EventHandler<string> OnError;

        public TickerHandler(IExchangeTickerReader tickerReader, RSI trades)
        {
            _rsi = trades;
            _tickerReader = tickerReader;

            _tickerReader.PoolingInterval = Common.PoolingInterval;
            _tickerReader.TickerReady += _tickerReader_TickerReady;
            _tickerReader.OnError += _tickerReader_OnError;
            _rsi.IndicatorReady += _rsi_IndicatorReady;
        }

        public TickerHandler(IExchangeTickerReader tickerReader, CCI trades)
        {
            _cci = trades;
            _tickerReader = tickerReader;

            _tickerReader.PoolingInterval = Common.PoolingInterval;
            _tickerReader.TickerReady += _tickerReader_TickerReady;
            _tickerReader.OnError += _tickerReader_OnError;
            _cci.IndicatorReady += _cci_IndicatorReady;
        }

        private void _tickerReader_OnError(object sender, string e)
        {
            if (this.OnError != null) OnError(this, e);
        }

        private void _tickerReader_TickerReady(object sender, Ticker e)
        {
            _rsi?.Add(DateTime.Now, e.last_price);
            _cci?.Add(DateTime.Now, e.high, e.low, e.last_price);
        }

        private void _rsi_IndicatorReady(object sender, RSISignal e)
        {            
            RSIReady(this, e);
        }

        private void _cci_IndicatorReady(object sender, CCISignal e)
        {
            CCIReady(this, e);
        }
    }
}
