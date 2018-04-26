/*
 * I started writing this class, but ended up discovering that Bitfinex API v1/trades/ endpoint never returns the ticker closest to the unix epoch time passed.
 * The class is fully functional, but with this API is not trustable.
 * I'll keep the code, for future purposes but I'll abandon the usage and find another way to the the ticker history
 * */
using IndicatorsBot.Core.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace IndicatorsBot.Core.Exchanges.Bitfinex
{
    [Obsolete("Not working fine with bitfinex API. Use TickerCandles instead", false)]
    public class TickerHistoryReader
    {
        readonly HttpClient client = new HttpClient();
        private string Route;
        private readonly string Address;

        public TickerHistoryReader() => Address = Common.BitFinexAPIAddress;

        public static DateTime FromUnixTime(long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public List<Ticker> GetHistory(string ticker, int intervalInMinutes, int quantity)
        {
            var result = new List<Ticker>();
            
            long currentUnixEpochTime = (long)Math.Truncate((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);

            long startMilliseconds = currentUnixEpochTime - (intervalInMinutes * 60 * quantity);

            for (int i = 1; i <= quantity; i++)
            {
                long currentUnixTime = startMilliseconds + (intervalInMinutes * 60 * i);
                bool success = false;
                while (!success)
                {
                    result.Add(GetQuoteByDate(ticker, currentUnixTime, out success));
                    System.Threading.Thread.Sleep(10000); //wait 10 seconds to avoid HTTP 429 error (Too Many Requests)
                }                
            }

            return result;            
        }

        private Ticker GetQuoteByDate(string ticker, long unixEpochTime, out bool success)
        {            
            Route = string.Format("v1/trades/{0}?timestamp={1}&limit_trades=1", ticker, unixEpochTime);

            HttpResponseMessage response = client.GetAsync(Address + Route).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            dynamic stuff = JArray.Parse(responseBody);

            var t = new Ticker()
            {
                last_price = stuff[0].price,
                timestamp = stuff[0].timestamp,
                UtcDateTime = FromUnixTime(unixEpochTime)
            };

            Console.WriteLine($"meu {t.UtcDateTime} ({unixEpochTime}) - api {FromUnixTime((long)t.timestamp)} ({t.timestamp}): {t.last_price}");
            success = true;
            return t;
        }
    }
}
