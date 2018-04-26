using IndicatorsBot.Core;
using IndicatorsBot.Core.Indicators;
using IndicatorsBot.Core.Model;
using System;
using System.Threading.Tasks;

namespace IndicatorsBot.ConsoleApp
{
    class Program
    {
        static bool enabled = true;

        static void Main(string[] args)
        {

            /*var hist = new Core.Exchanges.Bitfinex.TickerHistoryReader();
            var lista = hist.GetHistory("BTCUSD", 30, 14);*/            

            Console.ForegroundColor = ConsoleColor.Gray; //Console.ResetColor() is not working :(
            Console.CancelKeyPress += Console_CancelKeyPress;

            var ticker = string.Empty;
            string indicator = string.Empty;

            if (args.Length > 0)
            {
                ticker = args[0];

                if (args.Length > 1) indicator = args[1];

            } else
            {
                while (ticker == string.Empty)
                {
                    Console.WriteLine("Type in the ticker name: (hit ENTER for BTCUSD)");
                    ticker = Console.ReadLine();
                    if (string.IsNullOrEmpty(ticker)) ticker = "BTCUSD";
                }
            }            

            while (indicator == string.Empty)
            {
                Console.WriteLine("Type in the indicator name to start calculation: (hit ENTER for RSI)");
                indicator = Console.ReadLine();
                if (string.IsNullOrEmpty(indicator)) indicator = "RSI";
            }

            Console.WriteLine($"Fetching trade data for {ticker.ToUpper()}...");

            //on the next verion, it's gonna be an interface
            RSI RSITrades = null;
            CCI CCITrades = null;

            var bfxReader = new Core.Exchanges.Bitfinex.TickerReader();

            TickerHandler tickerHndl = null;

            //getting the 14 last minutes history
            var hist = new Core.Exchanges.Bitfinex.TickerCandlesReader();

            if (indicator == "RSI")
            {
                RSITrades = new RSI();
                tickerHndl = new TickerHandler(bfxReader, RSITrades);
                tickerHndl.RSIReady += tickerHndl_RSI_IndicatorReady;

                var lista = hist.GetHistory("BTCUSD", Core.Exchanges.Bitfinex.Common.CandleInterval1Min, 15);
                foreach (Ticker t in lista)
                {
                    RSITrades.Add(t.UtcDateTime, t.last_price);
                }
            }
            else
            {
                CCITrades = new CCI();
                tickerHndl = new TickerHandler(bfxReader, CCITrades);
                tickerHndl.CCIReady += tickerHndl_CCI_IndicatorReady;

                var lista = hist.GetHistory("BTCUSD", Core.Exchanges.Bitfinex.Common.CandleInterval1Min, 100);
                foreach (Ticker t in lista)
                {
                    CCITrades.Add(t.UtcDateTime,t.high, t.low, t.last_price);
                }
            }
            tickerHndl.OnError += tickerHndl_OnError;
            
            bfxReader.Enabled = true;
            Task.Run(async () =>
            {
                await bfxReader.Start(ticker.ToUpper());
            });

            while (enabled) ;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Program ended.");            
        }

        private static void tickerHndl_OnError(object sender, string e)
        {
            Console.WriteLine($"Error: {e}");
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            enabled = false;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Finishing...");
        }

        private static void tickerHndl_RSI_IndicatorReady(object sender, RSISignal e)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            if (!e.UpTrend && (e.RSI <= 70))
            {
                //bearishing
                Console.ForegroundColor = ConsoleColor.Red;
            }

            if (e.UpTrend && (e.RSI >= 30))
            {
                //bullishing
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine($"{e.CloseDate.ToString("HH:mm:ss")} Last Trade: {e.ClosePrice} - RSI: {e.RSI}");
        }

        private static void tickerHndl_CCI_IndicatorReady(object sender, CCISignal e)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            if (!e.UpTrend && (e.CCI <= -100))
            {
                //bearishing
                Console.ForegroundColor = ConsoleColor.Red;
            }

            if (e.UpTrend && (e.CCI >= 100))
            {
                //bullishing
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine($"{e.CloseDate.ToString("HH:mm:ss")} Last Trade: {e.ClosePrice} - CCI: {e.CCI}");
        }
    }    
}
