
namespace PckStudio.Forms.Editor
{
	partial class AudioEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioEditor));
            this.trackListTreeView = new System.Windows.Forms.TreeView();
            this.trackListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCategoryStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCategoryStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackListIcons = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trackTreeView = new System.Windows.Forms.TreeView();
            this.trackContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playOverworldInCreative = new MetroFramework.Controls.MetroCheckBox();
            this.compressionUpDown = new System.Windows.Forms.NumericUpDown();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.trackListContextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.trackContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressionUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // trackListTreeView
            // 
            resources.ApplyResources(this.trackListTreeView, "trackListTreeView");
            this.trackListTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.trackListTreeView.ContextMenuStrip = this.trackListContextMenuStrip;
            this.trackListTreeView.ForeColor = System.Drawing.Color.White;
            this.trackListTreeView.ImageList = this.trackListIcons;
            this.trackListTreeView.LabelEdit = true;
            this.trackListTreeView.Name = "trackListTreeView";
            this.trackListTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trackListTreeView_AfterSelect);
            this.trackListTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackListTreeView_KeyDown);
            // 
            // trackListContextMenuStrip
            // 
            this.trackListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategoryStripMenuItem,
            this.removeCategoryStripMenuItem,
            this.changeCategoryToolStripMenuItem});
            this.trackListContextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.trackListContextMenuStrip, "trackListContextMenuStrip");
            // 
            // addCategoryStripMenuItem
            // 
            this.addCategoryStripMenuItem.Name = "addCategoryStripMenuItem";
            resources.ApplyResources(this.addCategoryStripMenuItem, "addCategoryStripMenuItem");
            this.addCategoryStripMenuItem.Click += new System.EventHandler(this.addTrackListStripMenuItem_Click);
            // 
            // removeCategoryStripMenuItem
            // 
            this.removeCategoryStripMenuItem.Name = "removeCategoryStripMenuItem";
            resources.ApplyResources(this.removeCategoryStripMenuItem, "removeCategoryStripMenuItem");
            this.removeCategoryStripMenuItem.Click += new System.EventHandler(this.removeTrackListStripMenuItem_Click);
            // 
            // changeCategoryToolStripMenuItem
            // 
            this.changeCategoryToolStripMenuItem.Name = "changeCategoryToolStripMenuItem";
            resources.ApplyResources(this.changeCategoryToolStripMenuItem, "changeCategoryToolStripMenuItem");
            this.changeCategoryToolStripMenuItem.Click += new System.EventHandler(this.setTrackListToolStripMenuItem_Click);
            // 
            // trackListIcons
            // 
            this.trackListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("trackListIcons.ImageStream")));
            this.trackListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.trackListIcons.Images.SetKeyName(0, "0_overworld.png");
            this.trackListIcons.Images.SetKeyName(1, "1_nether.png");
            this.trackListIcons.Images.SetKeyName(2, "2_end.png");
            this.trackListIcons.Images.SetKeyName(3, "3_creative.png");
            this.trackListIcons.Images.SetKeyName(4, "4_menu.png");
            this.trackListIcons.Images.SetKeyName(5, "5_mg01.png");
            this.trackListIcons.Images.SetKeyName(6, "6_mg02.png");
            this.trackListIcons.Images.SetKeyName(7, "7_mg03.png");
            this.trackListIcons.Images.SetKeyName(8, "8_mg04.png");
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveToolStripMenuItem1
            // 
            resources.ApplyResources(this.saveToolStripMenuItem1, "saveToolStripMenuItem1");
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // trackTreeView
            // 
            this.trackTreeView.AllowDrop = true;
            resources.ApplyResources(this.trackTreeView, "trackTreeView");
            this.trackTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.trackTreeView.ContextMenuStrip = this.trackContextMenuStrip;
            this.trackTreeView.ForeColor = System.Drawing.Color.White;
            this.trackTreeView.Name = "trackTreeView";
            this.trackTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.Binka_DragDrop);
            this.trackTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView2_DragEnter);
            this.trackTreeView.DoubleClick += new System.EventHandler(this.trackTreeView_DoubleClick);
            this.trackTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackTreeView_KeyDown);
            // 
            // trackContextMenuStrip
            // 
            this.trackContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEntryMenuItem,
            this.editEntryToolStripMenuItem,
            this.removeEntryMenuItem});
            this.trackContextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.trackContextMenuStrip, "trackContextMenuStrip");
            // 
            // addEntryMenuItem
            // 
            this.addEntryMenuItem.Name = "addEntryMenuItem";
            resources.ApplyResources(this.addEntryMenuItem, "addEntryMenuItem");
            this.addEntryMenuItem.Click += new System.EventHandler(this.addEntryMenuItem_Click);
            // 
            // editEntryToolStripMenuItem
            // 
            this.editEntryToolStripMenuItem.Name = "editEntryToolStripMenuItem";
            resources.ApplyResources(this.editEntryToolStripMenuItem, "editEntryToolStripMenuItem");
            this.editEntryToolStripMenuItem.Click += new System.EventHandler(this.editEntryToolStripMenuItem_Click);
            // 
            // removeEntryMenuItem
            // 
            this.removeEntryMenuItem.Name = "removeEntryMenuItem";
            resources.ApplyResources(this.removeEntryMenuItem, "removeEntryMenuItem");
            this.removeEntryMenuItem.Click += new System.EventHandler(this.removeEntryMenuItem_Click);
            // 
            // playOverworldInCreative
            // 
            resources.ApplyResources(this.playOverworldInCreative, "playOverworldInCreative");
            this.playOverworldInCreative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playOverworldInCreative.ForeColor = System.Drawing.SystemColors.Window;
            this.playOverworldInCreative.Name = "playOverworldInCreative";
            this.playOverworldInCreative.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.playOverworldInCreative.UseCustomBackColor = true;
            this.playOverworldInCreative.UseCustomForeColor = true;
            this.playOverworldInCreative.UseSelectable = true;
            // 
            // compressionUpDown
            // 
            resources.ApplyResources(this.compressionUpDown, "compressionUpDown");
            this.compressionUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.compressionUpDown.ForeColor = System.Drawing.SystemColors.Window;
            this.compressionUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.compressionUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.compressionUpDown.Name = "compressionUpDown";
            this.compressionUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // AudioEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.compressionUpDown);
            this.Controls.Add(this.playOverworldInCreative);
            this.Controls.Add(this.trackListTreeView);
            this.Controls.Add(this.trackTreeView);
            this.Controls.Add(this.menuStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioEditor";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioEditor_FormClosing);
            this.trackListContextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.trackContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.compressionUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView trackListTreeView;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
		private System.Windows.Forms.TreeView trackTreeView;
		private System.Windows.Forms.ContextMenuStrip trackListContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem removeCategoryStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addCategoryStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip trackContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addEntryMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeEntryMenuItem;
        private System.Windows.Forms.ImageList trackListIcons;
		private MetroFramework.Controls.MetroCheckBox playOverworldInCreative;
		private System.Windows.Forms.NumericUpDown compressionUpDown;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private System.Windows.Forms.ToolStripMenuItem changeCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEntryToolStripMenuItem;
    }
}