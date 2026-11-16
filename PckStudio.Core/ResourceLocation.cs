/* Copyright (c) 2024-present miku-666
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1.The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
**/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PckStudio.Core.Json;
using PckStudio.Json;

namespace PckStudio.Core
{
    public sealed class ResourceLocation
    {
        private static List<ResourceLocation> ResourceGroups = new List<ResourceLocation>();
        private static readonly ResourceLocation Unknown = new ResourceLocation(string.Empty, ResourceCategory.Unknown, -1);

        private static AtlasGroup[] _particaleAtlasGroups =
        {
            new AtlasGroupAnimation("generic"            , column: 0, row:  0, frameCount:  8, ImageLayoutDirection.Horizontal, 2),
            new AtlasGroupAnimation("splash"             , column: 3, row:  1, frameCount:  4, ImageLayoutDirection.Horizontal, 2),
            new AtlasGroupAnimation("drip"               , column: 0, row:  7, frameCount:  3, ImageLayoutDirection.Horizontal, 4),
            new AtlasGroupAnimation("effect"             , column: 0, row:  8, frameCount:  8, ImageLayoutDirection.Horizontal, 2),
            new AtlasGroupAnimation("splash_effect"      , column: 0, row:  9, frameCount:  8, ImageLayoutDirection.Horizontal, 2),
            new AtlasGroupAnimation("firework_spark"     , column: 0, row: 10, frameCount:  8, ImageLayoutDirection.Horizontal, 2),
            new AtlasGroupAnimation("glitter"            , column: 0, row: 11, frameCount:  8, ImageLayoutDirection.Horizontal, 2),
            new AtlasGroupAnimation("BE_explosion"       , column: 0, row: 12, frameCount: 16, ImageLayoutDirection.Horizontal),
            new AtlasGroupLargeTile("flash"              , column: 4, row:  2, columnSpan: 4, rowSpan: 4),
            new AtlasGroupLargeTileAnimation("bubble_pop", row: 6, column:  6, rowSpan: 2, columnSpan: 2, frameCount: 5, ImageLayoutDirection.Horizontal, 2),
        };

        private static AtlasGroup[] _terrainAtlasGroups =
        {
             new AtlasGroupLargeTile("Oak Door"     , column: 1, row:  5, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Iron Door"    , column: 2, row:  5, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Acacia Door"  , column: 0, row: 23, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Birch Door"   , column: 1, row: 23, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Dark Oak Door", column: 2, row: 23, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Jungle Door"  , column: 3, row: 23, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Spruce Door"  , column: 4, row: 23, columnSpan: 1, rowSpan: 2),

             new AtlasGroupLargeTile("Large Fern"       , column: 0, row: 20, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Double Tall Grass", column: 1, row: 20, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Poeny"            , column: 2, row: 20, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Rose Bush"        , column: 3, row: 20, columnSpan: 1, rowSpan: 2),
             new AtlasGroupLargeTile("Lilac"            , column: 4, row: 20, columnSpan: 1, rowSpan: 2),

             new AtlasGroupAnimation("Wheat"      , column: 8, row:  5, frameCount:  8, ImageLayoutDirection.Horizontal, 5),
             new AtlasGroupAnimation("Potatoes"   , column: 9, row: 16, frameCount:  4, ImageLayoutDirection.Horizontal, 5),
             new AtlasGroupAnimation("Carrots"    , column: 8, row: 12, frameCount:  4, ImageLayoutDirection.Horizontal, 5),
             new AtlasGroupAnimation("Beetroots"  , column: 0, row: 25, frameCount:  4, ImageLayoutDirection.Horizontal, 5),
             new AtlasGroupAnimation("Nether Wart", column: 2, row: 14, frameCount:  3, ImageLayoutDirection.Horizontal, 5),
             new AtlasGroupAnimation("Destroy"    , column: 0, row: 15, frameCount: 10, ImageLayoutDirection.Horizontal, 3),
        };

        private static AtlasGroup[] _itemsAtlasGroups =
        {
            new AtlasGroupAnimation("Bow Pulling", column: 5, row: 6, frameCount: 3, ImageLayoutDirection.Vertical, 6),
        };

        private static AtlasGroup[] _paintingAtlasGroups =
        {
            new AtlasGroupLargeTile("The Pool"                , column:  0, row: 2, columnSpan: 2, rowSpan: 1),
            new AtlasGroupLargeTile("Bonjour Monsiuer Courbet", column:  2, row: 2, columnSpan: 2, rowSpan: 1),
            new AtlasGroupLargeTile("Seaside"                 , column:  4, row: 2, columnSpan: 2, rowSpan: 1),
            new AtlasGroupLargeTile("sunset_dense"            , column:  6, row: 2, columnSpan: 2, rowSpan: 1),
            new AtlasGroupLargeTile("Creebet"                 , column:  8, row: 2, columnSpan: 2, rowSpan: 1),

            new AtlasGroupLargeTile("Wanderer"                , column:  0, row: 4, columnSpan: 1, rowSpan: 2),
            new AtlasGroupLargeTile("Graham"                  , column:  1, row: 4, columnSpan: 1, rowSpan: 2),
            
            new AtlasGroupLargeTile("Fighters"                , column:  0, row: 6, columnSpan: 4, rowSpan: 2),

            new AtlasGroupLargeTile("Match"                   , column:  0, row: 8, columnSpan: 2, rowSpan: 2),
            new AtlasGroupLargeTile("Bust"                    , column:  2, row: 8, columnSpan: 2, rowSpan: 2),
            new AtlasGroupLargeTile("The stage is set"        , column:  4, row: 8, columnSpan: 2, rowSpan: 2),
            new AtlasGroupLargeTile("The Void"                , column:  6, row: 8, columnSpan: 2, rowSpan: 2),
            new AtlasGroupLargeTile("Skull and Roses"         , column:  8, row: 8, columnSpan: 2, rowSpan: 2),
            new AtlasGroupLargeTile("Wither"                  , column: 10, row: 8, columnSpan: 2, rowSpan: 2),

            new AtlasGroupLargeTile("Mortal Coil"             , column: 12, row: 4, columnSpan: 4, rowSpan: 3),
            new AtlasGroupLargeTile("Kong"                    , column: 12, row: 7, columnSpan: 4, rowSpan: 3),

            new AtlasGroupLargeTile("Back Texture"            , column: 12, row: 0, columnSpan: 4, rowSpan: 4),
            new AtlasGroupLargeTile("Pointer"                 , column:  0, row: 12, columnSpan: 4, rowSpan: 4),
            new AtlasGroupLargeTile("Pigscene"                , column:  4, row: 12, columnSpan: 4, rowSpan: 4),
            new AtlasGroupLargeTile("Skull On Fire"           , column:  8, row: 12, columnSpan: 4, rowSpan: 4),
        };

        private static readonly Dictionary<string, ResourceLocation> _categoryLookUp = new Dictionary<string, ResourceLocation>()
        {
            ["textures/items"] = new ResourceLocation("textures/items", ResourceCategory.ItemAnimation, 16, isGroup: true),
            ["textures/blocks"] = new ResourceLocation("textures/blocks", ResourceCategory.BlockAnimation, 16, isGroup: true),
            ["mob"] = new ResourceLocation("mob", ResourceCategory.MobEntityTextures, 1, isGroup: true),
            ["item"] = new ResourceLocation("item", ResourceCategory.ItemEntityTextures, 1, isGroup: true),
            ["terrain.png"] = new ResourceLocation("terrain.png", ResourceCategory.BlockAtlas, 16, tilesInfo: Tiles.BlockTileInfos, atlasGroups: _terrainAtlasGroups),
            ["items.png"] = new ResourceLocation("items.png", ResourceCategory.ItemAtlas, 16, tilesInfo: Tiles.ItemTileInfos, atlasGroups: _itemsAtlasGroups),
            ["particles.png"] = new ResourceLocation("particles.png", ResourceCategory.ParticleAtlas, 16, tilesInfo: Tiles.ParticleTileInfos, atlasGroups: _particaleAtlasGroups),
            //============ TODO ============//
            ["item/banner/Banner_Atlas.png"] = new ResourceLocation("item/banner/Banner_Atlas.png", ResourceCategory.BannerAtlas, new Size(6, 7), TillingMode.WidthAndHeight, tilesInfo: Tiles.BannerTileInfos),
            //==============================//
            ["art/kz.png"] = new ResourceLocation("art/kz.png", ResourceCategory.PaintingAtlas, 16, tilesInfo: Tiles.PaintingTileInfos, atlasGroups: _paintingAtlasGroups),
            ["misc/explosion.png"] = new ResourceLocation("misc/explosion.png", ResourceCategory.ExplosionAtlas, 16, tilesInfo: Tiles.ExplosionTileInfos),
            ["item/xporb.png"] = new ResourceLocation("item/xporb.png", ResourceCategory.ExperienceOrbAtlas, 4, tilesInfo: Tiles.ExperienceOrbTileInfos),
            ["terrain/moon_phases.png"] = new ResourceLocation("terrain/moon_phases.png", ResourceCategory.MoonPhaseAtlas, 4, tilesInfo: Tiles.MoonPhaseTileInfos),
            ["misc/mapicons.png"] = new ResourceLocation("misc/mapicons.png", ResourceCategory.MapIconAtlas, 4, tilesInfo: Tiles.MapIconTileInfos),
            ["misc/additionalmapicons.png"] = new ResourceLocation("misc/additionalmapicons.png", ResourceCategory.AdditionalMapIconsAtlas, 4, tilesInfo: Tiles.AdditionalMapIconTileInfos),
        };

        public static string GetPathFromCategory(ResourceCategory category)
        {
            return category switch
            {
                ResourceCategory.ItemAnimation => _categoryLookUp["textures/items"].ToString(),
                ResourceCategory.BlockAnimation => _categoryLookUp["textures/blocks"].ToString(),
                ResourceCategory.MobEntityTextures => _categoryLookUp["mob"].ToString(),
                ResourceCategory.ItemEntityTextures => _categoryLookUp["item"].ToString(),
                ResourceCategory.BlockAtlas => _categoryLookUp["terrain.png"].ToString(),
                ResourceCategory.ItemAtlas => _categoryLookUp["items.png"].ToString(),
                ResourceCategory.ParticleAtlas => _categoryLookUp["particles.png"].ToString(),
                ResourceCategory.BannerAtlas => _categoryLookUp["item/banner/Banner_Atlas.png"].ToString(),
                ResourceCategory.PaintingAtlas => _categoryLookUp["art/kz.png"].ToString(),
                ResourceCategory.ExplosionAtlas => _categoryLookUp["misc/explosion.png"].ToString(),
                ResourceCategory.ExperienceOrbAtlas => _categoryLookUp["item/xporb.png"].ToString(),
                ResourceCategory.MoonPhaseAtlas => _categoryLookUp["terrain/moon_phases.png"].ToString(),
                ResourceCategory.MapIconAtlas => _categoryLookUp["misc/mapicons.png"].ToString(),
                ResourceCategory.AdditionalMapIconsAtlas => _categoryLookUp["misc/additionalmapicons.png"].ToString(),
                _ => string.Empty
            };
        }

        public static ResourceCategory GetCategoryFromPath(string path) => GetFromPath(path).Category;

        public static ResourceLocation GetFromPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !path.StartsWith("res/"))
                return Unknown;
            string categoryPath = path.Substring("res/".Length);
            if (_categoryLookUp.ContainsKey(categoryPath))
                return _categoryLookUp[categoryPath];
            return ResourceGroups.Where(group => categoryPath.StartsWith(group.Path)).FirstOrDefault() ?? Unknown;
        }

        public enum TillingMode
        {
            Width,
            Height,
            WidthAndHeight
        }

        public string Path { get; }
        public ResourceCategory Category { get; }
        public Size TillingFactor { get; }
        public TillingMode Tilling { get; }
        public bool IsGroup { get; }
        public IEnumerable<JsonTileInfo> TilesInfo { get; }
        public IEnumerable<AtlasGroup> AtlasGroups { get; }

        public Size GetTileArea(Size imgSize)
        {
            return Tilling switch
            {
                TillingMode.Width => new Size(imgSize.Width / TillingFactor.Width, imgSize.Width / TillingFactor.Height),
                TillingMode.Height => new Size(imgSize.Height / TillingFactor.Width, imgSize.Height / TillingFactor.Height),
                TillingMode.WidthAndHeight => new Size(imgSize.Width / TillingFactor.Width, imgSize.Height / TillingFactor.Height),
                _ => Size.Empty,
            };
        }

        private ResourceLocation(string path, ResourceCategory category, int tillingFactor, TillingMode tilling = TillingMode.Width, bool isGroup = false, IEnumerable<JsonTileInfo> tilesInfo = default, IEnumerable<AtlasGroup> atlasGroups = default)
            : this(path, category, new Size(tillingFactor, tillingFactor), tilling, isGroup, tilesInfo, atlasGroups)
        {
        }


        private ResourceLocation(string path, ResourceCategory category, Size tillingFactor, TillingMode tilling = TillingMode.Width, bool isGroup = false, IEnumerable<JsonTileInfo> tilesInfo = default, IEnumerable<AtlasGroup> atlasGroups = default)
        {
            Path = path;
            Category = category;
            TillingFactor = new Size(Math.Max(1, tillingFactor.Width), Math.Max(1, tillingFactor.Height));
            Tilling = tilling;
            IsGroup = isGroup;
            TilesInfo = tilesInfo ?? Enumerable.Empty<JsonTileInfo>();
            AtlasGroups = atlasGroups ?? Enumerable.Empty<AtlasGroup>();
            if (isGroup)
                ResourceGroups.Add(this);
        }

        public override string ToString()
        {
            return "res/" + Path;
        }
    }
}
