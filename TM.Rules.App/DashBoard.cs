using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using TM.Rules.Engine;
using TM.Objects;
using TM.DAL;
namespace TM.Rules.App
{
    public partial class DashBoard : Form,IDisposable   
    {
        private int timerTicker = 0;
        Executor exec = new Executor();
        
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMDataSet.Rules' table. You can move, or remove it, as needed.

            BindData();

        }
        private void BindData()
        {
            List<TMRule> rules = new List<TMRule>();
            rules = DalManager.GetRules("OPTION");
           grdRules.DataSource = rules;
           grdRules.Update();

           List<string> logs = new List<string>();
           logs = DalManager.GetLogs("EXEC");
           grdLog.DataSource = logs;
           grdLog.Update();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            timerTicker++; //ticks every 1 minute
            lblTimerDetails.Text = "Current Counter :" + timerTicker.ToString() + ";Next execution at:" + DateTime.Now.Add(new TimeSpan(0, 300 - timerTicker, 0));
           
            if (timerTicker >= 300)//in five hours ; once
            {
                exec.ExecuteOptionRules();
                timerTicker = 0; //reset
            }
            if (Math.IEEERemainder (timerTicker ,10)==0)//in every 10 minutes ; once execute stock rules
            {
                exec.ExecuteStockRules();
            }

        }

        private void chkAutostart_CheckedChanged(object sender, EventArgs e)
        {
            string keyName = "RulesApp";
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;  // Or the EXE path.

            // Set Auto-start.
            if (chkAutostart.Checked)
            {
                Util.SetAutoStart(keyName, assemblyLocation);
            }
            else
            {
                // Unset Auto-start.
                if (Util.IsAutoStartEnabled(keyName, assemblyLocation))
                    Util.UnSetAutoStart(keyName);
            }
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exec.ExecuteStockRules();
            exec.ExecuteOptionRules();
        }

        void IDisposable.Dispose()
        {
            //throw new NotImplementedException();
            exec = null;
        }
    }
}
