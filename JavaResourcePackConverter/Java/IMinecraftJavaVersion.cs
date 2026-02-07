using System;

namespace JavaResourcePackConverter
{
    interface IMinecraftJavaVersion : IEquatable<Version>
    {
        string ToString(string seperator);
    }
}
