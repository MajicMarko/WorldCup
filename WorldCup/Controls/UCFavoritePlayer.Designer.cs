namespace WorldCup.Controls
{
    partial class UCFavoritePlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFavoritePlayer));
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPlayerNumber = new System.Windows.Forms.Label();
            this.lblPlayerPosition = new System.Windows.Forms.Label();
            this.lblPlayerCapetan = new System.Windows.Forms.Label();
            this.imgPlayer = new System.Windows.Forms.PictureBox();
            this.imgFavorite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFavorite)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerName.Location = new System.Drawing.Point(12, 11);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(285, 45);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "Name";
            // 
            // lblPlayerNumber
            // 
            this.lblPlayerNumber.AutoSize = true;
            this.lblPlayerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerNumber.Location = new System.Drawing.Point(3, 75);
            this.lblPlayerNumber.Name = "lblPlayerNumber";
            this.lblPlayerNumber.Size = new System.Drawing.Size(112, 79);
            this.lblPlayerNumber.TabIndex = 1;
            this.lblPlayerNumber.Text = "10";
            // 
            // lblPlayerPosition
            // 
            this.lblPlayerPosition.AutoSize = true;
            this.lblPlayerPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerPosition.Location = new System.Drawing.Point(12, 175);
            this.lblPlayerPosition.Name = "lblPlayerPosition";
            this.lblPlayerPosition.Size = new System.Drawing.Size(117, 32);
            this.lblPlayerPosition.TabIndex = 2;
            this.lblPlayerPosition.Text = "Position";
            // 
            // lblPlayerCapetan
            // 
            this.lblPlayerCapetan.AutoSize = true;
            this.lblPlayerCapetan.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerCapetan.Location = new System.Drawing.Point(131, 112);
            this.lblPlayerCapetan.Name = "lblPlayerCapetan";
            this.lblPlayerCapetan.Size = new System.Drawing.Size(67, 69);
            this.lblPlayerCapetan.TabIndex = 3;
            this.lblPlayerCapetan.Text = "C";
            // 
            // imgPlayer
            // 
            this.imgPlayer.Image = ((System.Drawing.Image)(resources.GetObject("imgPlayer.Image")));
            this.imgPlayer.Location = new System.Drawing.Point(226, 46);
            this.imgPlayer.Name = "imgPlayer";
            this.imgPlayer.Size = new System.Drawing.Size(125, 108);
            this.imgPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPlayer.TabIndex = 5;
            this.imgPlayer.TabStop = false;
            this.imgPlayer.Click += new System.EventHandler(this.imgPlayer_Click);
            // 
            // imgFavorite
            // 
            this.imgFavorite.Image = ((System.Drawing.Image)(resources.GetObject("imgFavorite.Image")));
            this.imgFavorite.Location = new System.Drawing.Point(131, 59);
            this.imgFavorite.Name = "imgFavorite";
            this.imgFavorite.Size = new System.Drawing.Size(60, 60);
            this.imgFavorite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFavorite.TabIndex = 6;
            this.imgFavorite.TabStop = false;
            this.imgFavorite.Visible = false;
            // 
            // UCFavoritePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(187)))), ((int)(((byte)(234)))));
            this.Controls.Add(this.imgFavorite);
            this.Controls.Add(this.imgPlayer);
            this.Controls.Add(this.lblPlayerCapetan);
            this.Controls.Add(this.lblPlayerPosition);
            this.Controls.Add(this.lblPlayerNumber);
            this.Controls.Add(this.lblPlayerName);
            this.Name = "UCFavoritePlayer";
            this.Size = new System.Drawing.Size(370, 217);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFavorite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblPlayerName;
        private Label lblPlayerNumber;
        private Label lblPlayerPosition;
        private Label lblPlayerCapetan;
        private PictureBox imgPlayer;
        private PictureBox imgFavorite;
    }
}
