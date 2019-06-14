using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace TM.Objects
{
    public class Storage
    {
        static string strConnectionString = string.Empty;


        public static bool InsertRuleResults(int RuleID, int StockID, string xmlResult, DateTime CreatedDate, int EntityType ) //0=stock;1=option
        {
            try
            {
                if (strConnectionString.Equals(string.Empty))
                {
                    strConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
                }

                SqlConnection con = new SqlConnection(strConnectionString);
                SqlCommand cmd = new SqlCommand("InsertRuleResult", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.Parameters.Add("@RuleID", SqlDbType.Int).Value = RuleID;
                cmd.Parameters.Add("@StockID", SqlDbType.Int).Value = StockID;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate;
                cmd.Parameters.Add("@xmlResult", SqlDbType.VarChar).Value = xmlResult;
                cmd.Parameters.Add("@EntityType", SqlDbType.Int).Value = EntityType;
          
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

      
    }
}