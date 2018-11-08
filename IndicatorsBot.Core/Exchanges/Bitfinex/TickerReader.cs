using IndicatorsBot.Core.Exchanges.Interfaces;
using IndicatorsBot.Core.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IndicatorsBot.Core.Exchanges.Bitfinex
{
    public class TickerReader : IExchangeTickerReader
    {
        public event EventHandler<Ticker> TickerReady;
        public event EventHandler<string> OnError;
        public bool Enabled { get; set; }
        static HttpClient client = new HttpClient();
        public string Route { get; set; }
        public string Address { get; set; }
        public int PoolingInterval { get; set; }
        public TickerReader()
        {
            Address = Common.BitFinexAPIAddress;
            PoolingInterval = Common.PoolingInterval;
        }

        public async Task Start(string ticker)
        {
            Enabled = true;

            while (Enabled)
            {
                try
                {
                    FetchTicker(ticker);
                }
                catch (Exception ex)
                {
                    string e = null;
                    if (ex.InnerException != null)
                    {
                        e = ex.InnerException.Message;
                    }
                    else
                    {
                        e = ex.Message;
                    }
                    OnError(this, e);
                    await Task.Delay(PoolingInterval * 2);
                }

                await Task.Delay(PoolingInterval);
            }
        }

        public void FetchTicker(string ticker)
        {
            Route = string.Format("v1/pubticker/{0}", ticker);

            HttpResponseMessage response = client.GetAsync(Address + Route).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            dynamic stuff = JObject.Parse(responseBody);

            var handler = TickerReady;

            if (handler != null)
            {
                var args = new Ticker()
                {
                    mid = stuff.mid,
                    bid = stuff.bid,
                    ask = stuff.ask,
                    last_price = stuff.last_price,
                    low = stuff.low,
                    high = stuff.high,
                    volume = stuff.volume,
                    timestamp = stuff.timestamp
                };

                handler(this, args);
            }
        }

        public void Stop()
        {
            Enabled = false;
        }
    }
}