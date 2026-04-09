/* Copyright (c) 2022-present miku-666, MayNL
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
**/

namespace PckStudio.Core.Skin
{
    /// <summary>
    /// For usage see <see cref="SkinGameFlags"/>
    /// </summary>
	public enum SkinGameFlagsFlag : int // this is such a stupid name lol
	{
		UNFAIR_BATTLE_SKIN			= 0,   // 0x01
		FEMALE_SKIN					= 1,   // 0x02
		MALE_SKIN					= 2,   // 0x04
		HUMAN_SKIN					= 3,   // 0x08
										   //
        BIOLOGICAL_SKIN				= 4,   // 0x10
    }
}
