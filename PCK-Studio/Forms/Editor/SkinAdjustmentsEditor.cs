using MetroFramework.Forms;
using PckStudio.Controls;
using PckStudio.Core.Skin;
using PckStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PckStudio.Forms.Editor
{
    public partial class SkinAdjustmentsEditor : MetroForm
    {
        public SkinANIM anim = SkinANIM.Empty;
        public SkinGameFlags gameFlags = SkinGameFlags.Empty;

        public SkinAdjustmentsEditor(Skin skin)
        {
            InitializeComponent();
            skinAdjustmentsEditorControl1.SetSkin(skin);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            anim = skinAdjustmentsEditorControl1.GetAnim();
            gameFlags = skinAdjustmentsEditorControl1.GetGameFlags();
            DialogResult = DialogResult.OK;
        }
    }
}
