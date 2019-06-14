using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using TM.Objects;
using TM.DAL;
using System.Data;

namespace TM.Rules.Web
{
    public partial class DefineRules : System.Web.UI.Page
    {
        DalManager dalmanager = new DalManager();
        protected void Page_Load(object sender, EventArgs e)
        {
        

            if (!Page.IsPostBack)
            {
                ddlEntity.Items.Add("Stock");
                ddlEntity.Items.Add("Options");

                lblRuleType.Text = ddlEntity.Text;

                BindData();


            }
            

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ruleTestControl.IsEmpty || !this.ruleTestControl.IsValid) return;
            //   string file = Server.MapPath("/Rules/Rule.config");
            string ruleXml = this.ruleTestControl.GetRuleXml();
            // File.WriteAllText(file, rule);
            //   string ruleText = ruleTestControl.GetClientRuleData();
            string ruleText = ruleTestControl.ToString();
            TMRule rule = new TMRule();
            rule.RuleName = txtRuleName.Text.Trim();
            rule.RuleType = ddlEntity.Text;
            rule.RuleText = ruleText;
            rule.RuleXml = ruleXml;
            rule.RuleDescription = txtDescription.Text.Trim();
            rule.ExecutionOrder = int.Parse(txtExecOrder.Text);
            bool result = DalManager.InsertRule(rule);
            ruleTestControl.Clear();
            txtDescription.Text = "";
            txtExecOrder.Text = "";
            txtRuleName.Text = "";
            BindData();
           
        }



        protected void btnShowEnt_Click(object sender, EventArgs e)
        {
            if (ddlEntity.Text.Equals("Options"))
            {
                this.ruleTestControl.SourceType = "TM.Objects.TMOptionEnt";
            }
            else if (ddlEntity.Text.Equals("Stock"))
            {
                this.ruleTestControl.SourceType = "TM.Objects.TMStockEnt";
            }
            lblRuleType.Text = ddlEntity.Text;
        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int ruleID = Convert.ToInt32(e.CommandArgument);
                // Delete the record 
                DeleteRecordByID(ruleID);
                BindData();
            }

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");

                l.Attributes.Add("onclick", "javascript:return " +
                     "confirm('Are you sure you want to delete this record " +
                     DataBinder.Eval(e.Row.DataItem, "RuleName") + "')");

            }
        }
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int ruleID = (int)grdRules.DataKeys[e.RowIndex].Value;
            //DeleteRecordByID(ruleID);
            //BindData();
        }

        private void DeleteRecordByID(int ruleID)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(ConnectionString);

            try
            {

                // Create the DeleteCommand.
                string CommandText = "DELETE FROM Rules WHERE RuleID = " + ruleID;
                SqlCommand myCommand = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myConnection.Close();
            }



        }

        private void BindData()
        {
            // make the query 
            string ConnectionString = ConfigurationManager.ConnectionStrings["SMConnectionString"].ToString();

            string query = "SELECT [RuleID], [RuleName], [RuleType], [RuleText], [RuleDescription], [ExecutionOrder], [IsActive], [CreatedDate] FROM [Rules] ORDER BY [ExecutionOrder]";


            SqlConnection myConnection = new SqlConnection(ConnectionString);
            SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Rules");
            grdRules.DataSource = ds;
            grdRules.DataBind();

        }
    }
}