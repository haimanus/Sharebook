using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using TM.DAL;
using TM.Objects;
namespace TM.Rules.Web
{
    public partial class RuleResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        private void BindData()
        {


            List<TMRuleResult> ruleResults = new List<TMRuleResult>();
            ruleResults = DalManager.GetRuleResults(DateTime.Now, 0);

            GridView1.DataSource = ruleResults;
            GridView1.DataBind();

            GridView2.DataSource = ruleResults;
            GridView2.DataBind();
        }
    }
}