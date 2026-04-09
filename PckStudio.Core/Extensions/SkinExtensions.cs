using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMI.Formats.Languages;
using OMI.Formats.Pck;
using PckStudio.Core.Skin;

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
    }
}
