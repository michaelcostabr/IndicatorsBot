using IndicatorsBot.Core.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace IndicatorsBot.Core.Exchanges.Bitfinex
{
    public class TickerCandlesReader
    {
        readonly HttpClient client = new HttpClient();
        private string Route;
        private readonly string Address;

        public TickerCandlesReader() => Address = Common.BitFinexAPIAddress;

        public static DateTime FromUnixTime(long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public List<Ticker> GetHistory(string ticker, string period, int interval)
        {
            var result = new List<Ticker>();

            Route = string.Format($"v2/candles/trade:{period}:t{ticker}/hist?limit={interval}");

            HttpResponseMessage response = client.GetAsync(Address + Route).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            dynamic stuff = JArray.Parse(responseBody);

            for (int i = interval-1; i >= 0; i--)
            {
                var t = new Ticker()
                {
                    last_price = stuff[i][2],
                    timestamp = stuff[i][0]/1000,
                    high = stuff[i][3],
                    low = stuff[i][4]
                };

                t.UtcDateTime = FromUnixTime((long)t.timestamp).ToLocalTime();

                result.Add(t);

                //Console.WriteLine($"{FromUnixTime((long)t.timestamp).ToLocalTime()} ({t.timestamp}): {t.last_price}");
            }

            return result;
        }
    }
}
