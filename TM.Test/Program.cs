using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TM.Objects;
using TM.DAL ;
using TM.Reader;
namespace TM.Test
{
    class Program
    {
        
        static void Main(string[] args)
        {
             DalManager dalmanager = new DalManager();
             List<TMStockInfo> optionSymbols = DalManager.GetStockSymbols();//get all symbols
            foreach (TMStockInfo symbol in optionSymbols)
            {
                TMStockEnt TMstock = new TMStockEnt(symbol.Symbol, symbol.StockID);
                TMstock.PriceBar =YahooAPI.GetHistoricalData(symbol.Symbol, DateTime.Now.AddDays(-250));//need to change with an interface or factory pattern

                
                Console.WriteLine(TMstock.Symbol);

                foreach (double close in TMstock.PriceBar.Close )
                {
                    Console.WriteLine(close.ToString() );
                }
                Console.ReadKey();

                TMstock.GenerateIndicators();//creates all sma , bollinger, candles etc
            }
        }
    }
}
