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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PckStudio.Controls
{
    internal partial class BoxEditorControl : UserControl
    {
        public event EventHandler BoxChanged;

        private SkinBOX result;
        public int boxVersion = 0;

        private bool CancelBoxChanged = false;

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
        }

        public bool ShowScalingSupportPrompt()
        {
            bool pm = MessageBox.Show(this.ParentForm, $"This pack does not support custom box scaling but this skin uses the parameter. Box scaling was added in Xbox 360 Title Update 69, PlayStation versions 1.76, and Wii U version Patch 43. Xbox One and Switch Editions do not have support for this feature. This value can affect how other skins in this pack appear. This feature can be changed at any time via the \"PCK\"->\"Set BOX Version\" menu button at the top of the program. Would you like to enable it?", "Unlock box scaling support for this pack?", MessageBoxButtons.YesNo) == DialogResult.Yes;
            if (pm) boxVersion = 3;
            return pm;
        }

        public void SetBOX(SkinBOX box)
        {
            if (string.IsNullOrEmpty(box.Type) || !parentComboBox.Items.Contains(box.Type))
            {
                throw new Exception("Failed to parse BOX value");
            }

            // cancel box changed so the event doesn't trigger for this function
            CancelBoxChanged = true;
            parentComboBox.SelectedItem = parentComboBox.Items[parentComboBox.Items.IndexOf(box.Type)];
            PosXUpDown.Value = (decimal)box.Pos.X;
            PosYUpDown.Value = (decimal)box.Pos.Y;
            PosZUpDown.Value = (decimal)box.Pos.Z;
            SizeXUpDown.Value = (decimal)box.Size.X;
            SizeYUpDown.Value = (decimal)box.Size.Y;
            SizeZUpDown.Value = (decimal)box.Size.Z;
            uvXUpDown.Value = (decimal)box.UV.X;
            uvYUpDown.Value = (decimal)box.UV.Y;
            helmetCheckBox.Checked = box.ArmorMaskFlags.GetFlag(SkinArmorFlagsFlag.HELMET);
            chestplateCheckBox.Checked = box.ArmorMaskFlags.GetFlag(SkinArmorFlagsFlag.CHESTPLATE);
            leggingsCheckBox.Checked = box.ArmorMaskFlags.GetFlag(SkinArmorFlagsFlag.LEGGINGS);
            bootsCheckBox.Checked = box.ArmorMaskFlags.GetFlag(SkinArmorFlagsFlag.BOOTS);
            mirrorCheckBox.Checked = box.Mirror;
            // if the XMLVersion doesn't support scaling, prompt user to change the XMLVersion - May
            decimal scale = (decimal)box.Scale;
            inflationUpDown.Value = 
                boxVersion == 3 ? scale : 
                    scale != 0 ? ShowScalingSupportPrompt() ? scale : 0 : 0;
            CancelBoxChanged = false;
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
            if(!CancelBoxChanged)
                OnBoxChanged(EventArgs.Empty);
        }

        protected virtual void OnBoxChanged(EventArgs e)
        {
            if (!CancelBoxChanged)
            {
                EventHandler handler = this.BoxChanged;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }
    }
}
