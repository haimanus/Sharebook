using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeEffects.Rule;
using EgarDDSEnt;
using TM.Objects;
using TM.DAL;
using TM.Reader;
using CodeEffects.Rule.Core;
namespace TM.Rules.Engine
{
    public partial class Executor : IDisposable
    {
        IVDDSEnt dds;
        //DalManager dalmanager = new DalManager();
        public Executor()
        {
            //dds = new IVDDSEnt();
            //dds.Connect("haimanus6", "realgrim");

            //read from profitstocksonline.com for all candle patterns for the day & keep in a list
        }
        public void ExecuteAll()
        {
            ExecuteOptionRules();
            ExecuteStockRules();
        }
        public void ExecuteOptionRules()
        {
            List<TMRule> rules = new List<TMRule>();
            rules = DalManager.GetRules("Option");


            if (rules != null && rules.Count>0)
            {
                IOptionsEnt DDSoption=null;
                IStocksEnt DDStock=null;
                List<TMStockInfo> optionSymbols = DalManager.GetStockSymbols();//get all symbols
                DalManager.InsertLog("EXEC", "ExecuteOptionRules started at:" + DateTime.Now.ToString());
                foreach (TMStockInfo symbol in optionSymbols)
                {
                    try
                    {
                      //  DDSoption = dds.GetOptionsByStock(symbol.Symbol);
                      //  DDStock = dds.GetStockBySymbol(symbol.Symbol);

                        
                        TMStockEnt TMstock = new TMStockEnt(symbol.Symbol, symbol.StockID, DDStock);
                        TMstock.PriceBar = YahooAPI.GetHistoricalData(symbol.Symbol,DateTime.Now.AddDays(-360));//need to change with an interface or factory pattern
                        TMstock.GenerateIndicators();//creates all sma , bollinger, candles etc

                        while (DDSoption.Next())
                        {
                            TMOptionEnt TMoption = new TMOptionEnt(symbol.Symbol, symbol.StockID, DDSoption);
                            TMoption.StockEnt = TMstock;
                           
                            foreach (TMRule rule in rules)
                            {
                                TMoption.RuleName = rule.RuleName;
                                TMoption.RuleID = rule.RuleID;

                                //Evaluator<TMOptionEnt> e = new Evaluator<TMOptionEnt>(rule.RuleXml);
                                //bool success = e.Evaluate(TMoption);
                                DalManager.InsertLog("EXEC:OPTION", "Option rule:" + rule.RuleName + " executed for stock:" + symbol.Symbol + "; strike price: " + DDSoption.StrikePrice.ToString()  + " & expiration date:" + DDSoption.ExpirationDate.ToString() + "; on " + DateTime.Now.ToString()); 

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //handle exception here. log to db
                        int x;
                    }

                }
                DalManager.InsertLog("EXEC", "ExecuteOptionRules ended at:" + DateTime.Now.ToString());

            }
           

        }
        public void ExecuteStockRules()
        {
            List<TMRule> rules = new List<TMRule>();
            rules = DalManager.GetRules("Stock");


            if (rules != null && rules.Count>0)
            {
                IStocksEnt ddsStock =null;

                List<TMStockInfo> stockSymbols = DalManager.GetStockSymbols();
                DalManager.InsertLog("EXEC", "ExecuteStockRules started at:" + DateTime.Now.ToString());

                foreach (TMStockInfo symbol in stockSymbols)
                {
                    try
                    {
                        ddsStock = dds.GetStockBySymbol(symbol.Symbol);

                        TMStockEnt tmStock = new TMStockEnt(symbol.Symbol, symbol.StockID, ddsStock);

                        tmStock.PriceBar = YahooAPI.GetHistoricalData(symbol.Symbol, DateTime.Now.AddDays(-360));//need to change with an interface or factory pattern
                        tmStock.GenerateIndicators();//creates all sma , bollinger, candles etc

                        foreach (TMRule rule in rules)
                        {
                            tmStock.RuleName = rule.RuleName;                           
                            tmStock.RuleID = rule.RuleID;

                            //Evaluator<TMStockEnt> e = new Evaluator<TMStockEnt>(rule.RuleXml);
                            //bool success = e.Evaluate(tmStock);
                            DalManager.InsertLog("EXEC:STOCK","Stock rule:" + rule.RuleName + " executed for stock:" + symbol.Symbol + " on " + DateTime.Now.ToString()); 

                        }
                    }
                    catch (Exception ex)
                    {
                        //handle exception here
                        int x;
                    }

                }
                DalManager.InsertLog("EXEC", "ExecuteStockRules ended at:" + DateTime.Now.ToString());

            }

        }

        public void Dispose()
        {
            dds.Disconnect();
               GC.Collect();
           
        }
    }
}

