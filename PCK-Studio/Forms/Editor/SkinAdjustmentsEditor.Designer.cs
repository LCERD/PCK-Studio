namespace PckStudio.Forms.Editor
{
    partial class SkinAdjustmentsEditor
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
            this.skinAdjustmentsEditorControl1 = new PckStudio.Controls.SkinAdjustmentsEditorControl();
            this.saveButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // skinAdjustmentsEditorControl1
            // 
            this.skinAdjustmentsEditorControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.skinAdjustmentsEditorControl1.Location = new System.Drawing.Point(20, 58);
            this.skinAdjustmentsEditorControl1.Name = "skinAdjustmentsEditorControl1";
            this.skinAdjustmentsEditorControl1.Size = new System.Drawing.Size(680, 512);
            this.skinAdjustmentsEditorControl1.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(290, 529);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(141, 37);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SkinAdjustmentsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 578);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.skinAdjustmentsEditorControl1);
            this.MinimumSize = new System.Drawing.Size(720, 578);
            this.Name = "SkinAdjustmentsEditor";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "SkinAdjustmentsEditor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.LemonChiffon;
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SkinAdjustmentsEditorControl skinAdjustmentsEditorControl1;
        private MetroFramework.Controls.MetroButton saveButton;
    }
}