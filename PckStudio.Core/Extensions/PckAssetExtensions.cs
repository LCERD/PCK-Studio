using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;

using OMI.Formats.Languages;
using OMI.Formats.Pck;
using OMI.Workers;

using PckStudio.Interfaces;
using PckStudio.Core.Deserializer;
using PckStudio.Core.Serializer;
using PckStudio.Core.Skin;

namespace PckStudio.Core.Extensions
{
    public static class PckAssetExtensions
    {
        private const string MipMap = "MipMapLevel";

        public static PckAsset CreateNewAssetIf(this PckFile pck, bool condition, string filename, PckAssetType filetype, IDataFormatWriter writer)
        {
            if (condition)
            {
                return pck.CreateNewAsset(filename, filetype, writer);
            }
            return default;
        }

        public static PckAsset CreateNewAsset(this PckFile pck, string filename, PckAssetType filetype, IDataFormatWriter writer)
        {
            PckAsset asset = pck.CreateNewAsset(filename, filetype);
            asset.SetData(writer);
            return asset;
        }

        public static Image GetTexture(this PckAsset asset)
        {
            if (asset.Type != PckAssetType.SkinFile &&
                asset.Type != PckAssetType.CapeFile &&
                asset.Type != PckAssetType.TextureFile)
            {
                throw new Exception("Asset is not suitable to contain image data.");
            }
            return asset.GetDeserializedData(ImageDeserializer.DefaultDeserializer);
        }

        /// <summary>
        /// Tries to get the skin id of the skin <paramref name="asset"/>
        /// </summary>
        /// <param name="asset"></param>
        /// <returns>Non-zero base number on success, otherwise 0</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static int GetSkinId(this PckAsset asset)
        {
            if (asset.Type != PckAssetType.SkinFile)
                throw new InvalidOperationException("Asset is not a skin.");

            const string skinAssetnamePrefix = "dlcskin";

            string assetPath = Path.GetFileNameWithoutExtension(asset.Filename);
            if (!assetPath.StartsWith(skinAssetnamePrefix))
            {
                Trace.TraceWarning($"[{nameof(GetSkinId)}] Asset name does not start with '{skinAssetnamePrefix}'");
                return 0;
            }

            int skinId = 0;
            if (!int.TryParse(assetPath.Substring(skinAssetnamePrefix.Length), out skinId))
            {
                Trace.TraceWarning($"[{nameof(GetSkinId)}] Failed to parse Skin Id");
            }
            return skinId;
        }

        public static Skin.Skin GetSkin(this PckAsset asset)
        {
            if (asset.Type != PckAssetType.SkinFile)
                throw new InvalidOperationException("Asset is not a skin.");

            int skinId = asset.GetSkinId();

            string name = asset.GetParameter("DISPLAYNAME");
            Image texture = asset.GetTexture();
            SkinANIM anim = asset.GetParameter("ANIM", SkinANIM.FromString);
            SkinGameFlags gameFlags = asset.GetParameter("GAME_FLAGS", SkinGameFlags.FromString);
            IEnumerable<SkinBOX> boxes = asset.GetMultipleParameters("BOX").Select(kv => SkinBOX.FromString(kv.Value));
            IEnumerable<SkinPartOffset> offsets = asset.GetMultipleParameters("OFFSET").Select(kv => SkinPartOffset.FromString(kv.Value));
            return new Skin.Skin(name, skinId, texture, anim, gameFlags, boxes, offsets);
        }

        public static void SetSkin(this PckAsset asset, Skin.Skin skin, LOCFile localizationFile)
        {
            if (asset.Type != PckAssetType.SkinFile)
                throw new InvalidOperationException("Asset is not a skin file");

            asset.SetTexture(skin.Texture);

            string skinId = skin.Identifier.ToString("d08");

            // TODO: keep filepath 
            asset.Filename = $"dlcskin{skinId}.png";

            asset.SetParameter("DISPLAYNAME", skin.MetaData.Name);

            if (localizationFile is not null)
            {
                string skinLocKey = $"IDS_dlcskin{skinId}_DISPLAYNAME";
                asset.SetParameter("DISPLAYNAMEID", skinLocKey);
                localizationFile.SetLocEntry(skinLocKey, skin.MetaData.Name);
            }

            if (!string.IsNullOrEmpty(skin.MetaData.Theme))
            {
                asset.SetParameter("THEMENAME", skin.MetaData.Theme);

                if (localizationFile is not null)
                {
                    string skinThemeLocKey = $"IDS_dlcskin{skinId}_THEMENAME";
                    asset.SetParameter("THEMENAMEID", skinThemeLocKey);
                    localizationFile.SetLocEntry(skinThemeLocKey, skin.MetaData.Theme);
                }
            }

            if (skin.HasCape)
            {
                asset.SetParameter("CAPEPATH", $"dlccape{skinId}.png");
            }

            asset.SetParameter("ANIM", skin.Anim.ToString());
            asset.SetParameter("GAME_FLAGS", skin.GameFlags.ToString());
            asset.SetParameter("FREE", "1");

            asset.RemoveParameters("BOX");
            asset.RemoveParameters("OFFSET");

            foreach (SkinBOX box in skin.Model.AdditionalBoxes)
            {
                asset.AddParameter(box.ToParameter());
            }
            foreach (SkinPartOffset offset in skin.Model.PartOffsets)
            {
                asset.AddParameter(offset.ToParameter());
            }
        }

        public static T GetDeserializedData<T>(this PckAsset asset, IPckAssetDeserializer<T> deserializer)
        {
            return deserializer.Deserialize(asset);
        }

        public static T GetData<T>(this PckAsset asset, IDataFormatReader<T> formatReader) where T : class
        {
            using var ms = new MemoryStream(asset.Data);
            return formatReader.FromStream(ms);
        }

        public static void SetSerializedData<T>(this PckAsset asset, T obj, IPckAssetSerializer<T> serializer)
        {
            serializer.Serialize(obj, ref asset);
        }

        public static void SetData(this PckAsset asset, IDataFormatWriter formatWriter)
        {
            using (var stream = new MemoryStream())
            {
                formatWriter.WriteToStream(stream);
                asset.SetData(stream.ToArray());
            }
        }

        public static void SetTexture(this PckAsset asset, Image image)
        {
            if (asset.Type != PckAssetType.SkinFile &&
                asset.Type != PckAssetType.CapeFile &&
                asset.Type != PckAssetType.TextureFile)
            {
                throw new Exception("Asset is not suitable to contain image data.");
            }
            asset.SetSerializedData(image, ImageSerializer.DefaultSerializer);
        }

        public static bool IsMipmappedFile(this PckAsset asset)
        {
            // We only want to test the file name itself. ex: "terrainMipMapLevel2"
            string name = Path.GetFileNameWithoutExtension(asset.Filename);

            // check if last character is a digit (0-9). If not return false
            if (!char.IsDigit(name[name.Length - 1]))
                return false;

            // If string does not end with MipMapLevel, then it's not MipMapped
            if (!name.Remove(name.Length - 1, 1).EndsWith(MipMap))
                return false;
            return true;
        }

        public static string GetNormalPath(this PckAsset asset)
        {
            if (!asset.IsMipmappedFile())
                return asset.Filename;
            string ext = Path.GetExtension(asset.Filename);
            return asset.Filename.Remove(asset.Filename.Length - (MipMap.Length + 1) - ext.Length) + ext;
        }

        public static void DeserializeParameters(this PckAsset asset, IEnumerable<string> serializedData)
        {
            IEnumerable<KeyValuePair<string, string>> lines = serializedData
                .Select(line => line.Split([' '], 2))
                .Where (keyValue => keyValue.Length == 2)
                .Select(keyValue => new KeyValuePair<string, string>(keyValue[0].Replace(":", ""), keyValue[1]));
            foreach (KeyValuePair<string, string> kv in lines)
            {
                asset.AddParameter(kv);
            }
        }

        public static IEnumerable<string> SerializeParameters(this PckAsset asset, string separator = ":")
        {
            IReadOnlyList<KeyValuePair<string, string>> parameters = asset.GetParameters();
            return parameters.Select(parameter => parameter.Key + separator + parameter.Value);
        }
    }
}
