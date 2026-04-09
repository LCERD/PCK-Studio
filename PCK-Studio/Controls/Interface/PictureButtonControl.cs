using PckStudio.Core.Skin;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace PckStudio.Controls
{
    /// <summary>
    /// Inherits from PictureBox; adds Interpolation Mode Setting
    /// </summary>
    public partial class PictureButtonControl : PictureBox
    {
        public event EventHandler StateChanged;
        public Color ShownBorderColor { get; set; }
        public DashStyle DashStyle { get; set; }
        public Color HiddenBorderColor { get; set; }
        public DashStyle SetDashStyle { get; set; }
        // show that the flag effect is forced on and cannot be changed
        public bool ForceHidden { get; set; }
        public bool ForceShown { get; set; }
        // The button being active returns a false value instead of true
        public bool Inverted { get; set; }

        public enum DisplayState
        {
            Default,
            Set
        }

        public DisplayState state { get; set; }

        public void SetState(bool Set)
        {
            state = Set ? DisplayState.Set : DisplayState.Default;
        }

        public bool GetValue()
        {
            bool value = state == DisplayState.Set;

            return Inverted ? !value : value;
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            bool set = state == DisplayState.Set;

            var colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = 0.25f;
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            paintEventArgs.Graphics.Clear(Color.Transparent);

            paintEventArgs.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            paintEventArgs.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (set) paintEventArgs.Graphics.DrawImage(Image, ClientRectangle, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, imageAttributes);
            else base.OnPaint(paintEventArgs);

            Color penColor = set ? HiddenBorderColor : ShownBorderColor;

            if (ForceHidden)
                penColor = HiddenBorderColor;
            else if (ForceShown)
                penColor = ShownBorderColor;

            var pen = new Pen(penColor, 2.5f);

            pen.DashStyle = (ForceHidden || ForceShown) ? DashStyle.Solid : DashStyle.Dash;

            paintEventArgs.Graphics.DrawRectangle(pen, ClientRectangle);
        }

        // Add implementation to the IButtonControl.PerformClick method.
        public void PerformClick()
        {
            if (CanSelect)
            {
                OnClick(EventArgs.Empty);
            }
        }
    }
}