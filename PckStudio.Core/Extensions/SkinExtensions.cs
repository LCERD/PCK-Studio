using OMI.Formats.Languages;
using OMI.Formats.Model;
using OMI.Formats.Pck;
using OpenTK;
using PckStudio.Core.Skin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PckStudio.Core.Extensions
{
    public static class SkinExtensions
    {
        public static PckAsset CreateFile(this Skin.Skin skin, LOCFile localizationFile)
        {
            string skinId = skin.Identifier.ToString("d08");
            PckAsset skinFile = new PckAsset($"dlcskin{skinId}.png", PckAssetType.SkinFile);

            skinFile.AddParameter("DISPLAYNAME", skin.MetaData.Name);
            if (localizationFile is not null)
            {
                string skinLocKey = $"IDS_dlcskin{skinId}_DISPLAYNAME";
                skinFile.AddParameter("DISPLAYNAMEID", skinLocKey);
                localizationFile.AddLocKey(skinLocKey, skin.MetaData.Name);
            }

            if (!string.IsNullOrEmpty(skin.MetaData.Theme))
            {
                skinFile.AddParameter("THEMENAME", skin.MetaData.Theme);
                if (localizationFile is not null)
                {
                    skinFile.AddParameter("THEMENAMEID", $"IDS_dlcskin{skinId}_THEMENAME");
                    localizationFile.AddLocKey($"IDS_dlcskin{skinId}_THEMENAME", skin.MetaData.Theme);
                }
            }

            if (skin.HasCape)
            {
                skinFile.AddParameter("CAPEPATH", $"dlccape{skinId}.png");
            }

            skinFile.AddParameter("ANIM", skin.Anim);
            skinFile.AddParameter("GAME_FLAGS", skin.GameFlags);
            skinFile.AddParameter("FREE", "1");

            foreach (SkinBOX box in skin.Model.AdditionalBoxes)
            {
                skinFile.AddParameter(box.ToParameter());
            }
            foreach (SkinPartOffset offset in skin.Model.PartOffsets)
            {
                skinFile.AddParameter(offset.ToParameter());
            }

            skinFile.SetTexture(skin.Texture);

            return skinFile;
        }

        public static PckAsset CreateCapeFile(this Skin.Skin skin)
        {
            if (!skin.HasCape)
                throw new InvalidOperationException("Skin does not contain a cape.");
            string skinId = skin.Identifier.ToString("d08");
            PckAsset capeFile = new PckAsset($"dlccape{skinId}.png", PckAssetType.CapeFile);
            capeFile.SetTexture(skin.CapeTexture);
            return capeFile;
        }

        // Function to create a paper doll from the skin for use in 2D contexts
        public static Image DrawPaperDoll(this Skin.Skin skin, float pixelScale = 10.0f, int xmlVersion = 0, bool bustCrop = false)
        {
            //pixel scale set to 10 so inflated parts can be seen as properly as possible

            bool isWideSkin = skin.Anim.GetFlag(SkinAnimFlag.MODERN_WIDE_MODEL);
            bool isSlimSkin = skin.Anim.GetFlag(SkinAnimFlag.SLIM_MODEL);
            bool isModernSkin = isWideSkin || isSlimSkin;
            bool isDinnerbone = skin.Anim.GetFlag(SkinAnimFlag.DINNERBONE);
            bool isStatueOfLiberty = skin.Anim.GetFlag(SkinAnimFlag.STATUE_OF_LIBERTY);

            float textureScaleX = skin.Texture.Width / 64f; // minecraft skins always have a width of 64
            float textureScaleY = skin.Texture.Height / (isModernSkin ? 64f : 32f);

            // start with a large canvas and crop down later
            Image paperDoll = new Bitmap(512, 512);

            using (Graphics gfx = Graphics.FromImage(paperDoll))
            {
                gfx.InterpolationMode = InterpolationMode.NearestNeighbor;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.SmoothingMode = SmoothingMode.None;

                SkinBOX baseHeadBox = new SkinBOX("HEAD", new(-4, -8, -4), new(8), new(0, 0));
                SkinBOX baseTorsoBox = new SkinBOX("BODY", new(-4, 0, -2), new(8, 12, 4), new(16, 16));

                List<SkinBOX> baseBoxes = new List<SkinBOX>();
                List<SkinBOX> skinBoxes = new List<SkinBOX>();

                if (!skin.Anim.GetFlag(SkinAnimFlag.HEAD_DISABLED))
                {
                    baseBoxes.Add(baseHeadBox);
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.HEADWEAR_DISABLED))
                {
                    baseBoxes.Add(new SkinBOX("HEADWEAR", new(-4, -8, -4), new(8), new(32, 0), scale: 0.5f));
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.TORSO_DISABLED))
                {
                    baseBoxes.Add(baseTorsoBox);
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.JACKET_DISABLED) && isModernSkin)
                {
                    baseBoxes.Add(new SkinBOX("JACKET", new(-4, 0, -2), new(8, 12, 4), new(16, 32), scale: 0.25f));
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.RIGHT_ARM_DISABLED))
                {
                    baseBoxes.Add(new SkinBOX("ARM0", new(isSlimSkin ? -2 : -3, -2, -2), new(isSlimSkin ? 3 : 4, 12, 4), new(40, 16)));
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.RIGHT_SLEEVE_DISABLED) && isModernSkin)
                {
                    baseBoxes.Add(new SkinBOX("SLEEVE0", new(isSlimSkin ? -2 : -3, -2, -2), new(isSlimSkin ? 3 : 4, 12, 4), new(40, 32), scale: 0.25f));
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.LEFT_ARM_DISABLED))
                {
                    if (!isModernSkin)
                    {
                        baseBoxes.Add(new SkinBOX("ARM1", new(-1, -2, -2), new(4, 12, 4), new(40, 16), mirror: true));
                    }
                    else
                    {
                        baseBoxes.Add(new SkinBOX("ARM1", new(-1, -2, -2), new(isSlimSkin ? 3 : 4, 12, 4), new(32, 48)));
                    }
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.LEFT_SLEEVE_DISABLED) && isModernSkin)
                {
                    baseBoxes.Add(new SkinBOX("SLEEVE1", new(-1, -2, -2), new(isSlimSkin ? 3 : 4, 12, 4), new(48, 48), scale: 0.25f));
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.RIGHT_LEG_DISABLED))
                {
                    baseBoxes.Add(new SkinBOX("LEG0", new(-2, 0, -2), new(4, 12, 4), new(0, 16)));
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.RIGHT_PANTS_DISABLED) && isModernSkin)
                {
                    baseBoxes.Add(new SkinBOX("PANTS0", new(-2, 0, -2), new(4, 12, 4), new(0, 32), scale: 0.25f));
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.LEFT_LEG_DISABLED))
                {
                    if (!isModernSkin)
                    {
                        baseBoxes.Add(new SkinBOX("LEG1", new(-2, 0, -2), new(4, 12, 4), new(0, 16), mirror: true));
                    }
                    else
                    {
                        baseBoxes.Add(new SkinBOX("LEG1", new(-2, 0, -2), new(4, 12, 4), new(16, 48)));
                    }
                }
                if (!skin.Anim.GetFlag(SkinAnimFlag.LEFT_PANTS_DISABLED) && isModernSkin)
                {
                    baseBoxes.Add(new SkinBOX("PANTS1", new(-2, 0, -2), new(4, 12, 4), new(0, 48), scale: 0.25f));
                }

                skinBoxes.AddRange(baseBoxes);
                skinBoxes.AddRange(skin.Model.AdditionalBoxes);

                skinBoxes = skinBoxes
                    .OrderByDescending(box =>
                        isStatueOfLiberty && box.Type == "ARM0"
                            ? -box.Pos.Z
                            : box.Pos.Z
                    )
                    .ThenBy(box => box.Scale)
                    .ToList();

                float canvasWidth = 0;
                float canvasHeight = 0;
                float canvasMinX = float.MaxValue;
                float canvasMinY = float.MaxValue;
                float canvasMaxX = float.MinValue;
                float canvasMaxY = float.MinValue;

                // used to center the render around the torso to best use space
                float torsoCenterY = baseTorsoBox.Pos.Y + (baseTorsoBox.Size.Y / 2f);

                float defaultDrawOffsetX = paperDoll.Width / 2f; // draw at center of the canvas
                float defaultDrawOffsetY = paperDoll.Height / 2f - torsoCenterY * pixelScale; // draw from center of the torso box

                foreach (SkinBOX box in skinBoxes)
                {
                    try
                    {
                        float boxWidth = box.Size.X;
                        float boxHeight = box.Size.Y;
                        float boxDepth = box.Size.Z;

                        if (boxWidth <= 0 || boxHeight <= 0) // if either of these are 0, skip because drawing is impossible
                            continue;

                        bool isStatueOfLibertyArm = isStatueOfLiberty && (box.Type == "ARM0" || box.Type == "SLEEVE0" || box.Type == "ARMARMOR0");

                        // this math is basically to ensure the face is stretched if the texture is improper
                        Rectangle faceRect = new Rectangle(
                            isStatueOfLibertyArm // get back of ARM 0 box if Statue of Liberty
                                ? (int)((box.UV.X + boxWidth + 2 * boxDepth) * textureScaleX) // depth + width + depth = offset for back of box
                                : (int)((box.UV.X + boxDepth) * textureScaleX),
                            (int)((box.UV.Y + boxDepth) * textureScaleY),
                            (int)(boxWidth * textureScaleX),
                            (int)(boxHeight * textureScaleY)
                        );

                        Image boxFace = skin.Texture.GetArea(faceRect);
                        if (box.Mirror) boxFace.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        if (isStatueOfLibertyArm)
                        {
                            boxFace.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        }

                        float drawOffsetX = defaultDrawOffsetX; // draw at center of the canvas
                        float drawOffsetY = defaultDrawOffsetY;

                        // offset by 4 pixels so feet align with where the head should be for the bust crop. This might not be perfect, but it gets the job done for the 2 "vanilla" upside-down skins
                        if (isDinnerbone)
                            drawOffsetY -= 4 * pixelScale;

                        float armXOffset = GameConstants.SkinLeftArmTranslation.X * pixelScale;
                        float armYOffset = GameConstants.SkinLeftArmTranslation.Y * pixelScale;
                        float legXOffset = GameConstants.SkinLeftLegTranslation.X * pixelScale;
                        float legYOffset = GameConstants.SkinLeftLegTranslation.Y * pixelScale;

                        switch (box.Type)
                        {
                            case "HEAD":
                            case "HEADWEAR":
                                drawOffsetY += skin.Model.PartOffsets.Find(x => x.Type == "HEAD").Value * pixelScale;
                                break;
                            case "BODY":
                            case "WAIST":
                            case "JACKET":
                            case "BELT":
                            case "BODYARMOR":
                                drawOffsetY += skin.Model.PartOffsets.Find(x => x.Type == "BODY").Value * pixelScale;
                                break;
                            case "ARM0":
                            case "SLEEVE0":
                            case "ARMARMOR0":
                                drawOffsetX -= armXOffset;
                                drawOffsetY += armYOffset + skin.Model.PartOffsets.Find(x => x.Type == "ARM0").Value * pixelScale;
                                break;
                            case "ARM1":
                            case "SLEEVE1":
                            case "ARMARMOR1":
                                drawOffsetX += armXOffset;
                                drawOffsetY += armYOffset + skin.Model.PartOffsets.Find(x => x.Type == "ARM1").Value * pixelScale;
                                break;
                            case "LEG0":
                            case "PANTS0":
                            case "LEGGING0":
                            case "SOCK0":
                            case "BOOT0":
                                drawOffsetX -= legXOffset;
                                drawOffsetY += legYOffset + skin.Model.PartOffsets.Find(x => x.Type == "LEG0").Value * pixelScale;
                                break;
                            case "LEG1":
                            case "PANTS1":
                            case "LEGGING1":
                            case "SOCK1":
                            case "BOOT1":
                                drawOffsetX += legXOffset;
                                drawOffsetY += legYOffset + skin.Model.PartOffsets.Find(x => x.Type == "LEG1").Value * pixelScale;
                                break;
                        }

                        float boxPosY = box.Pos.Y;

                        if (isStatueOfLibertyArm)
                        {
                            boxPosY = -(box.Pos.Y + box.Size.Y);
                        }

                        float drawX = box.Pos.X * pixelScale;
                        float drawY = boxPosY * pixelScale;

                        float drawWidth = boxWidth * pixelScale;
                        float drawHeight = boxHeight * pixelScale;

                        // handle Box scale
                        float boxInflate =
                            // if XMLVersion 3 or a base box; then return box scale
                            (xmlVersion == 3 || baseBoxes.Contains(box)) ? box.Scale
                                // if not; then check that it is an overlay box
                                : (xmlVersion > 0 && xmlVersion < 3 && SkinBOX.OverlayTypes.Contains(box.Type))
                                    // if so, return hardcoded box inflate value
                                    ? (box.Type == "HEADWEAR" ? 0.5f : 0.25f)
                                    : 0f; // finally, if not caught anywhere else, return no scale

                        float drawInflate = boxInflate * pixelScale * 1.5f; // no idea why 1.5 seems to fix this :,)
                        float halfInflation = drawInflate * 0.5f;

                        float finalDrawX = drawOffsetX + drawX - halfInflation;
                        float finalDrawY = drawOffsetY + drawY - halfInflation;

                        float finalDrawWidth = drawWidth + drawInflate;
                        float finalDrawHeight = drawHeight + drawInflate;

                        RectangleF boxRect = new RectangleF(finalDrawX, finalDrawY, finalDrawWidth, finalDrawHeight);

                        if (isStatueOfLiberty && box.Type == "ARM0")
                        {
                            float pivotX = defaultDrawOffsetX + GameConstants.SkinRightArmPivot.X * pixelScale;
                            float pivotY = defaultDrawOffsetY + GameConstants.SkinRightArmPivot.Y * pixelScale;

                            float angle = -8f * (float)Math.PI / 180f;

                            // used to calculate if the bounds of the arm go beyond the current bounds of the image so that the entire skin is shown
                            PointF[] armBounds =
                            {
                                new PointF(finalDrawX, finalDrawY),
                                new PointF(finalDrawX + finalDrawWidth, finalDrawY),
                                new PointF(finalDrawX, finalDrawY + finalDrawHeight),
                                new PointF(finalDrawX + finalDrawWidth, finalDrawY + finalDrawHeight)
                            };

                            foreach (var bound in armBounds)
                            {
                                float finalX = bound.X - pivotX;
                                float finalY = bound.Y - pivotY;

                                float rotateX = pivotX + (finalX * (float)Math.Cos(angle) - finalY * (float)Math.Sin(angle));
                                float rotateY = pivotY + (finalX * (float)Math.Sin(angle) + finalY * (float)Math.Cos(angle));

                                canvasMinX = Math.Min(canvasMinX, rotateX);
                                canvasMinY = Math.Min(canvasMinY, rotateY);
                                canvasMaxX = Math.Max(canvasMaxX, rotateX);
                                canvasMaxY = Math.Max(canvasMaxY, rotateY);
                            }

                            var state = gfx.Save();

                            gfx.TranslateTransform(pivotX, pivotY);
                            gfx.RotateTransform(-8f);
                            gfx.TranslateTransform(-pivotX, -pivotY);

                            gfx.DrawImage(boxFace, boxRect);

                            gfx.Restore(state);
                        }
                        else
                        {
                            canvasMinX = Math.Min(canvasMinX, finalDrawX);
                            canvasMinY = Math.Min(canvasMinY, finalDrawY);
                            canvasMaxX = Math.Max(canvasMaxX, finalDrawX + finalDrawWidth);
                            canvasMaxY = Math.Max(canvasMaxY, finalDrawY + finalDrawHeight);

                            gfx.DrawImage(boxFace, boxRect);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                canvasWidth = canvasMaxX - canvasMinX;
                canvasHeight = canvasMaxY - canvasMinY;

                Console.WriteLine($"{skin.Identifier.Id} {canvasWidth}x{canvasHeight}");

                Rectangle cropRect = new Rectangle(
                    (int)Math.Floor(canvasMinX),
                    (int)Math.Floor(canvasMinY),
                    (int)Math.Ceiling(canvasMaxX - canvasMinX),
                    (int)Math.Ceiling(canvasMaxY - canvasMinY)
                );

                if (bustCrop)
                {
                    if(isDinnerbone)
                        paperDoll.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    float headCenterY = baseHeadBox.Pos.Y + (baseHeadBox.Size.Y / 2f);

                    float cropX = defaultDrawOffsetX;
                    float cropY = defaultDrawOffsetY + (headCenterY * pixelScale);

                    const int size = 256;

                    cropRect = new Rectangle(
                        (int)Math.Floor(cropX - size / 2f),
                        (int)Math.Floor(cropY - size / 2f),
                        size,
                        size
                    );
                }

                paperDoll = paperDoll.GetArea(cropRect);

                if (isDinnerbone && !bustCrop)
                    paperDoll.RotateFlip(RotateFlipType.RotateNoneFlipY);

                return paperDoll;
            }
        }
    }
}
