using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using RZGame.Core.ContentManagement;
using RZGame.Core.Utilities;

namespace RZGame.Scenes
{
    class SampleScene : Scene
    {
        private Entity reimu;
        private SpriteRenderer reimuSprite;

        private float moveSpeed = 2.0f;
        private bool lookingLeft = false;

        public override void Initialize()
        {
            base.Initialize();

            Texture2D reimuTex = ContentManager.GetTexture("REIMU_SPRITE.png");
            reimuSprite = new(reimuTex);

            reimu = CreateEntity("reimu");
            reimu.AddComponent(reimuSprite);
            reimu.Transform.Position = Vector2.One * 100;

            //Camera.RawZoom = 2;
        }

        public override void Begin()
        {
            base.Begin();
        }

        public override void Update()
        {
            base.Update();

            if (KeyboardHelper.GetKeyDown(Keys.D))
            {
                reimu.Transform.Position = new Vector2(
                    reimu.Transform.Position.X + moveSpeed,
                    reimu.Transform.Position.Y);
                lookingLeft = false;
            }
            else if (KeyboardHelper.GetKeyDown(Keys.A))
            {
                reimu.Transform.Position = new Vector2(
                    reimu.Transform.Position.X - moveSpeed,
                    reimu.Transform.Position.Y);
                lookingLeft = true;
            }

            if (KeyboardHelper.GetKeyDown(Keys.S))
            {
                reimu.Transform.Position = new Vector2(
                    reimu.Transform.Position.X,
                    reimu.Transform.Position.Y + moveSpeed);
            }
            else if (KeyboardHelper.GetKeyDown(Keys.W))
            {
                reimu.Transform.Position = new Vector2(
                    reimu.Transform.Position.X,
                    reimu.Transform.Position.Y - moveSpeed);
            }

            reimuSprite.FlipX = lookingLeft;
        }
    }
}
