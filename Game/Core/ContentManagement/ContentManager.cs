using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.IO;

namespace RZGame.Core.ContentManagement
{
    public enum AssetType
    {
        Image,
        SoundEffect,
        Music,
        Font,
        Shader
    }

    public struct Asset
    {
        public AssetType Type;
        public string Name;
        public string Path;

        public Asset(AssetType type, string name, string path)
        {
            Type = type;
            Name = name;
            Path = path;
        }
    }

    public class ContentManager
    {
        private readonly Dictionary<string, Asset> _assets;
        public readonly Dictionary<string, Texture2D> Textures;
        public readonly Dictionary<string, SpriteFont> Fonts;
        public readonly Dictionary<string, SoundEffect> SFXs;
        public readonly Dictionary<string, Song> Songs;

        private RZPAKLoader Loader;

        public ContentManager()
        {
            Loader = new();

            _assets = new Dictionary<string, Asset>();
            Textures = new Dictionary<string, Texture2D>();
            Fonts = new Dictionary<string, SpriteFont>();
            SFXs = new Dictionary<string, SoundEffect>();
            Songs = new Dictionary<string, Song>();
        }

        public void LoadAssets()
        {
            Dictionary<string, byte[]> files = Loader.Load();
            foreach(KeyValuePair<string, Asset> asset in _assets)
            {
                if(asset.Value.Type == AssetType.Image)
                {
                    if(files.TryGetValue(asset.Value.Name, out byte[] content))
                    {
                        using MemoryStream ms = new(content);
                        Texture2D tex = Texture2D.FromStream(Game.GraphicsDevice, ms);
                        Textures.Add(asset.Value.Name, tex);
                    }
                }
            }
        }

        public void AddAsset(string name, string path, AssetType type)
        {
            Asset asset = new()
            {
                Name = name,
                Path = path,
                Type = type
            };
            _assets.Add(name, asset);
        }

        public static Texture2D GetTexture(string name)
        {
            if (Game.GameInstance.CM.Textures.TryGetValue(name, out Texture2D tex))
            {
                return tex;
            }
            else
            {
                return new Texture2D(Nez.Core.GraphicsDevice, 32, 32);
            }
        }
    }
}
