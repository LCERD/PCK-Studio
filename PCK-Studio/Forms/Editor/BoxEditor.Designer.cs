namespace PckStudio.Forms.Editor
{
	partial class BoxEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoxEditor));
            this.closeButton = new MetroFramework.Controls.MetroButton();
            this.toolTip = new MetroFramework.Components.MetroToolTip();
            this.boxEditorControl1 = new PckStudio.Controls.BoxEditorControl();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(207, 187);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(126, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Save";
            this.closeButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.closeButton.UseSelectable = true;
            this.closeButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolTip
            // 
            this.toolTip.StripAmpersands = true;
            this.toolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.toolTip.StyleManager = null;
            this.toolTip.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // boxEditorControl1
            // 
            this.boxEditorControl1.BackColor = System.Drawing.Color.Transparent;
            this.boxEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.boxEditorControl1.Name = "boxEditorControl1";
            this.boxEditorControl1.Size = new System.Drawing.Size(540, 220);
            this.boxEditorControl1.TabIndex = 2;
            // 
            // BoxEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 220);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.boxEditorControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 554);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 220);
            this.Name = "BoxEditor";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "BOX Editor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BoxEditor_FormClosing);
            this.ResumeLayout(false);

		}

		#endregion
		private MetroFramework.Controls.MetroButton closeButton;
		private MetroFramework.Components.MetroToolTip toolTip;
        private Controls.BoxEditorControl boxEditorControl1;
    }
}