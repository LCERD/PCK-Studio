/* Copyright (c) 2026-present miku-666, MayNL
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
using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace PckStudio.Core.Skin
{
    /// <summary>
    /// Represents a SkinBOX ArmorFlags value where flags can be set
    /// </summary>
    public class SkinArmorFlags : ICloneable, IEquatable<SkinArmorFlags>, IEquatable<SkinArmorFlagsMask>
    {
		public static readonly SkinArmorFlags Empty = new SkinArmorFlags(0);
		public static readonly SkinArmorFlags HeadArmor = new SkinArmorFlags(1);
		public static readonly SkinArmorFlags ChestplateAndArmArmor = new SkinArmorFlags(2);
		public static readonly SkinArmorFlags Leggings = new SkinArmorFlags(4);
        public static readonly SkinArmorFlags Belt = new SkinArmorFlags(6);
        public static readonly SkinArmorFlags Boots = new SkinArmorFlags(8);
        public static readonly SkinArmorFlags Socks = new SkinArmorFlags(12);

		private BitVector32 _flags;
		private static readonly Regex _validator = new Regex(@"^(0|[1-9]|1[0-6])$", RegexOptions.CultureInvariant);

        public SkinArmorFlags(SkinArmorFlagsMask mask)
			: this((int)mask)
		{
		}

		public SkinArmorFlags(int mask)
		{
			_flags = new BitVector32(mask);
		}

		public override string ToString() => _flags.Data.ToString(); // decimal instead of hexadecimal like the other bitfields in the game

		public static bool IsValidArmorFlags(string gameFlags)
		{
			return !string.IsNullOrWhiteSpace(gameFlags) && _validator.IsMatch(gameFlags);
		}

		public static SkinArmorFlags FromString(string value)
			=> IsValidArmorFlags(value)
				? new SkinArmorFlags(Convert.ToInt32(value))
                : Empty;

		public static SkinArmorFlags operator |(SkinArmorFlags @this, SkinArmorFlags other) => new SkinArmorFlags(@this._flags.Data | other._flags.Data);

		public static SkinArmorFlags operator |(SkinArmorFlags @this, SkinArmorFlagsMask mask) => new SkinArmorFlags(@this._flags.Data | (int)mask);
		public static SkinArmorFlags operator &(SkinArmorFlags @this, SkinArmorFlagsMask mask) => new SkinArmorFlags(@this._flags.Data & (int)mask);
        public static SkinArmorFlags FromValue(int value) => new SkinArmorFlags(value);
		
		public int ToValue() => _flags.Data;

		public static implicit operator SkinArmorFlags(SkinArmorFlagsMask mask) => new SkinArmorFlags(mask);

		public static bool operator ==(SkinArmorFlags @this, SkinArmorFlagsMask mask) => @this.Equals(mask);
		public static bool operator !=(SkinArmorFlags @this, SkinArmorFlagsMask mask) => !@this.Equals(mask);
		public static bool operator ==(SkinArmorFlags @this, SkinArmorFlags other) => @this.Equals(other);
		public static bool operator !=(SkinArmorFlags @this, SkinArmorFlags other) => !@this.Equals(other);

        public bool Equals(SkinArmorFlags other)
        {
            return _flags.Data == other._flags.Data;
        }

        public bool Equals(SkinArmorFlagsMask other)
        {
            return _flags.Data == (int)other;
        }

		public override bool Equals(object obj) => obj is SkinArmorFlags a && Equals(a);

		public override int GetHashCode() => _flags.Data;

        /// <summary>
        /// Sets the desired flag in the bitfield
        /// </summary>
        /// <param name="flag">SkinArmor Flag to set</param>
        /// <param name="state">State of the flag</param>
        public SkinArmorFlags SetFlag(SkinArmorFlagsFlag flag, bool state)
        {
            if (!Enum.IsDefined(typeof(SkinArmorFlagsFlag), flag))
                throw new ArgumentOutOfRangeException(nameof(flag));
            return new SkinArmorFlags(state ? _flags.Data | 1 << (int)flag : _flags.Data & ~(1 << (int)flag));
        }

        /// <summary>
        /// Gets flag state
        /// </summary>
        /// <param name="flag">Flag to check</param>
        /// <returns>True if flag is set, otherwise false</returns>
        public bool GetFlag(SkinArmorFlagsFlag flag)
		{
            if (!Enum.IsDefined(typeof(SkinArmorFlagsFlag), flag))
                throw new ArgumentOutOfRangeException(nameof(flag));
            return _flags[1 << (int)flag];
		}

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
