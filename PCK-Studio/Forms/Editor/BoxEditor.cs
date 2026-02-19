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

            if (string.IsNullOrEmpty(box.Type) || !parentComboBox.Items.Contains(box.Type))
            {
                throw new Exception("Failed to parse BOX value");
            }

            closeButton.Visible = !Settings.Default.AutoSaveChanges;

            inflationUpDown.Enabled = xmlVersion == 3;

			parentComboBox.SelectedItem = parentComboBox.Items[parentComboBox.Items.IndexOf(box.Type)];
			PosXUpDown.Value = (decimal)box.Pos.X;
			PosYUpDown.Value = (decimal)box.Pos.Y;
			PosZUpDown.Value = (decimal)box.Pos.Z;
			SizeXUpDown.Value = (decimal)box.Size.X;
			SizeYUpDown.Value = (decimal)box.Size.Y;
			SizeZUpDown.Value = (decimal)box.Size.Z;
			uvXUpDown.Value = (decimal)box.UV.X;
			uvYUpDown.Value = (decimal)box.UV.Y;
            helmetCheckBox.Checked = (box.ArmorMaskFlags & 1) != 0;
            chestplateCheckBox.Checked = (box.ArmorMaskFlags & 2) != 0;
            leggingsCheckBox.Checked = (box.ArmorMaskFlags & 4) != 0;
            bootsCheckBox.Checked = (box.ArmorMaskFlags & 8) != 0;
            mirrorCheckBox.Checked = box.Mirror;
			inflationUpDown.Value = (decimal)box.Scale;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
            int mask = 0;

            if (helmetCheckBox.Checked) mask |= 1;
            if (chestplateCheckBox.Checked) mask |= 2;
            if (leggingsCheckBox.Checked) mask |= 4;
            if (bootsCheckBox.Checked) mask |= 8;

            result = SkinBOX.FromString(
				$"{parentComboBox.SelectedItem} " +
				$"{PosXUpDown.Value} {PosYUpDown.Value} {PosZUpDown.Value} " +
				$"{SizeXUpDown.Value} {SizeYUpDown.Value} {SizeZUpDown.Value} " +
				$"{uvXUpDown.Value} {uvYUpDown.Value} " +
				$"{mask} " +
				$"{Convert.ToInt32(mirrorCheckBox.Checked)} " +
				$"{inflationUpDown.Value}");
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
