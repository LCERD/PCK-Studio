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
using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace PckStudio.Core.Skin
{
    /// <summary>
    /// Represents a Skin GAME_FLAGS value where flags can be set
    /// </summary>
    public class SkinGameFlags : ICloneable, IEquatable<SkinGameFlags>, IEquatable<SkinGameFlagsMask>
    {
		public static readonly SkinGameFlags Empty = new SkinGameFlags(0);
		public static readonly SkinGameFlags CreatureSkin = new SkinGameFlags(0x16);
		public static readonly SkinGameFlags HumanSkin = new SkinGameFlags(0x18);
		public static readonly SkinGameFlags FemaleHumanSkin = new SkinGameFlags(0x1a);
		public static readonly SkinGameFlags MaleHumanSkin = new SkinGameFlags(0x1c);
		public static readonly SkinGameFlags RobotSkin = new SkinGameFlags(0x0e);

		private BitVector32 _flags;
		private static readonly Regex _validator = new Regex(@"^0x[0-9a-f]{1,2}\b", RegexOptions.IgnoreCase);

		public SkinGameFlags(SkinGameFlagsMask mask)
			: this((int)mask)
		{
		}

		private SkinGameFlags(int mask)
		{
			_flags = new BitVector32(mask);
		}

		public override string ToString() => "0x" + _flags.Data.ToString("x2");

		public static bool IsValidGameFlags(string gameFlags)
		{
			return !string.IsNullOrWhiteSpace(gameFlags) && _validator.IsMatch(gameFlags);
		}

		public static SkinGameFlags FromString(string value)
			=> IsValidGameFlags(value)
				? new SkinGameFlags(Convert.ToInt32(value.TrimEnd(' ', '\n', '\r'), 16))
                : Empty;

		public static SkinGameFlags operator |(SkinGameFlags @this, SkinGameFlags other) => new SkinGameFlags(@this._flags.Data | other._flags.Data);

		public static SkinGameFlags operator |(SkinGameFlags @this, SkinGameFlagsMask mask) => new SkinGameFlags(@this._flags.Data | (int)mask);
		public static SkinGameFlags operator &(SkinGameFlags @this, SkinGameFlagsMask mask) => new SkinGameFlags(@this._flags.Data & (int)mask);
        public static SkinGameFlags FromValue(int value) => new SkinGameFlags(value);
		
		public int ToValue() => _flags.Data;

		public static implicit operator SkinGameFlags(SkinGameFlagsMask mask) => new SkinGameFlags(mask);

		public static bool operator ==(SkinGameFlags @this, SkinGameFlagsMask mask) => @this.Equals(mask);
		public static bool operator !=(SkinGameFlags @this, SkinGameFlagsMask mask) => !@this.Equals(mask);
		public static bool operator ==(SkinGameFlags @this, SkinGameFlags other) => @this.Equals(other);
		public static bool operator !=(SkinGameFlags @this, SkinGameFlags other) => !@this.Equals(other);

        public bool Equals(SkinGameFlags other)
        {
            return _flags.Data == other._flags.Data;
        }

        public bool Equals(SkinGameFlagsMask other)
        {
            return _flags.Data == (int)other;
        }

		public override bool Equals(object obj) => obj is SkinGameFlags a && Equals(a);

		public override int GetHashCode() => _flags.Data;

        /// <summary>
        /// Sets the desired flag in the bitfield
        /// </summary>
        /// <param name="flag">GAME_FLAGS Flag to set</param>
        /// <param name="state">State of the flag</param>
        public SkinGameFlags SetFlag(SkinGameFlagsFlag flag, bool state)
        {
            if (!Enum.IsDefined(typeof(SkinGameFlagsFlag), flag))
                throw new ArgumentOutOfRangeException(nameof(flag));
            return new SkinGameFlags(state ? _flags.Data | 1 << (int)flag : _flags.Data & ~(1 << (int)flag));
        }

        /// <summary>
        /// Gets flag state
        /// </summary>
        /// <param name="flag">Flag to check</param>
        /// <returns>True if flag is set, otherwise false</returns>
        public bool GetFlag(SkinGameFlagsFlag flag)
		{
            if (!Enum.IsDefined(typeof(SkinGameFlagsFlag), flag))
                throw new ArgumentOutOfRangeException(nameof(flag));
            return _flags[1 << (int)flag];
		}

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
