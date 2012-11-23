using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class Panel
    {

        //fields
        private PyramidPanic game;
        private Vector2 position;
        private SpriteFont font;
        private List<Picture> pictures;
        //Constructor
        public Panel(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.Initialize();
        }
        private void Initialize()
        {
            this.font = this.game.Content.Load<SpriteFont>(@"PlaySceneAssets\Fonts\Arial");
            this.pictures = new List<Picture>();
            this.LoadContent();

        }
        private void LoadContent()
        {
            this.pictures.Add(new Picture(this.game, @"PlaySceneAssets\Panel\Panel", this.position));
            this.pictures.Add(new Picture(this.game, @"PlaySceneAssets\Panel\Lives", this.position + new Vector2 (2*32f, 0f)));
            this.pictures.Add(new Picture(this.game, @"PlaySceneAssets\Treasures\Scarab", this.position
                                                      + new Vector2(7.5f * 32f, 0f)));
        }
        public void Draw(GameTime gameTime)
        {
            foreach (Picture picture in this.pictures)
            {
                picture.Draw(gameTime);
            }
            this.game.SpriteBatch.DrawString(this.font, "3", this.position+ new Vector2(3f *32f, -2f), Color.Yellow);
            this.game.SpriteBatch.DrawString(this.font, "0", this.position + new Vector2(8.5f * 32f, -2f), Color.Yellow);
            this.game.SpriteBatch.DrawString(this.font, "0", this.position + new Vector2(16.5f * 32f, 3f), Color.Yellow);
        }

    }
}
