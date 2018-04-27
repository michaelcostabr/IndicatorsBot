# IndicatorsBot
A .Net Core project to automatize the calculation or some trading indicators, like (RSI, CCI, Moving Averages and etc.).

On the console app, it checks for cryptocurrency trades

Usage: On a command shell, type in:
dotnet IndicatorsBot.ConsoleApp.dll [Ticker]


Version 0.1 - Reading RSI for the last 1 minute at Bitfinex. 
			  For reading 5, 15, 60 minutes and so on, you just need to create threads that get the last trade price whithin those intervals and add it to another respective IndicatorsBot.Core.Indicators.Trades list.
			  
Version 0.2 - Handling CCI calculations. Just need to implement its use on the program.			  

Version 0.3 - Getting historical candles data, so it is not necessary to wait for X measures to get the first indicator ready.
