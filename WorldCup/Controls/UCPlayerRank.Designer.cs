namespace WorldCup.Controls
{
    partial class UCPlayerRank
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPlayerRank));
            this.imgPlayer = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblApearences = new System.Windows.Forms.Label();
            this.lblGoalsScored = new System.Windows.Forms.Label();
            this.lblYellowCard = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPlayer
            // 
            this.imgPlayer.Image = ((System.Drawing.Image)(resources.GetObject("imgPlayer.Image")));
            this.imgPlayer.Location = new System.Drawing.Point(0, 0);
            this.imgPlayer.Name = "imgPlayer";
            this.imgPlayer.Size = new System.Drawing.Size(62, 70);
            this.imgPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPlayer.TabIndex = 0;
            this.imgPlayer.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(68, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(266, 41);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Full Name";
            // 
            // lblApearences
            // 
            this.lblApearences.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblApearences.Location = new System.Drawing.Point(334, 13);
            this.lblApearences.Name = "lblApearences";
            this.lblApearences.Size = new System.Drawing.Size(126, 29);
            this.lblApearences.TabIndex = 2;
            this.lblApearences.Text = "App";
            this.lblApearences.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGoalsScored
            // 
            this.lblGoalsScored.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGoalsScored.Location = new System.Drawing.Point(466, 13);
            this.lblGoalsScored.Name = "lblGoalsScored";
            this.lblGoalsScored.Size = new System.Drawing.Size(127, 29);
            this.lblGoalsScored.TabIndex = 3;
            this.lblGoalsScored.Text = "Goal";
            this.lblGoalsScored.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYellowCard
            // 
            this.lblYellowCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblYellowCard.Location = new System.Drawing.Point(608, 13);
            this.lblYellowCard.Name = "lblYellowCard";
            this.lblYellowCard.Size = new System.Drawing.Size(66, 29);
            this.lblYellowCard.TabIndex = 4;
            this.lblYellowCard.Text = "YC";
            this.lblYellowCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCPlayerRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblYellowCard);
            this.Controls.Add(this.lblGoalsScored);
            this.Controls.Add(this.lblApearences);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.imgPlayer);
            this.Name = "UCPlayerRank";
            this.Size = new System.Drawing.Size(685, 67);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox imgPlayer;
        private Label lblName;
        private Label lblApearences;
        private Label lblGoalsScored;
        private Label lblYellowCard;
    }
}
