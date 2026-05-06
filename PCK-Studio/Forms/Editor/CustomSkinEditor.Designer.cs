namespace PckStudio.Forms.Editor
{
    partial class CustomSkinEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSkinEditor));
            this.importTextureButton = new MetroFramework.Controls.MetroButton();
            this.exportTextureButton = new MetroFramework.Controls.MetroButton();
            this.skinPartTabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateUvTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDone = new MetroFramework.Controls.MetroButton();
            this.importSkinButton = new MetroFramework.Controls.MetroButton();
            this.exportSkinButton = new MetroFramework.Controls.MetroButton();
            this.outlineColorButton = new MetroFramework.Controls.MetroButton();
            this.generateTextureCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.showArmorCheckbox = new MetroFramework.Controls.MetroCheckBox();
            this.skinPartListBox = new System.Windows.Forms.ListBox();
            this.captureScreenshotButton = new MetroFramework.Controls.MetroButton();
            this.showToolsCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.skinNameLabel = new MetroFramework.Controls.MetroLabel();
            this.parameterTabControl = new MetroFramework.Controls.MetroTabControl();
            this.skinPartsTabPage = new System.Windows.Forms.TabPage();
            this.skinOffsetsTabPage = new System.Windows.Forms.TabPage();
            this.offsetListBox = new System.Windows.Forms.ListBox();
            this.offsetTabContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.addOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderer3D1 = new PckStudio.Rendering.SkinRenderer();
            this.uvPictureBox = new PckStudio.ToolboxItems.InterpolationPictureBox();
            this.centerSelectionCheckbox = new MetroFramework.Controls.MetroCheckBox();
            this.textureSizeLabel = new System.Windows.Forms.Label();
            this.renderSettingsButton = new MetroFramework.Controls.MetroButton();
            this.exportTemplateButton = new MetroFramework.Controls.MetroButton();
            this.boxEditorControl1 = new PckStudio.Controls.BoxEditorControl();
            this.skinAdjustmentsEditorControl1 = new PckStudio.Controls.SkinAdjustmentsEditorControl();
            this.skinPartTabContextMenu.SuspendLayout();
            this.parameterTabControl.SuspendLayout();
            this.skinPartsTabPage.SuspendLayout();
            this.skinOffsetsTabPage.SuspendLayout();
            this.offsetTabContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uvPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // importTextureButton
            // 
            this.importTextureButton.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.importTextureButton, "importTextureButton");
            this.importTextureButton.Name = "importTextureButton";
            this.importTextureButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.importTextureButton.UseSelectable = true;
            this.importTextureButton.Click += new System.EventHandler(this.importTextureButton_Click);
            // 
            // exportTextureButton
            // 
            this.exportTextureButton.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.exportTextureButton, "exportTextureButton");
            this.exportTextureButton.Name = "exportTextureButton";
            this.exportTextureButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.exportTextureButton.UseSelectable = true;
            this.exportTextureButton.Click += new System.EventHandler(this.exportTextureButton_Click);
            // 
            // skinPartTabContextMenu
            // 
            this.skinPartTabContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinPartTabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.generateUvTextureToolStripMenuItem});
            this.skinPartTabContextMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.skinPartTabContextMenu, "skinPartTabContextMenu");
            // 
            // createToolStripMenuItem
            // 
            resources.ApplyResources(this.createToolStripMenuItem, "createToolStripMenuItem");
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            resources.ApplyResources(this.cloneToolStripMenuItem, "cloneToolStripMenuItem");
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // generateUvTextureToolStripMenuItem
            // 
            resources.ApplyResources(this.generateUvTextureToolStripMenuItem, "generateUvTextureToolStripMenuItem");
            this.generateUvTextureToolStripMenuItem.Name = "generateUvTextureToolStripMenuItem";
            this.generateUvTextureToolStripMenuItem.Click += new System.EventHandler(this.generateUvTextureToolStripMenuItem_Click);
            // 
            // buttonDone
            // 
            resources.ApplyResources(this.buttonDone, "buttonDone");
            this.buttonDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonDone.ForeColor = System.Drawing.Color.White;
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonDone.UseSelectable = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // importSkinButton
            // 
            this.importSkinButton.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.importSkinButton, "importSkinButton");
            this.importSkinButton.Name = "importSkinButton";
            this.importSkinButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.importSkinButton.UseSelectable = true;
            this.importSkinButton.Click += new System.EventHandler(this.importSkinButton_Click);
            // 
            // exportSkinButton
            // 
            this.exportSkinButton.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.exportSkinButton, "exportSkinButton");
            this.exportSkinButton.Name = "exportSkinButton";
            this.exportSkinButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.exportSkinButton.UseSelectable = true;
            this.exportSkinButton.Click += new System.EventHandler(this.exportSkinButton_Click);
            // 
            // outlineColorButton
            // 
            this.outlineColorButton.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.outlineColorButton, "outlineColorButton");
            this.outlineColorButton.Name = "outlineColorButton";
            this.outlineColorButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.outlineColorButton.UseSelectable = true;
            this.outlineColorButton.Click += new System.EventHandler(this.outlineColorButton_Click);
            // 
            // generateTextureCheckBox
            // 
            resources.ApplyResources(this.generateTextureCheckBox, "generateTextureCheckBox");
            this.generateTextureCheckBox.Name = "generateTextureCheckBox";
            this.generateTextureCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.generateTextureCheckBox.UseSelectable = true;
            // 
            // showArmorCheckbox
            // 
            resources.ApplyResources(this.showArmorCheckbox, "showArmorCheckbox");
            this.showArmorCheckbox.Name = "showArmorCheckbox";
            this.showArmorCheckbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.showArmorCheckbox.UseSelectable = true;
            this.showArmorCheckbox.CheckedChanged += new System.EventHandler(this.showArmorCheckbox_CheckedChanged);
            // 
            // skinPartListBox
            // 
            this.skinPartListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinPartListBox.ContextMenuStrip = this.skinPartTabContextMenu;
            resources.ApplyResources(this.skinPartListBox, "skinPartListBox");
            this.skinPartListBox.FormattingEnabled = true;
            this.skinPartListBox.Name = "skinPartListBox";
            this.skinPartListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.skinPartListBox.Tag = "";
            this.skinPartListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.skinPartListBox_MouseClick);
            this.skinPartListBox.SelectedIndexChanged += new System.EventHandler(this.skinPartListBox_SelectedIndexChanged);
            this.skinPartListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.skinPartListBox_KeyUp);
            // 
            // captureScreenshotButton
            // 
            this.captureScreenshotButton.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.captureScreenshotButton, "captureScreenshotButton");
            this.captureScreenshotButton.Name = "captureScreenshotButton";
            this.captureScreenshotButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.captureScreenshotButton.UseSelectable = true;
            this.captureScreenshotButton.Click += new System.EventHandler(this.captureScreenshotButton_Click);
            // 
            // showToolsCheckBox
            // 
            resources.ApplyResources(this.showToolsCheckBox, "showToolsCheckBox");
            this.showToolsCheckBox.Name = "showToolsCheckBox";
            this.showToolsCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.showToolsCheckBox.UseSelectable = true;
            this.showToolsCheckBox.CheckedChanged += new System.EventHandler(this.showToolsCheckBox_CheckedChanged);
            // 
            // skinNameLabel
            // 
            resources.ApplyResources(this.skinNameLabel, "skinNameLabel");
            this.skinNameLabel.Name = "skinNameLabel";
            this.skinNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // parameterTabControl
            // 
            resources.ApplyResources(this.parameterTabControl, "parameterTabControl");
            this.parameterTabControl.Controls.Add(this.skinPartsTabPage);
            this.parameterTabControl.Controls.Add(this.skinOffsetsTabPage);
            this.parameterTabControl.Multiline = true;
            this.parameterTabControl.Name = "parameterTabControl";
            this.parameterTabControl.SelectedIndex = 0;
            this.parameterTabControl.Style = MetroFramework.MetroColorStyle.Pink;
            this.parameterTabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.parameterTabControl.UseSelectable = true;
            // 
            // skinPartsTabPage
            // 
            this.skinPartsTabPage.Controls.Add(this.skinPartListBox);
            resources.ApplyResources(this.skinPartsTabPage, "skinPartsTabPage");
            this.skinPartsTabPage.Name = "skinPartsTabPage";
            // 
            // skinOffsetsTabPage
            // 
            this.skinOffsetsTabPage.Controls.Add(this.offsetListBox);
            resources.ApplyResources(this.skinOffsetsTabPage, "skinOffsetsTabPage");
            this.skinOffsetsTabPage.Name = "skinOffsetsTabPage";
            // 
            // offsetListBox
            // 
            this.offsetListBox.ContextMenuStrip = this.offsetTabContextMenu;
            resources.ApplyResources(this.offsetListBox, "offsetListBox");
            this.offsetListBox.FormattingEnabled = true;
            this.offsetListBox.Name = "offsetListBox";
            this.offsetListBox.DoubleClick += new System.EventHandler(this.offsetListBox_DoubleClick);
            // 
            // offsetTabContextMenu
            // 
            this.offsetTabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOffsetToolStripMenuItem,
            this.removeOffsetToolStripMenuItem});
            this.offsetTabContextMenu.Name = "offsetTabContextMenu";
            resources.ApplyResources(this.offsetTabContextMenu, "offsetTabContextMenu");
            this.offsetTabContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // addOffsetToolStripMenuItem
            // 
            this.addOffsetToolStripMenuItem.Name = "addOffsetToolStripMenuItem";
            resources.ApplyResources(this.addOffsetToolStripMenuItem, "addOffsetToolStripMenuItem");
            this.addOffsetToolStripMenuItem.Click += new System.EventHandler(this.addOffsetToolStripMenuItem_Click);
            // 
            // removeOffsetToolStripMenuItem
            // 
            this.removeOffsetToolStripMenuItem.Name = "removeOffsetToolStripMenuItem";
            resources.ApplyResources(this.removeOffsetToolStripMenuItem, "removeOffsetToolStripMenuItem");
            this.removeOffsetToolStripMenuItem.Click += new System.EventHandler(this.removeOffsetToolStripMenuItem_Click);
            // 
            // renderer3D1
            // 
            resources.ApplyResources(this.renderer3D1, "renderer3D1");
            this.renderer3D1.Animate = true;
            this.renderer3D1.BackColor = System.Drawing.Color.DimGray;
            this.renderer3D1.CapeTexture = null;
            this.renderer3D1.CenterOnSelect = false;
            this.renderer3D1.GuideLineColor = System.Drawing.Color.Empty;
            this.renderer3D1.HighlightlingColor = System.Drawing.Color.Aqua;
            this.renderer3D1.MouseSensetivity = 0.01F;
            this.renderer3D1.Name = "renderer3D1";
            this.renderer3D1.RefreshRate = 60;
            this.renderer3D1.RenderCape = true;
            this.renderer3D1.SelectedIndex = -1;
            this.renderer3D1.SelectedIndices = new int[] {
        -1};
            this.renderer3D1.ShowArmor = false;
            this.renderer3D1.ShowBoundingBox = false;
            this.renderer3D1.ShowGuideLines = false;
            this.renderer3D1.Texture = null;
            this.renderer3D1.VSync = true;
            this.renderer3D1.TextureChanging += new System.EventHandler<PckStudio.Rendering.TextureChangingEventArgs>(this.renderer3D1_TextureChanging);
            // 
            // uvPictureBox
            // 
            resources.ApplyResources(this.uvPictureBox, "uvPictureBox");
            this.uvPictureBox.BackgroundInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.uvPictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.uvPictureBox.Name = "uvPictureBox";
            this.uvPictureBox.TabStop = false;
            // 
            // centerSelectionCheckbox
            // 
            resources.ApplyResources(this.centerSelectionCheckbox, "centerSelectionCheckbox");
            this.centerSelectionCheckbox.Name = "centerSelectionCheckbox";
            this.centerSelectionCheckbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.centerSelectionCheckbox.UseSelectable = true;
            this.centerSelectionCheckbox.CheckedChanged += new System.EventHandler(this.centerSelectionCheckbox_CheckedChanged);
            // 
            // textureSizeLabel
            // 
            resources.ApplyResources(this.textureSizeLabel, "textureSizeLabel");
            this.textureSizeLabel.ForeColor = System.Drawing.Color.White;
            this.textureSizeLabel.Name = "textureSizeLabel";
            // 
            // renderSettingsButton
            // 
            resources.ApplyResources(this.renderSettingsButton, "renderSettingsButton");
            this.renderSettingsButton.Name = "renderSettingsButton";
            this.renderSettingsButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.renderSettingsButton.UseSelectable = true;
            this.renderSettingsButton.Click += new System.EventHandler(this.renderSettingsButton_Click);
            // 
            // exportTemplateButton
            // 
            this.exportTemplateButton.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.exportTemplateButton, "exportTemplateButton");
            this.exportTemplateButton.Name = "exportTemplateButton";
            this.exportTemplateButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.exportTemplateButton.UseSelectable = true;
            this.exportTemplateButton.Click += new System.EventHandler(this.exportTemplateButton_Click);
            // 
            // boxEditorControl1
            // 
            resources.ApplyResources(this.boxEditorControl1, "boxEditorControl1");
            this.boxEditorControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.boxEditorControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxEditorControl1.Name = "boxEditorControl1";
            this.boxEditorControl1.BoxChanged += new System.EventHandler(this.boxEditorControl1_BoxChanged);
            // 
            // skinAdjustmentsEditorControl1
            // 
            resources.ApplyResources(this.skinAdjustmentsEditorControl1, "skinAdjustmentsEditorControl1");
            this.skinAdjustmentsEditorControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.skinAdjustmentsEditorControl1.Name = "skinAdjustmentsEditorControl1";
            this.skinAdjustmentsEditorControl1.AdjustmentsChanged += new System.EventHandler(this.skinAdjustmentsEditorControl1_AdjustmentsChanged);
            // 
            // CustomSkinEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinAdjustmentsEditorControl1);
            this.Controls.Add(this.parameterTabControl);
            this.Controls.Add(this.boxEditorControl1);
            this.Controls.Add(this.exportTextureButton);
            this.Controls.Add(this.importTextureButton);
            this.Controls.Add(this.textureSizeLabel);
            this.Controls.Add(this.showToolsCheckBox);
            this.Controls.Add(this.centerSelectionCheckbox);
            this.Controls.Add(this.showArmorCheckbox);
            this.Controls.Add(this.generateTextureCheckBox);
            this.Controls.Add(this.outlineColorButton);
            this.Controls.Add(this.uvPictureBox);
            this.Controls.Add(this.exportTemplateButton);
            this.Controls.Add(this.renderSettingsButton);
            this.Controls.Add(this.skinNameLabel);
            this.Controls.Add(this.captureScreenshotButton);
            this.Controls.Add(this.renderer3D1);
            this.Controls.Add(this.exportSkinButton);
            this.Controls.Add(this.importSkinButton);
            this.Controls.Add(this.buttonDone);
            this.Name = "CustomSkinEditor";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomSkinEditor_FormClosing);
            this.skinPartTabContextMenu.ResumeLayout(false);
            this.parameterTabControl.ResumeLayout(false);
            this.skinPartsTabPage.ResumeLayout(false);
            this.skinOffsetsTabPage.ResumeLayout(false);
            this.offsetTabContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uvPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip skinPartTabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateUvTextureToolStripMenuItem;
        private MetroFramework.Controls.MetroButton buttonDone;
        private MetroFramework.Controls.MetroButton outlineColorButton;
        private MetroFramework.Controls.MetroButton exportSkinButton;
        private MetroFramework.Controls.MetroButton importSkinButton;
        private PckStudio.ToolboxItems.InterpolationPictureBox uvPictureBox;
        private MetroFramework.Controls.MetroButton importTextureButton;
        private MetroFramework.Controls.MetroButton exportTextureButton;
        private MetroFramework.Controls.MetroCheckBox generateTextureCheckBox;
        private MetroFramework.Controls.MetroCheckBox showArmorCheckbox;
        private Rendering.SkinRenderer renderer3D1;
        private System.Windows.Forms.ListBox skinPartListBox;
        private MetroFramework.Controls.MetroButton captureScreenshotButton;
        private MetroFramework.Controls.MetroCheckBox showToolsCheckBox;
        private MetroFramework.Controls.MetroLabel skinNameLabel;
        private MetroFramework.Controls.MetroTabControl parameterTabControl;
        private System.Windows.Forms.TabPage skinPartsTabPage;
        private System.Windows.Forms.TabPage skinOffsetsTabPage;
        private System.Windows.Forms.ListBox offsetListBox;
        private MetroFramework.Controls.MetroContextMenu offsetTabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeOffsetToolStripMenuItem;
        private MetroFramework.Controls.MetroCheckBox centerSelectionCheckbox;
        private System.Windows.Forms.Label textureSizeLabel;
        private MetroFramework.Controls.MetroButton renderSettingsButton;
        private MetroFramework.Controls.MetroButton exportTemplateButton;
        private Controls.BoxEditorControl boxEditorControl1;
        private Controls.SkinAdjustmentsEditorControl skinAdjustmentsEditorControl1;
    }
}