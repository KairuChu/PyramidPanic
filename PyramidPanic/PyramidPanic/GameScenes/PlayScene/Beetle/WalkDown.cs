using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class WalkDown : AnimatedSprite, IBeetle
    {
        //Fields.
        private Beetle beetle;

        //Constructor.
        public WalkDown(Beetle beetle)
            : base(beetle)
        {
            this.beetle = beetle;
            this.angle = (float)Math.PI;
        }


        //Update Method.
        public virtual void Update(GameTime gameTime)
        {
            this.beetle.Position += new Vector2(0f, this.beetle.Speed);
            if (this.beetle.Position.Y > this.beetle.Bot)
            {
                this.beetle.State = new WalkUp(this.beetle);
            }
            base.Update(gameTime);
        }

        //Draw Method.
        public virtual void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
