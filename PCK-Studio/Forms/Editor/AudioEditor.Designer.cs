
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCategoryStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCategoryStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catImages = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trackTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playOverworldInCreative = new MetroFramework.Controls.MetroCheckBox();
            this.compressionUpDown = new System.Windows.Forms.NumericUpDown();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressionUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // trackListTreeView
            // 
            resources.ApplyResources(this.trackListTreeView, "trackListTreeView");
            this.trackListTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.trackListTreeView.ContextMenuStrip = this.contextMenuStrip1;
            this.trackListTreeView.ForeColor = System.Drawing.Color.White;
            this.trackListTreeView.ImageList = this.catImages;
            this.trackListTreeView.LabelEdit = true;
            this.trackListTreeView.Name = "trackListTreeView";
            this.trackListTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.trackListTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategoryStripMenuItem,
            this.removeCategoryStripMenuItem,
            this.changeCategoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // addCategoryStripMenuItem
            // 
            resources.ApplyResources(this.addCategoryStripMenuItem, "addCategoryStripMenuItem");
            this.addCategoryStripMenuItem.Name = "addCategoryStripMenuItem";
            this.addCategoryStripMenuItem.Click += new System.EventHandler(this.addCategoryStripMenuItem_Click);
            // 
            // removeCategoryStripMenuItem
            // 
            this.removeCategoryStripMenuItem.Name = "removeCategoryStripMenuItem";
            resources.ApplyResources(this.removeCategoryStripMenuItem, "removeCategoryStripMenuItem");
            this.removeCategoryStripMenuItem.Click += new System.EventHandler(this.removeCategoryStripMenuItem_Click);
            // 
            // changeCategoryToolStripMenuItem
            // 
            this.changeCategoryToolStripMenuItem.Name = "changeCategoryToolStripMenuItem";
            resources.ApplyResources(this.changeCategoryToolStripMenuItem, "changeCategoryToolStripMenuItem");
            this.changeCategoryToolStripMenuItem.Click += new System.EventHandler(this.setCategoryToolStripMenuItem_Click);
            // 
            // catImages
            // 
            this.catImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("catImages.ImageStream")));
            this.catImages.TransparentColor = System.Drawing.Color.Transparent;
            this.catImages.Images.SetKeyName(0, "0_overworld.png");
            this.catImages.Images.SetKeyName(1, "1_nether.png");
            this.catImages.Images.SetKeyName(2, "2_end.png");
            this.catImages.Images.SetKeyName(3, "3_creative.png");
            this.catImages.Images.SetKeyName(4, "4_menu.png");
            this.catImages.Images.SetKeyName(5, "5_mg01.png");
            this.catImages.Images.SetKeyName(6, "6_mg02.png");
            this.catImages.Images.SetKeyName(7, "7_mg03.png");
            this.catImages.Images.SetKeyName(8, "8_mg04.png");
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
            this.trackTreeView.ContextMenuStrip = this.contextMenuStrip2;
            this.trackTreeView.ForeColor = System.Drawing.Color.White;
            this.trackTreeView.Name = "trackTreeView";
            this.trackTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.Binka_DragDrop);
            this.trackTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView2_DragEnter);
            this.trackTreeView.DoubleClick += new System.EventHandler(this.trackTreeView_DoubleClick);
            this.trackTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView2_KeyDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEntryMenuItem,
            this.editEntryToolStripMenuItem,
            this.removeEntryMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            // 
            // addEntryMenuItem
            // 
            resources.ApplyResources(this.addEntryMenuItem, "addEntryMenuItem");
            this.addEntryMenuItem.Name = "addEntryMenuItem";
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
            this.Shown += new System.EventHandler(this.AudioEditor_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
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
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem removeCategoryStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addCategoryStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem addEntryMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeEntryMenuItem;
        private System.Windows.Forms.ImageList catImages;
		private MetroFramework.Controls.MetroCheckBox playOverworldInCreative;
		private System.Windows.Forms.NumericUpDown compressionUpDown;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private System.Windows.Forms.ToolStripMenuItem changeCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEntryToolStripMenuItem;
    }
}