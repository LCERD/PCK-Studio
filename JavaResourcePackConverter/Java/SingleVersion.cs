using System;

namespace JavaResourcePackConverter
{
    class SingleVersion(Version version) : IMinecraftJavaVersion
    {
        private readonly Version _version = version;

        public SingleVersion(string version) : this(new Version(version)) { }

        public bool Equals(Version other) => _version.Equals(other);

        public string ToString(string _) => _version.ToString();
    }
}
