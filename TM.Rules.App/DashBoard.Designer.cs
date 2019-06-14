namespace TM.Rules.App
{
    partial class DashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.grdRules = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimerDetails = new System.Windows.Forms.Label();
            this.chkAutostart = new System.Windows.Forms.CheckBox();
            this.grdLog = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Execute Now";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grdRules
            // 
            this.grdRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRules.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdRules.Location = new System.Drawing.Point(12, 72);
            this.grdRules.Name = "grdRules";
            this.grdRules.ReadOnly = true;
            this.grdRules.Size = new System.Drawing.Size(964, 154);
            this.grdRules.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rules to execute:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimerDetails
            // 
            this.lblTimerDetails.AutoSize = true;
            this.lblTimerDetails.Location = new System.Drawing.Point(110, 53);
            this.lblTimerDetails.Name = "lblTimerDetails";
            this.lblTimerDetails.Size = new System.Drawing.Size(35, 13);
            this.lblTimerDetails.TabIndex = 3;
            this.lblTimerDetails.Text = "label2";
            // 
            // chkAutostart
            // 
            this.chkAutostart.AutoSize = true;
            this.chkAutostart.Location = new System.Drawing.Point(805, 53);
            this.chkAutostart.Name = "chkAutostart";
            this.chkAutostart.Size = new System.Drawing.Size(137, 17);
            this.chkAutostart.TabIndex = 4;
            this.chkAutostart.Text = "Autostart with Windows";
            this.chkAutostart.UseVisualStyleBackColor = true;
            this.chkAutostart.CheckedChanged += new System.EventHandler(this.chkAutostart_CheckedChanged);
            // 
            // grdLog
            // 
            this.grdLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLog.Location = new System.Drawing.Point(12, 259);
            this.grdLog.Name = "grdLog";
            this.grdLog.ReadOnly = true;
            this.grdLog.Size = new System.Drawing.Size(964, 154);
            this.grdLog.TabIndex = 5;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 442);
            this.Controls.Add(this.grdLog);
            this.Controls.Add(this.chkAutostart);
            this.Controls.Add(this.lblTimerDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdRules);
            this.Controls.Add(this.button1);
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grdRules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimerDetails;
        private System.Windows.Forms.CheckBox chkAutostart;
        private System.Windows.Forms.DataGridView grdLog;
    }
}

