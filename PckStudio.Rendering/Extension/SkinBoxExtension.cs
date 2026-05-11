using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PckStudio.Core.Extensions;
using PckStudio.Core.Skin;

namespace PckStudio.Rendering.Extension
{
    public static class SkinBoxExtension
    {
        public static Cube ToCube(this SkinBOX skinBOX) => skinBOX.ToCube(0f);

        public static Cube ToCube(this SkinBOX skinBOX, float inflate, bool flipZMapping = false)
        {
            SkinArmorFlags ArmorFlags = skinBOX.ArmorMaskFlags;

            // this is to ensure armor types include the flags on top of custom defined flags for armor masking

            switch(skinBOX.Type)
            {
                case "BODYARMOR":
                case "ARMARMOR0":
                case "ARMARMOR1":
                    ArmorFlags |= SkinArmorFlags.ChestplateAndArmArmor;
                    break;
                case "LEGGING0":
                case "LEGGING1":
                    ArmorFlags |= SkinArmorFlags.Leggings;
                    break;
                case "BOOT0":
                case "BOOT1":
                    ArmorFlags |= SkinArmorFlags.Boots;
                    break;
                case "BELT":
                    ArmorFlags |= SkinArmorFlags.Belt;
                    break;
                case "SOCK0":
                case "SOCK1":
                    ArmorFlags |= SkinArmorFlags.Socks;
                    break;
            }

            return new Cube(skinBOX.Pos.ToOpenTKVector(), skinBOX.Size.ToOpenTKVector(), skinBOX.UV.ToOpenTKVector(), skinBOX.Scale + inflate, skinBOX.Mirror, flipZMapping, ArmorFlags.ToValue());
        }
    }
}
