namespace WorldCup
{
    partial class FavoritePlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritePlayers));
            this.lblAllPlayers = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblFavPlayers = new System.Windows.Forms.Label();
            this.pnlAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.playerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToFavouretesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.ddlRepresentation = new System.Windows.Forms.ComboBox();
            this.lblTilte = new System.Windows.Forms.Label();
            this.playerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAllPlayers
            // 
            this.lblAllPlayers.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblAllPlayers, "lblAllPlayers");
            this.lblAllPlayers.Name = "lblAllPlayers";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblError, "lblError");
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Name = "lblError";
            // 
            // lblFavPlayers
            // 
            this.lblFavPlayers.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblFavPlayers, "lblFavPlayers");
            this.lblFavPlayers.Name = "lblFavPlayers";
            // 
            // pnlAllPlayers
            // 
            this.pnlAllPlayers.AllowDrop = true;
            resources.ApplyResources(this.pnlAllPlayers, "pnlAllPlayers");
            this.pnlAllPlayers.BackColor = System.Drawing.Color.Transparent;
            this.pnlAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAllPlayers.ContextMenuStrip = this.playerContextMenuStrip;
            this.pnlAllPlayers.Name = "pnlAllPlayers";
            this.pnlAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlPlayers_DragDrop);
            this.pnlAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlPlayers_DragEnter);
            // 
            // playerContextMenuStrip
            // 
            this.playerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.playerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToFavouretesToolStripMenuItem});
            this.playerContextMenuStrip.Name = "playerContextMenuStrip";
            resources.ApplyResources(this.playerContextMenuStrip, "playerContextMenuStrip");
            this.playerContextMenuStrip.Opened += new System.EventHandler(this.playerContextMenuStrip_Opened);
            // 
            // moveToFavouretesToolStripMenuItem
            // 
            this.moveToFavouretesToolStripMenuItem.Name = "moveToFavouretesToolStripMenuItem";
            resources.ApplyResources(this.moveToFavouretesToolStripMenuItem, "moveToFavouretesToolStripMenuItem");
            this.moveToFavouretesToolStripMenuItem.Click += new System.EventHandler(this.moveToOtherList_Click);
            // 
            // pnlFavoritePlayers
            // 
            this.pnlFavoritePlayers.AllowDrop = true;
            resources.ApplyResources(this.pnlFavoritePlayers, "pnlFavoritePlayers");
            this.pnlFavoritePlayers.BackColor = System.Drawing.Color.Transparent;
            this.pnlFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFavoritePlayers.ContextMenuStrip = this.playerContextMenuStrip;
            this.pnlFavoritePlayers.Name = "pnlFavoritePlayers";
            this.pnlFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlPlayers_DragDrop);
            this.pnlFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlPlayers_DragEnter);
            // 
            // ddlRepresentation
            // 
            this.ddlRepresentation.FormattingEnabled = true;
            resources.ApplyResources(this.ddlRepresentation, "ddlRepresentation");
            this.ddlRepresentation.Name = "ddlRepresentation";
            this.ddlRepresentation.SelectedIndexChanged += new System.EventHandler(this.ddlRepresentation_SelectedIndexChanged);
            // 
            // lblTilte
            // 
            resources.ApplyResources(this.lblTilte, "lblTilte");
            this.lblTilte.BackColor = System.Drawing.Color.Transparent;
            this.lblTilte.Name = "lblTilte";
            // 
            // FavoritePlayers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.lblTilte);
            this.Controls.Add(this.ddlRepresentation);
            this.Controls.Add(this.pnlFavoritePlayers);
            this.Controls.Add(this.pnlAllPlayers);
            this.Controls.Add(this.lblAllPlayers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblFavPlayers);
            this.Name = "FavoritePlayers";
            this.playerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAllPlayers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblFavPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlAllPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlFavoritePlayers;
        private System.Windows.Forms.ContextMenuStrip playerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem moveToFavouretesToolStripMenuItem;
        private ComboBox ddlRepresentation;
        private Label lblTilte;
    }
}