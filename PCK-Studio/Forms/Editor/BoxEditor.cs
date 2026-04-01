using OpenTK;
using PckStudio.Core.Skin;
using PckStudio.Properties;
using System;
using System.Windows.Forms;

namespace PckStudio.Forms.Editor
{
	public partial class BoxEditor : MetroFramework.Forms.MetroForm
	{
		private SkinBOX result;
		public SkinBOX Result => result;

        public BoxEditor(string formattedBoxString, int xmlVersion)
			: this(SkinBOX.FromString(formattedBoxString), xmlVersion)
		{
		}

		public BoxEditor(SkinBOX box, int xmlVersion)
		{
			InitializeComponent();
            boxEditorControl1.SetBOXVersion(xmlVersion);
            boxEditorControl1.SetBOX(box);
        }

		private void saveButton_Click(object sender, EventArgs e)
		{
			result = boxEditorControl1.GetBOX();
			DialogResult = DialogResult.OK;
		}

        private void BoxEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (Settings.Default.AutoSaveChanges)
			{
				saveButton_Click(sender, EventArgs.Empty);
			}
        }
    }
}
