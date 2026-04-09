using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PckStudio.Core.Skin
{
    [Flags]
    public enum SkinGameFlagsMask : int
    {
        NONE                        = 0,       // 0x00
        UNFAIR_BATTLE_SKIN          = 1 << 0,  // 0x01, Makes the skin unusable in Competitive Battle Mini Games
        FEMALE_SKIN                 = 1 << 1,  // 0x02, used on female skins
        MALE_SKIN                   = 1 << 2,  // 0x04, used on male skins
        HUMAN_SKIN                  = 1 << 3,  // 0x08, used on human skins that can be any gender and some non human IP characters

        BIOLOGICAL_SKIN             = 1 << 4,  // 0x10, This is only ever disabled on Robot/Synthetic skins so this is seemingly implied

        // HOW THESE FLAGS ARE USED IN GAME //
        // DLC skins in Minecraft Console utilize these flags for what seems to be a cut categorization/sorting feature
        // found in the skins menu with unused tabs labled "Mal" "Fem" and "Bea", respectively Male, Female, and likely "Beast"
        // with Steve, Alex, and Creeper icon sprites respectively.

        // Most, but notably not all, skins use this feature with a GAME_FLAGS. The following are the known used values and their archetypes:
        // *Note this does not include variations with the battle flag. Just add 1 to get those values; i.e 0x1a -> 0x1b or 0x18 -> 0x19
        // Creature/Fantasy skins       - 0x16: Female, Male, and Biological flags enabled.
        // Gender neutral human skins   - 0x18: Human and Biological flags enabled.
        // Female human skins           - 0x1a: Female, Human, and Biological flags enabled.
        // Male human skins             - 0x1c: Male, Human, and Biological flags enabled.
        // Robot/Synthetic skins        - 0x0e: Male, Female, and Human flags enabled.
    }
}
