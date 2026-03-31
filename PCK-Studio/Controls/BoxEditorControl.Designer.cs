namespace PckStudio.Controls
{
    partial class BoxEditorControl
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
            this.parentLabel = new MetroFramework.Controls.MetroLabel();
            this.positionLabel = new MetroFramework.Controls.MetroLabel();
            this.sizeLabel = new MetroFramework.Controls.MetroLabel();
            this.uvLabel = new MetroFramework.Controls.MetroLabel();
            this.inflationLabel = new MetroFramework.Controls.MetroLabel();
            this.toolTip = new MetroFramework.Components.MetroToolTip();
            this.parentComboBox = new MetroFramework.Controls.MetroComboBox();
            this.PosXUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosYUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosZUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeZUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeYUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeXUpDown = new System.Windows.Forms.NumericUpDown();
            this.uvYUpDown = new System.Windows.Forms.NumericUpDown();
            this.uvXUpDown = new System.Windows.Forms.NumericUpDown();
            this.helmetCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.mirrorCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.inflationUpDown = new System.Windows.Forms.NumericUpDown();
            this.chestplateCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.leggingsCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.bootsCheckBox = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PosXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosZUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeZUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inflationUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // parentLabel
            // 
            this.parentLabel.AutoSize = true;
            this.parentLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.parentLabel.Location = new System.Drawing.Point(47, 55);
            this.parentLabel.Name = "parentLabel";
            this.parentLabel.Size = new System.Drawing.Size(50, 25);
            this.parentLabel.TabIndex = 2;
            this.parentLabel.Text = "Type:";
            this.parentLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.positionLabel.Location = new System.Drawing.Point(22, 84);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(75, 25);
            this.positionLabel.TabIndex = 4;
            this.positionLabel.Text = "Position:";
            this.positionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.sizeLabel.Location = new System.Drawing.Point(51, 109);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(46, 25);
            this.sizeLabel.TabIndex = 22;
            this.sizeLabel.Text = "Size:";
            this.sizeLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // uvLabel
            // 
            this.uvLabel.AutoSize = true;
            this.uvLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.uvLabel.Location = new System.Drawing.Point(58, 135);
            this.uvLabel.Name = "uvLabel";
            this.uvLabel.Size = new System.Drawing.Size(39, 25);
            this.uvLabel.TabIndex = 26;
            this.uvLabel.Text = "UV:";
            this.uvLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // inflationLabel
            // 
            this.inflationLabel.AutoSize = true;
            this.inflationLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.inflationLabel.Location = new System.Drawing.Point(42, 165);
            this.inflationLabel.Name = "inflationLabel";
            this.inflationLabel.Size = new System.Drawing.Size(55, 25);
            this.inflationLabel.TabIndex = 31;
            this.inflationLabel.Text = "Scale:";
            this.inflationLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // toolTip
            // 
            this.toolTip.StripAmpersands = true;
            this.toolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.toolTip.StyleManager = null;
            this.toolTip.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // parentComboBox
            // 
            this.parentComboBox.FormattingEnabled = true;
            this.parentComboBox.ItemHeight = 23;
            this.parentComboBox.Items.AddRange(new object[] {
            "HEAD",
            "BODY",
            "ARM0",
            "ARM1",
            "LEG0",
            "LEG1",
            "HEADWEAR",
            "JACKET",
            "SLEEVE0",
            "SLEEVE1",
            "PANTS0",
            "PANTS1",
            "WAIST",
            "LEGGING0",
            "LEGGING1",
            "SOCK0",
            "SOCK1",
            "BOOT0",
            "BOOT1",
            "ARMARMOR1",
            "ARMARMOR0",
            "BODYARMOR",
            "BELT"});
            this.parentComboBox.Location = new System.Drawing.Point(103, 51);
            this.parentComboBox.Name = "parentComboBox";
            this.parentComboBox.Size = new System.Drawing.Size(163, 29);
            this.parentComboBox.TabIndex = 3;
            this.parentComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.parentComboBox.UseSelectable = true;
            // 
            // PosXUpDown
            // 
            this.PosXUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.PosXUpDown.DecimalPlaces = 3;
            this.PosXUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PosXUpDown.Location = new System.Drawing.Point(103, 86);
            this.PosXUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PosXUpDown.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.PosXUpDown.Name = "PosXUpDown";
            this.PosXUpDown.Size = new System.Drawing.Size(73, 20);
            this.PosXUpDown.TabIndex = 19;
            // 
            // PosYUpDown
            // 
            this.PosYUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.PosYUpDown.DecimalPlaces = 3;
            this.PosYUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PosYUpDown.Location = new System.Drawing.Point(182, 86);
            this.PosYUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PosYUpDown.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.PosYUpDown.Name = "PosYUpDown";
            this.PosYUpDown.Size = new System.Drawing.Size(73, 20);
            this.PosYUpDown.TabIndex = 20;
            // 
            // PosZUpDown
            // 
            this.PosZUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.PosZUpDown.DecimalPlaces = 3;
            this.PosZUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PosZUpDown.Location = new System.Drawing.Point(261, 86);
            this.PosZUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PosZUpDown.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.PosZUpDown.Name = "PosZUpDown";
            this.PosZUpDown.Size = new System.Drawing.Size(73, 20);
            this.PosZUpDown.TabIndex = 21;
            // 
            // SizeZUpDown
            // 
            this.SizeZUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SizeZUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.SizeZUpDown.Location = new System.Drawing.Point(261, 111);
            this.SizeZUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SizeZUpDown.Name = "SizeZUpDown";
            this.SizeZUpDown.Size = new System.Drawing.Size(73, 20);
            this.SizeZUpDown.TabIndex = 25;
            // 
            // SizeYUpDown
            // 
            this.SizeYUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SizeYUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.SizeYUpDown.Location = new System.Drawing.Point(182, 111);
            this.SizeYUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SizeYUpDown.Name = "SizeYUpDown";
            this.SizeYUpDown.Size = new System.Drawing.Size(73, 20);
            this.SizeYUpDown.TabIndex = 24;
            // 
            // SizeXUpDown
            // 
            this.SizeXUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SizeXUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.SizeXUpDown.Location = new System.Drawing.Point(103, 111);
            this.SizeXUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SizeXUpDown.Name = "SizeXUpDown";
            this.SizeXUpDown.Size = new System.Drawing.Size(73, 20);
            this.SizeXUpDown.TabIndex = 23;
            // 
            // uvYUpDown
            // 
            this.uvYUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.uvYUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.uvYUpDown.Location = new System.Drawing.Point(182, 137);
            this.uvYUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.uvYUpDown.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.uvYUpDown.Name = "uvYUpDown";
            this.uvYUpDown.Size = new System.Drawing.Size(73, 20);
            this.uvYUpDown.TabIndex = 28;
            // 
            // uvXUpDown
            // 
            this.uvXUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.uvXUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.uvXUpDown.Location = new System.Drawing.Point(103, 137);
            this.uvXUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.uvXUpDown.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.uvXUpDown.Name = "uvXUpDown";
            this.uvXUpDown.Size = new System.Drawing.Size(73, 20);
            this.uvXUpDown.TabIndex = 27;
            // 
            // helmetCheckBox
            // 
            this.helmetCheckBox.AutoSize = true;
            this.helmetCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.helmetCheckBox.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.helmetCheckBox.Location = new System.Drawing.Point(340, 84);
            this.helmetCheckBox.Name = "helmetCheckBox";
            this.helmetCheckBox.Size = new System.Drawing.Size(160, 25);
            this.helmetCheckBox.TabIndex = 29;
            this.helmetCheckBox.Text = "Mask with helmet";
            this.helmetCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.helmetCheckBox.UseSelectable = true;
            // 
            // mirrorCheckBox
            // 
            this.mirrorCheckBox.AutoSize = true;
            this.mirrorCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.mirrorCheckBox.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.mirrorCheckBox.Location = new System.Drawing.Point(340, 58);
            this.mirrorCheckBox.Name = "mirrorCheckBox";
            this.mirrorCheckBox.Size = new System.Drawing.Size(133, 25);
            this.mirrorCheckBox.TabIndex = 30;
            this.mirrorCheckBox.Text = "Mirror Texture";
            this.mirrorCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mirrorCheckBox.UseSelectable = true;
            // 
            // inflationUpDown
            // 
            this.inflationUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.inflationUpDown.DecimalPlaces = 3;
            this.inflationUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.inflationUpDown.Location = new System.Drawing.Point(103, 167);
            this.inflationUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.inflationUpDown.Name = "inflationUpDown";
            this.inflationUpDown.Size = new System.Drawing.Size(73, 20);
            this.inflationUpDown.TabIndex = 32;
            // 
            // chestplateCheckBox
            // 
            this.chestplateCheckBox.AutoSize = true;
            this.chestplateCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chestplateCheckBox.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.chestplateCheckBox.Location = new System.Drawing.Point(340, 109);
            this.chestplateCheckBox.Name = "chestplateCheckBox";
            this.chestplateCheckBox.Size = new System.Drawing.Size(184, 25);
            this.chestplateCheckBox.TabIndex = 33;
            this.chestplateCheckBox.Text = "Mask with chestplate";
            this.chestplateCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chestplateCheckBox.UseSelectable = true;
            // 
            // leggingsCheckBox
            // 
            this.leggingsCheckBox.AutoSize = true;
            this.leggingsCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.leggingsCheckBox.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.leggingsCheckBox.Location = new System.Drawing.Point(340, 135);
            this.leggingsCheckBox.Name = "leggingsCheckBox";
            this.leggingsCheckBox.Size = new System.Drawing.Size(172, 25);
            this.leggingsCheckBox.TabIndex = 34;
            this.leggingsCheckBox.Text = "Mask with leggings";
            this.leggingsCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.leggingsCheckBox.UseSelectable = true;
            // 
            // bootsCheckBox
            // 
            this.bootsCheckBox.AutoSize = true;
            this.bootsCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.bootsCheckBox.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.bootsCheckBox.Location = new System.Drawing.Point(340, 161);
            this.bootsCheckBox.Name = "bootsCheckBox";
            this.bootsCheckBox.Size = new System.Drawing.Size(150, 25);
            this.bootsCheckBox.TabIndex = 35;
            this.bootsCheckBox.Text = "Mask with boots";
            this.bootsCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bootsCheckBox.UseSelectable = true;
            // 
            // BoxEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.bootsCheckBox);
            this.Controls.Add(this.leggingsCheckBox);
            this.Controls.Add(this.chestplateCheckBox);
            this.Controls.Add(this.inflationUpDown);
            this.Controls.Add(this.uvYUpDown);
            this.Controls.Add(this.uvXUpDown);
            this.Controls.Add(this.SizeZUpDown);
            this.Controls.Add(this.SizeYUpDown);
            this.Controls.Add(this.SizeXUpDown);
            this.Controls.Add(this.PosZUpDown);
            this.Controls.Add(this.PosYUpDown);
            this.Controls.Add(this.PosXUpDown);
            this.Controls.Add(this.inflationLabel);
            this.Controls.Add(this.parentComboBox);
            this.Controls.Add(this.mirrorCheckBox);
            this.Controls.Add(this.helmetCheckBox);
            this.Controls.Add(this.uvLabel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.parentLabel);
            this.Name = "BoxEditorControl";
            this.Size = new System.Drawing.Size(540, 220);
            ((System.ComponentModel.ISupportInitialize)(this.PosXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosZUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeZUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inflationUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroToolTip toolTip;
        private MetroFramework.Controls.MetroComboBox parentComboBox;
        private System.Windows.Forms.NumericUpDown PosXUpDown;
        private System.Windows.Forms.NumericUpDown PosYUpDown;
        private System.Windows.Forms.NumericUpDown PosZUpDown;
        private System.Windows.Forms.NumericUpDown SizeZUpDown;
        private System.Windows.Forms.NumericUpDown SizeYUpDown;
        private System.Windows.Forms.NumericUpDown SizeXUpDown;
        private System.Windows.Forms.NumericUpDown uvYUpDown;
        private System.Windows.Forms.NumericUpDown uvXUpDown;
        private MetroFramework.Controls.MetroCheckBox helmetCheckBox;
        private MetroFramework.Controls.MetroCheckBox mirrorCheckBox;
        private System.Windows.Forms.NumericUpDown inflationUpDown;
        private MetroFramework.Controls.MetroCheckBox chestplateCheckBox;
        private MetroFramework.Controls.MetroCheckBox leggingsCheckBox;
        private MetroFramework.Controls.MetroCheckBox bootsCheckBox;
        private MetroFramework.Controls.MetroLabel parentLabel;
        private MetroFramework.Controls.MetroLabel positionLabel;
        private MetroFramework.Controls.MetroLabel sizeLabel;
        private MetroFramework.Controls.MetroLabel uvLabel;
        private MetroFramework.Controls.MetroLabel inflationLabel;
    }
}