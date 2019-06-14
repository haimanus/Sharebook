using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TM.Objects;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace TM.DAL
{
    public  class DalManager
    {

        static string strConnectionString = string.Empty;

         public DalManager()
         {
             if (strConnectionString.Equals(string.Empty))
             {
                 strConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
             }
         }
        public static  List<TMRule> GetRules(string ruleCategory)
        {
            if (strConnectionString.Equals(string.Empty))
            {
                strConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
            }
            List<TMRule> rules = new List<TMRule>();

            SqlConnection con;
            SqlCommand cmd;
            try
            {

                con = new SqlConnection(strConnectionString);
                cmd = new SqlCommand("GetRules", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.Parameters.Add("@RuleType", SqlDbType.Int).Value = ruleCategory.ToUpper() == "OPTION" ? 2 : 1;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TMRule rule = new TMRule();

                    rule.RuleID = Convert.ToInt32(dr["RuleID"]);
                    rule.RuleName = Convert.ToString(dr["RuleName"]);
                    rule.RuleDescription = Convert.ToString(dr["RuleDescription"]);
                    rule.RuleType = ruleCategory;
                    rule.RuleXml = Convert.ToString(dr["RuleXml"]);
                    rule.RuleText = Convert.ToString(dr["RuleText"]);
                    rule.ExecutionOrder = Convert.ToInt32(dr["ExecutionOrder"]);
                    rules.Add(rule);


                }
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                rules = null;         
                throw ex;
            }
            finally
            {
                    
                con = null;
                cmd = null;
            }

            return rules;
        }


        public static List<TMStockInfo> GetStockSymbols()
        {
            if (strConnectionString.Equals(string.Empty))
            {
                strConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
            }
            List<TMStockInfo> symbols = new List<TMStockInfo>();

            SqlConnection con;
            SqlCommand cmd;
            try
            {

                con = new SqlConnection(strConnectionString);
                cmd = new SqlCommand("GetStockSymbols", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TMStockInfo symbol = new TMStockInfo();

                    symbol.StockID = Convert.ToInt32(dr["StockID"]);
                    symbol.Symbol = Convert.ToString(dr["StockSymbol"]);

                    symbols.Add(symbol);



                }
                //TMStockInfo symbol = new TMStockInfo();
                //symbol.StockID = 1;
                //symbol.Symbol = "IBM";
                //symbols.Add(symbol);

                //symbol = new TMStockInfo();
                //symbol.StockID = 2;
                //symbol.Symbol = "GOOG";
                //symbols.Add(symbol);


                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                symbols = null;
                throw ex;
            }
            finally
            {

                con = null;
                cmd = null;
            }

            return symbols;
        }



        public static bool InsertRule(TMRule rule)
        {

            if (strConnectionString.Equals(string.Empty))
            {
                strConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
            }

            try
            {
               

                SqlConnection con = new SqlConnection(strConnectionString);
                SqlCommand cmd = new SqlCommand("InsertRule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();

                cmd.Parameters.Add("@RuleName", SqlDbType.VarChar).Value = rule.RuleName;
                cmd.Parameters.Add("@RuleType", SqlDbType.Int).Value = rule.RuleType == "Stock" ? 1 : 2;
                cmd.Parameters.Add("@RuleXml", SqlDbType.VarChar).Value = rule.RuleXml;
                cmd.Parameters.Add("@RuleText", SqlDbType.VarChar).Value = rule.RuleText;
                cmd.Parameters.Add("@RuleDescription", SqlDbType.VarChar).Value = rule.RuleDescription;
                cmd.Parameters.Add("@ExecutionOrder", SqlDbType.Int).Value = rule.ExecutionOrder;



                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                cmd = null;
                con = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public static bool InsertLog(string source, string message)
        {

            if (strConnectionString.Equals(string.Empty))
            {
                strConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
            }

            try
            {


                SqlConnection con = new SqlConnection(strConnectionString);
                SqlCommand cmd = new SqlCommand("InsertLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();

                //cmd.Parameters.Add("@RuleName", SqlDbType.VarChar).Value = rule.RuleName;
                //cmd.Parameters.Add("@RuleType", SqlDbType.Int).Value = rule.RuleType == "Stock" ? 1 : 2;
              



                //cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                cmd = null;
                con = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public static List<string> GetLogs(string source)
        {
            if (strConnectionString.Equals(string.Empty))
            {
                strConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
            }
            List<string> messages = new List<string>();
            messages.Add("test");
            return messages;
        }

        public static List<TMRuleResult> GetRuleResults(DateTime CreatedDate, int EntityType) //0=stock;1=option
        {
            if (strConnectionString.Equals(string.Empty))
            {
                strConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
            }
            List<TMRuleResult> results = new List<TMRuleResult>();
            SqlConnection con;
            SqlCommand cmd;
            try
            {

                con = new SqlConnection(strConnectionString);
                cmd = new SqlCommand("GetRuleResult", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = CreatedDate;
                cmd.Parameters.Add("@entityType", SqlDbType.Int).Value = EntityType;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TMRuleResult result = new TMRuleResult();

                    result.RuleID = Convert.ToInt32(dr["RuleID"]);
                    result.RuleName = Convert.ToString(dr["RuleName"]);
                    result.RuleDescription = Convert.ToString(dr["RuleDescription"]);
                    result.Company = Convert.ToString(dr["Company"]); ;
                    result.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    result.EntityType = Convert.ToInt16(dr["EntityType"]);
                    result.StockID = Convert.ToInt32(dr["StockID"]);
                    result.StockSymbol = Convert.ToString(dr["StockSymbol"]);
                    result.XmlResult = Convert.ToString(dr["XmlResult"]);


                    results.Add(result);


                }
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                results = null;
                throw ex;
            }
            finally
            {

                con = null;
                cmd = null;
            }

            return results;
        }
    }



}

