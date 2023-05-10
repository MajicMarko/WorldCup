namespace WorldCup
{
    partial class RangList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangList));
            this.lblName = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblApp = new System.Windows.Forms.Label();
            this.lblGoal = new System.Windows.Forms.Label();
            this.lblYellowCard = new System.Windows.Forms.Label();
            this.pnlMatches = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrintPlayers = new System.Windows.Forms.Button();
            this.btnSortPlayers = new System.Windows.Forms.Button();
            this.rbCardDesc = new System.Windows.Forms.RadioButton();
            this.rbCardAsc = new System.Windows.Forms.RadioButton();
            this.rbGoalDesc = new System.Windows.Forms.RadioButton();
            this.rbGoalAsc = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrintMatchs = new System.Windows.Forms.Button();
            this.btnSortMatchs = new System.Windows.Forms.Button();
            this.rbAppDesc = new System.Windows.Forms.RadioButton();
            this.rbAppAsc = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnChangeSettings = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.lblError, "lblError");
            this.lblError.Name = "lblError";
            // 
            // pnlPlayers
            // 
            resources.ApplyResources(this.pnlPlayers, "pnlPlayers");
            this.pnlPlayers.Name = "pnlPlayers";
            // 
            // lblApp
            // 
            this.lblApp.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblApp, "lblApp");
            this.lblApp.Name = "lblApp";
            // 
            // lblGoal
            // 
            this.lblGoal.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblGoal, "lblGoal");
            this.lblGoal.Name = "lblGoal";
            // 
            // lblYellowCard
            // 
            this.lblYellowCard.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblYellowCard, "lblYellowCard");
            this.lblYellowCard.Name = "lblYellowCard";
            // 
            // pnlMatches
            // 
            resources.ApplyResources(this.pnlMatches, "pnlMatches");
            this.pnlMatches.BackColor = System.Drawing.Color.Transparent;
            this.pnlMatches.Name = "pnlMatches";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnPrintPlayers);
            this.groupBox1.Controls.Add(this.btnSortPlayers);
            this.groupBox1.Controls.Add(this.rbCardDesc);
            this.groupBox1.Controls.Add(this.rbCardAsc);
            this.groupBox1.Controls.Add(this.rbGoalDesc);
            this.groupBox1.Controls.Add(this.rbGoalAsc);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnPrintPlayers
            // 
            this.btnPrintPlayers.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnPrintPlayers, "btnPrintPlayers");
            this.btnPrintPlayers.Name = "btnPrintPlayers";
            this.btnPrintPlayers.UseVisualStyleBackColor = false;
            this.btnPrintPlayers.Click += new System.EventHandler(this.btnPrintPlayers_Click);
            // 
            // btnSortPlayers
            // 
            this.btnSortPlayers.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnSortPlayers, "btnSortPlayers");
            this.btnSortPlayers.Name = "btnSortPlayers";
            this.btnSortPlayers.UseVisualStyleBackColor = false;
            this.btnSortPlayers.Click += new System.EventHandler(this.btnSortPlayers_Click);
            // 
            // rbCardDesc
            // 
            resources.ApplyResources(this.rbCardDesc, "rbCardDesc");
            this.rbCardDesc.Name = "rbCardDesc";
            this.rbCardDesc.TabStop = true;
            this.rbCardDesc.UseVisualStyleBackColor = true;
            // 
            // rbCardAsc
            // 
            resources.ApplyResources(this.rbCardAsc, "rbCardAsc");
            this.rbCardAsc.Name = "rbCardAsc";
            this.rbCardAsc.TabStop = true;
            this.rbCardAsc.UseVisualStyleBackColor = true;
            // 
            // rbGoalDesc
            // 
            resources.ApplyResources(this.rbGoalDesc, "rbGoalDesc");
            this.rbGoalDesc.Name = "rbGoalDesc";
            this.rbGoalDesc.TabStop = true;
            this.rbGoalDesc.UseVisualStyleBackColor = true;
            // 
            // rbGoalAsc
            // 
            resources.ApplyResources(this.rbGoalAsc, "rbGoalAsc");
            this.rbGoalAsc.Checked = true;
            this.rbGoalAsc.Name = "rbGoalAsc";
            this.rbGoalAsc.TabStop = true;
            this.rbGoalAsc.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnPrintMatchs);
            this.groupBox2.Controls.Add(this.btnSortMatchs);
            this.groupBox2.Controls.Add(this.rbAppDesc);
            this.groupBox2.Controls.Add(this.rbAppAsc);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnPrintMatchs
            // 
            this.btnPrintMatchs.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnPrintMatchs, "btnPrintMatchs");
            this.btnPrintMatchs.Name = "btnPrintMatchs";
            this.btnPrintMatchs.UseVisualStyleBackColor = false;
            this.btnPrintMatchs.Click += new System.EventHandler(this.btnPrintMatchs_Click);
            // 
            // btnSortMatchs
            // 
            this.btnSortMatchs.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnSortMatchs, "btnSortMatchs");
            this.btnSortMatchs.Name = "btnSortMatchs";
            this.btnSortMatchs.UseVisualStyleBackColor = false;
            this.btnSortMatchs.Click += new System.EventHandler(this.btnSortMatches_Click);
            // 
            // rbAppDesc
            // 
            resources.ApplyResources(this.rbAppDesc, "rbAppDesc");
            this.rbAppDesc.Name = "rbAppDesc";
            this.rbAppDesc.UseVisualStyleBackColor = true;
            // 
            // rbAppAsc
            // 
            resources.ApplyResources(this.rbAppAsc, "rbAppAsc");
            this.rbAppAsc.Checked = true;
            this.rbAppAsc.Name = "rbAppAsc";
            this.rbAppAsc.TabStop = true;
            this.rbAppAsc.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // btnChangeSettings
            // 
            this.btnChangeSettings.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnChangeSettings, "btnChangeSettings");
            this.btnChangeSettings.Name = "btnChangeSettings";
            this.btnChangeSettings.UseVisualStyleBackColor = false;
            this.btnChangeSettings.Click += new System.EventHandler(this.btnChangeSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RangList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChangeSettings);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.pnlMatches);
            this.Controls.Add(this.lblApp);
            this.Controls.Add(this.lblYellowCard);
            this.Controls.Add(this.lblGoal);
            this.Name = "RangList";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel pnlMatches;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayers;
        private System.Windows.Forms.Label lblYellowCard;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblError;
        private GroupBox groupBox1;
        private Button btnSortPlayers;
        private RadioButton rbCardDesc;
        private RadioButton rbCardAsc;
        private RadioButton rbGoalDesc;
        private RadioButton rbGoalAsc;
        private GroupBox groupBox2;
        private RadioButton rbAppDesc;
        private RadioButton rbAppAsc;
        private Button btnSortMatchs;
        private Label lblTitle;
        private Button btnPrintPlayers;
        private Button btnPrintMatchs;
        private Button btnChangeSettings;
        private Button btnClose;
    }
}