using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PckStudio.Core.Skin
{
    [Flags]
    public enum SkinArmorFlagsMask : int
    {
        NONE        = 0,       // 0x00
        HELMET      = 1 << 0,  // 0x01, Makes the SkinBOX invisible when wearing a helmet or other head armor
        CHESTPLATE  = 1 << 1,  // 0x02, Makes the SkinBOX invisible when wearing a chestplate; automatically applied with BODYARMOR, ARMARMOR0, ARMARMOR1, and BELT box types
        LEGGINGS    = 1 << 2,  // 0x04, Makes the SkinBOX invisible when wearing leggings; automatically applied with BELT, LEGGING0, LEGGING1, SOCK0, and SOCK1 box types
        BOOTS       = 1 << 3,  // 0x08, Makes the SkinBOX invisible when wearing boots; automatically applied with BOOT0, and BOOT1 box types
    }
}
