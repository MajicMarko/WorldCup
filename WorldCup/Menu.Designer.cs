namespace WorldCup
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbChampionship = new System.Windows.Forms.GroupBox();
            this.Men = new System.Windows.Forms.RadioButton();
            this.Women = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.gbChampionship.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // lblLanguage
            // 
            this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbChampionship
            // 
            this.gbChampionship.BackColor = System.Drawing.Color.Transparent;
            this.gbChampionship.Controls.Add(this.Men);
            this.gbChampionship.Controls.Add(this.Women);
            this.gbChampionship.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.gbChampionship, "gbChampionship");
            this.gbChampionship.Name = "gbChampionship";
            this.gbChampionship.TabStop = false;
            // 
            // Men
            // 
            resources.ApplyResources(this.Men, "Men");
            this.Men.Name = "Men";
            this.Men.UseVisualStyleBackColor = true;
            // 
            // Women
            // 
            this.Women.Checked = true;
            resources.ApplyResources(this.Women, "Women");
            this.Women.Name = "Women";
            this.Women.TabStop = true;
            this.Women.UseVisualStyleBackColor = true;
            // 
            // btnLanguage
            // 
            this.btnLanguage.BackColor = System.Drawing.Color.Azure;
            this.btnLanguage.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnLanguage, "btnLanguage");
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.UseVisualStyleBackColor = false;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // Menu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ControlBox = false;
            this.Controls.Add(this.btnLanguage);
            this.Controls.Add(this.gbChampionship);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblTitle);
            this.Name = "Menu";
            this.gbChampionship.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbChampionship;
        private System.Windows.Forms.RadioButton Men;
        private System.Windows.Forms.RadioButton Women;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnLanguage;
    }
}

