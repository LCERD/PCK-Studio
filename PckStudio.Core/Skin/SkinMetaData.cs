namespace PckStudio.Core.Skin
{
    public sealed class SkinMetaData
    {
        public string Name { get; }
        public string Theme { get; }
        public bool IsDisplayName;

        public SkinMetaData(string name, string theme)
        {
            Name = name;
            Theme = theme;
        }
    }
}
