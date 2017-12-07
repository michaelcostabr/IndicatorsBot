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
        static double lastRSI = 0;
        static bool upTrend = false;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray; //Console.ResetColor() is not working :(
            Console.CancelKeyPress += Console_CancelKeyPress;

            var ticker = string.Empty;

            if (args.Length > 0)
            {
                ticker = args[0];

            } else
            {
                while (ticker == string.Empty)
                {
                    Console.WriteLine("Type in the ticker name to start indicator's calculation: (hit ENTER for BTCUSD)");
                    ticker = Console.ReadLine();
                    if (string.IsNullOrEmpty(ticker)) ticker = "BTCUSD";
                }
            }

            Console.WriteLine($"Fetching trade data for {ticker.ToUpper()}...");

            var trades = new Trades();
            var bfxReader = new Core.Exchanges.Bitfinex.TickerReader();
            var tickerHndl = new TickerHandler(bfxReader, trades);

            tickerHndl.OnError += tickerHndl_OnError;
            tickerHndl.IndicatorReady += tickerHndl_IndicatorReady;
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

        private static void tickerHndl_IndicatorReady(object sender, Trade e)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            if ((!upTrend) && (e.RSI <= 70))
            {
                //bearishing
                Console.ForegroundColor = ConsoleColor.Red;
            }

            if ((upTrend) && (e.RSI >= 30))
            {
                //bullishing
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine($"{e.CloseDate.ToString("HH:mm:ss")} Last Trade: {e.ClosePrice} - RSI: {e.RSI}");

            upTrend = (e.RSI > lastRSI);
        }
    }    
}
