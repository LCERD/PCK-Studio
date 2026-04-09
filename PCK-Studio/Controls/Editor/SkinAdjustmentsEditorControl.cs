using ICSharpCode.SharpZipLib.Zip;
using MetroFramework.Properties;
using Newtonsoft.Json.Linq;
using PckStudio.Core.Skin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static DiscordRPC.User;
using static System.Windows.Forms.AxHost;
using res = PckStudio.Properties.Resources;

namespace PckStudio.Controls
{
    public partial class SkinAdjustmentsEditorControl : UserControl
    {
        public event EventHandler AdjustmentsChanged;

        private SkinANIM _anim;
        private SkinGameFlags _gameFlags;

        private List<PictureButtonControl> _baseButtons = new List<PictureButtonControl>();
        private List<PictureButtonControl> _armorButtons = new List<PictureButtonControl>();

        public SkinAdjustmentsEditorControl()
        {
            InitializeComponent();

            _baseButtons.Add(headButtonControl);
            _baseButtons.Add(torsoButtonControl);
            _baseButtons.Add(rightArmButtonControl);
            _baseButtons.Add(leftArmButtonControl);
            _baseButtons.Add(rightLegButtonControl);
            _baseButtons.Add(leftLegButtonControl);

            _armorButtons.Add(headArmorButtonControl);
            _armorButtons.Add(chestButtonControl);
            _armorButtons.Add(rightShoulderButtonControl);
            _armorButtons.Add(leftShoulderButtonControl);
            _armorButtons.Add(rightLeggingButtonControl);
            _armorButtons.Add(leftLeggingButtonControl);
        }

        private void ProcessArmorLinkage(PictureButtonControl baseBtn)
        {
            PictureButtonControl armorButton = _armorButtons[_baseButtons.IndexOf(baseBtn)];
            SkinAnimFlag armorFlag = (SkinAnimFlag)armorButton.Tag;

            bool state = baseBtn.GetValue();
            bool armorFlagValue = _anim.GetFlag(armorFlag);

            armorButton.ForceShown = !state;

            // if flag is already set, do not update the display of the button
            if (!armorFlagValue)
            {
                armorButton.SetState(state);
            }
        }

        public void SetSkin(Skin skin)
        {
            _anim = skin.Anim;
            _gameFlags = skin.GameFlags;

            SkinGameFlagsFlag unfairSkinFlag = SkinGameFlagsFlag.UNFAIR_BATTLE_SKIN;

            // handle the unfair flag separate from skin type
            unfairCheckbox.Checked = _gameFlags.GetFlag(unfairSkinFlag);

            // remove the unfairSkinFlag because we just want to test skin types now
            SkinGameFlags skinTypeFlags = _gameFlags.SetFlag(unfairSkinFlag, false);

            if (skinTypeFlags == SkinGameFlags.Empty)
            {
                skinTypeComboBox.SelectedIndex = 0;
            }
            else if (skinTypeFlags == SkinGameFlags.CreatureSkin)
            {
                skinTypeComboBox.SelectedIndex = 1;
            }
            else if (skinTypeFlags == SkinGameFlags.HumanSkin)
            {
                skinTypeComboBox.SelectedIndex = 2;
            }
            else if (skinTypeFlags == SkinGameFlags.FemaleHumanSkin)
            {
                skinTypeComboBox.SelectedIndex = 3;
            }
            else if (skinTypeFlags == SkinGameFlags.MaleHumanSkin)
            {
                skinTypeComboBox.SelectedIndex = 4;
            }
            else if (skinTypeFlags == SkinGameFlags.RobotSkin)
            {
                skinTypeComboBox.SelectedIndex = 5;
            }
            else
            {
                skinTypeComboBox.SelectedIndex = 6; // CUSTOM

                femaleCheckbox.Checked = _gameFlags.GetFlag(SkinGameFlagsFlag.FEMALE_SKIN);
                maleCheckbox.Checked = _gameFlags.GetFlag(SkinGameFlagsFlag.MALE_SKIN);
                humanCheckbox.Checked = _gameFlags.GetFlag(SkinGameFlagsFlag.HUMAN_SKIN);
                biologicalCheckbox.Checked = _gameFlags.GetFlag(SkinGameFlagsFlag.BIOLOGICAL_SKIN);
            }

            hideAllArmorCheckBox.Checked = _anim.GetFlag(SkinAnimFlag.ALL_ARMOR_DISABLED);
            disableBobbingCheckBox.Checked = _anim.GetFlag(SkinAnimFlag.NO_BOBBING_OVERRIDE);
            dinnerboneCheckbox.Checked = _anim.GetFlag(SkinAnimFlag.DINNERBONE);
            reverseCrouchCheckbox.Checked = _anim.GetFlag(SkinAnimFlag.DO_BACKWARDS_CROUCH);
            forceSkinEffectsCheckbox.Checked = _anim.GetFlag(SkinAnimFlag.CUSTOM_ANIMATION_OVERRIDE);
            sitIdleCheckbox.Checked = _anim.GetFlag(SkinAnimFlag.SIT_IDLE_ANIMATION);
            headButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.HEAD_DISABLED));
            torsoButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.TORSO_DISABLED));
            rightArmButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.RIGHT_ARM_DISABLED));
            leftArmButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.LEFT_ARM_DISABLED));
            rightLegButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.RIGHT_LEG_DISABLED));
            leftLegButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.LEFT_LEG_DISABLED));

            hatButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.HEADWEAR_DISABLED));
            jacketButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.JACKET_DISABLED));
            rightSleeveButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.RIGHT_SLEEVE_DISABLED));
            leftSleeveButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.LEFT_SLEEVE_DISABLED));
            rightPantsLegButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.RIGHT_PANTS_DISABLED));
            leftPantsLegButtonControl.SetState(_anim.GetFlag(SkinAnimFlag.LEFT_PANTS_DISABLED));

            foreach (PictureButtonControl baseBtn in _baseButtons)
            {
                ProcessArmorLinkage(baseBtn);
            }

            if (_anim.GetFlag(SkinAnimFlag.SLIM_MODEL))
            {
                modelComboBox.SelectedIndex = 2;
            }
            else if (_anim.GetFlag(SkinAnimFlag.MODERN_WIDE_MODEL))
            {
                modelComboBox.SelectedIndex = 1;
            }
            else
            {
                modelComboBox.SelectedIndex = 0;
            }

            if (_anim.GetFlag(SkinAnimFlag.STATIC_ARMS))
            {
                armAnimationComboBox.SelectedIndex = 1;
            }
            else if (_anim.GetFlag(SkinAnimFlag.ZOMBIE_ARMS))
            {
                armAnimationComboBox.SelectedIndex = 2;
            }
            else if (_anim.GetFlag(SkinAnimFlag.STATIC_ARMS))
            {
                armAnimationComboBox.SelectedIndex = 3;
            }
            else if (_anim.GetFlag(SkinAnimFlag.STATUE_OF_LIBERTY))
            {
                armAnimationComboBox.SelectedIndex = 4;
            }
            else
            {
                armAnimationComboBox.SelectedIndex = 0;
            }

            if (_anim.GetFlag(SkinAnimFlag.STATIC_LEGS))
            {
                legAnimationComboBox.SelectedIndex = 1;
            }
            else if (_anim.GetFlag(SkinAnimFlag.SYNCED_LEGS))
            {
                legAnimationComboBox.SelectedIndex = 2;
            }
            else
            {
                legAnimationComboBox.SelectedIndex = 0;
            }

        }

        public SkinANIM GetAnim()
        {
            return _anim;
        }

        public SkinGameFlags GetGameFlags()
        {
            return _gameFlags;
        }

        private void skinTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCustom = skinTypeComboBox.SelectedIndex == 6;
            bool isRobot = skinTypeComboBox.SelectedIndex == 5;
            bool isCreature = skinTypeComboBox.SelectedIndex == 1;
            bool isHuman = skinTypeComboBox.SelectedIndex > 1 && !isRobot;

            // disable user interactivity with checkboxes if an archetype is set
            femaleCheckbox.Enabled = maleCheckbox.Enabled = humanCheckbox.Enabled = biologicalCheckbox.Enabled = isCustom;

            if (isCustom)
                return; // don't alter any of the checks if selecting "Custom"

            // this is only ever off when not a robot
            biologicalCheckbox.Checked = !isRobot && skinTypeComboBox.SelectedIndex != 0;

            // robots have all 3 flags enabled
            // creatures have both gender flags enabled
            humanCheckbox.Checked = isHuman || isRobot;
            femaleCheckbox.Checked = isCreature || isRobot || skinTypeComboBox.SelectedIndex == 3;
            maleCheckbox.Checked = isCreature || isRobot || skinTypeComboBox.SelectedIndex == 4;

            HandleAdjustmentsChanged(sender, e);
        }

        private void animCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            SkinAnimFlag flag = (SkinAnimFlag)checkBox.Tag;

            Console.WriteLine(flag);

            bool state = checkBox.Checked;

            if (flag == SkinAnimFlag.ALL_ARMOR_DISABLED)
            {
                headArmorButtonControl.ForceHidden = state;
                chestButtonControl.ForceHidden = state;
                rightShoulderButtonControl.ForceHidden = state;
                leftShoulderButtonControl.ForceHidden = state;
                rightLeggingButtonControl.ForceHidden = state;
                leftLeggingButtonControl.ForceHidden = state;
                RefreshControls();
            }

            _anim = _anim.SetFlag(flag, state);
            HandleAdjustmentsChanged(sender, e);
        }

        private void gamesFlagCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            _gameFlags = _gameFlags.SetFlag((SkinGameFlagsFlag)checkBox.Tag, checkBox.Checked);
            HandleAdjustmentsChanged(sender, e);
        }

        private void armAnimationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            // default arm animation; no special flags
            _anim = _anim.SetFlag(SkinAnimFlag.STATIC_ARMS, false).SetFlag(SkinAnimFlag.ZOMBIE_ARMS, false).SetFlag(SkinAnimFlag.SYNCED_ARMS, false).SetFlag(SkinAnimFlag.STATUE_OF_LIBERTY, false);

            if (comboBox.SelectedIndex == 1)
            {
                _anim = _anim.SetFlag(SkinAnimFlag.STATIC_ARMS, true);
            }
            else if (comboBox.SelectedIndex == 2)
            {
                _anim = _anim.SetFlag(SkinAnimFlag.ZOMBIE_ARMS, true);
            }
            else if (comboBox.SelectedIndex == 3)
            {
                _anim = _anim.SetFlag(SkinAnimFlag.SYNCED_ARMS, true);
            }
            else if (comboBox.SelectedIndex == 4)
            {
                _anim = _anim.SetFlag(SkinAnimFlag.STATUE_OF_LIBERTY, true);
            }

            HandleAdjustmentsChanged(sender, e);
        }

        private void legAnimationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            // default arm animation; no special flags
            _anim = _anim.SetFlag(SkinAnimFlag.STATIC_LEGS, false).SetFlag(SkinAnimFlag.SYNCED_LEGS, false);

            if (comboBox.SelectedIndex == 1)
            {
                _anim = _anim.SetFlag(SkinAnimFlag.STATIC_LEGS, true);
            }
            else if (comboBox.SelectedIndex == 2)
            {
                _anim = _anim.SetFlag(SkinAnimFlag.SYNCED_LEGS, true);
            }

            HandleAdjustmentsChanged(sender, e);
        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            bool isModernWide = comboBox.SelectedIndex == 1;

            // using "res" as an alias for Properties.Resoureces for the sake of code legibility - May

            if (comboBox.SelectedIndex == 2) // Slim gets priority
            {
                _anim = _anim.SetFlag(SkinAnimFlag.MODERN_WIDE_MODEL, false).SetFlag(SkinAnimFlag.SLIM_MODEL, true);

                jacketButtonControl.ForceHidden = false;
                leftSleeveButtonControl.ForceHidden = false;
                leftPantsLegButtonControl.ForceHidden = false;
                rightSleeveButtonControl.ForceHidden = false;
                rightPantsLegButtonControl.ForceHidden = false;

                headButtonControl.Image = hatButtonControl.Image = res.skinAdjustments_slim_head;
                torsoButtonControl.Image = jacketButtonControl.Image = res.skinAdjustments_slim_body;
                rightArmButtonControl.Image = rightSleeveButtonControl.Image = res.skinAdjustments_slim_right_arm;
                leftArmButtonControl.Image = leftSleeveButtonControl.Image = res.skinAdjustments_slim_left_arm;
                rightLegButtonControl.Image = rightPantsLegButtonControl.Image = res.skinAdjustments_slim_right_leg;
                leftLegButtonControl.Image = leftPantsLegButtonControl.Image = res.skinAdjustments_slim_left_leg;

                // slim arm proportions
                rightArmButtonControl.Width = leftArmButtonControl.Width = rightSleeveButtonControl.Width = leftSleeveButtonControl.Width = 28;
                // use armor panel position to offset properly for slim model
                rightArmButtonControl.Left = rightSleeveButtonControl.Left = rightShoulderButtonControl.Left + 4;
            }
            else
            {
                _anim = _anim.SetFlag(SkinAnimFlag.MODERN_WIDE_MODEL, isModernWide).SetFlag(SkinAnimFlag.SLIM_MODEL, false);

                jacketButtonControl.ForceHidden = !isModernWide;
                leftSleeveButtonControl.ForceHidden = !isModernWide;
                leftPantsLegButtonControl.ForceHidden = !isModernWide;
                rightSleeveButtonControl.ForceHidden = !isModernWide;
                rightPantsLegButtonControl.ForceHidden = !isModernWide;

                // display old steve head to symbolize classic java format skins and updated steve head to symbolize modern versions
                headButtonControl.Image = hatButtonControl.Image = isModernWide ? res.skinAdjustments_wide_head : res.skinAdjustments_classic_head;

                torsoButtonControl.Image = jacketButtonControl.Image = res.skinAdjustments_wide_body;

                // right and left parts are all swapped because the sprites are named incorrectly lol
                // although it is technically correct as it is the image for the opposite box in the actual interface. :3
                rightArmButtonControl.Image = rightSleeveButtonControl.Image = res.skinAdjustments_wide_left_arm;
                leftArmButtonControl.Image = leftSleeveButtonControl.Image = res.skinAdjustments_wide_right_arm;
                rightLegButtonControl.Image = rightPantsLegButtonControl.Image = res.skinAdjustments_wide_legs;
                leftLegButtonControl.Image = leftPantsLegButtonControl.Image = res.skinAdjustments_wide_legs;

                // wide arm proportions
                rightArmButtonControl.Width = leftArmButtonControl.Width = rightSleeveButtonControl.Width = leftSleeveButtonControl.Width = 32;
                // use armor panel position to position back in case we were using slim model before
                rightArmButtonControl.Left = rightSleeveButtonControl.Left = rightShoulderButtonControl.Left;
            }

            HandleAdjustmentsChanged(sender, e);
        }

        private void pictureButton_Click(object sender, EventArgs e)
        {
            PictureButtonControl btn = (PictureButtonControl)sender;

            bool state = btn.state == PictureButtonControl.DisplayState.Set;
            SkinAnimFlag flag = (SkinAnimFlag)btn.Tag;

            // do not update display of armor buttons if forcefully rendered and the base parts aren't disabled. There's no value for this.
            // however, do allow armor buttons that are forcefully hidden (by disable all armor flag) to be enabled as there is a suitable value in the mask for this; even if it doesn't work in game -May
            if (!btn.ForceShown || btn.ForceHidden)
            {
                btn.state = !state ? PictureButtonControl.DisplayState.Set : PictureButtonControl.DisplayState.Default;

                _anim = _anim.SetFlag(flag, _armorButtons.Contains(btn) ? state : !state); // armor button states are inverted
            }

            if(_baseButtons.Contains(btn))
                ProcessArmorLinkage(btn);

            HandleAdjustmentsChanged(sender, e);

            RefreshControls();
        }

        private void RefreshControls()
        {
            SkinPanel.Refresh();
            OverlayPanel.Refresh();
            ArmorPanel.Refresh();
        }

        private void HandleAdjustmentsChanged(object sender, EventArgs e)
        {
            animMaskLabel.Text = _anim.ToString();
            gameFlagsMaskLabel.Text = _gameFlags.ToString();
            OnAdjustmentsChanged(EventArgs.Empty);
        }

        protected virtual void OnAdjustmentsChanged(EventArgs e)
        {
            EventHandler handler = this.AdjustmentsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
