using OpenTK;
using PckStudio.Core.Skin;
using PckStudio.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PckStudio.Controls
{
    internal partial class BoxEditorControl : UserControl
    {
        public event EventHandler BoxChanged;

        private SkinBOX result;
        private int boxVersion = 0;

        public BoxEditorControl(SkinBOX box, int xmlVersion)
            : this(xmlVersion)
        {
            SetBOX(box);
        }

        public BoxEditorControl()
            :this(0)
        {

        }

        public BoxEditorControl(int xmlVersion = 0)
        {
            InitializeComponent();
            SetBOXVersion(xmlVersion);
            parentComboBox.SelectedIndexChanged += this.HandleBoxChanged;
            PosXUpDown.ValueChanged += this.HandleBoxChanged;
            PosYUpDown.ValueChanged += this.HandleBoxChanged;
            PosZUpDown.ValueChanged += this.HandleBoxChanged;
            SizeXUpDown.ValueChanged += this.HandleBoxChanged;
            SizeYUpDown.ValueChanged += this.HandleBoxChanged;
            SizeZUpDown.ValueChanged += this.HandleBoxChanged;
            uvXUpDown.ValueChanged += this.HandleBoxChanged;
            uvYUpDown.ValueChanged += this.HandleBoxChanged;
            helmetCheckBox.CheckedChanged += this.HandleBoxChanged;
            chestplateCheckBox.CheckedChanged += this.HandleBoxChanged;
            leggingsCheckBox.CheckedChanged += this.HandleBoxChanged;
            bootsCheckBox.CheckedChanged += this.HandleBoxChanged;
            mirrorCheckBox.CheckedChanged += this.HandleBoxChanged;
            inflationUpDown.ValueChanged += this.HandleBoxChanged;
        }

        public void SetBOXVersion(int xmlVersion)
        {
            boxVersion = xmlVersion;
            Debug.WriteLine(xmlVersion);
            inflationUpDown.Enabled = boxVersion == 3;
        }

        public void SetBOX(SkinBOX box)
        {
            if (string.IsNullOrEmpty(box.Type) || !parentComboBox.Items.Contains(box.Type))
            {
                throw new Exception("Failed to parse BOX value");
            }

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

        public SkinBOX GetBOX()
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

            return result;
        }

        private void HandleBoxChanged(object sender, EventArgs e)
        {
            // we'll explain this in a minute
            this.OnBoxChanged(EventArgs.Empty);
        }

        protected virtual void OnBoxChanged(EventArgs e)
        {
            EventHandler handler = this.BoxChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
