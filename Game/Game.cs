using RZGame.Core.ContentManagement;
using RZGame.Core.Utilities;
using RZGame.Scenes;

namespace RZGame
{
    public class Game : Nez.Core
    {
		public static Game GameInstance;

		public ContentManager CM;

		public Game() : base()
		{
			GameInstance = this;
			CM = new();
		}

		protected override void Initialize()
		{
			base.Initialize();

			CM.AddAsset("REIMU_SPRITE.png", "root/textures", AssetType.Image);
			CM.LoadAssets();

			Scene = new SampleScene();
		}

        protected override void LoadContent()
        {
            base.LoadContent();
		}
        protected override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

			KeyboardHelper.GetState();
		}
    }
}
