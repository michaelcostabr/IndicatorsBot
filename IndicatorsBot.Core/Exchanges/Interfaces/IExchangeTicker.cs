using IndicatorsBot.Core.Model;
using System;
using System.Threading.Tasks;

namespace IndicatorsBot.Core.Exchanges.Interfaces
{
    public interface IExchangeTickerReader
    {
        event EventHandler<Ticker> TickerReady;
        event EventHandler<string> OnError;
        bool Enabled { get; set; }
        int PoolingInterval { get; set; }
        Task Start(string ticker);
        void Stop();
    }
}
