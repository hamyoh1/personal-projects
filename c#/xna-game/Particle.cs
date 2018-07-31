using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Honour_In_Blood
{
    class Particle
    {
        Texture2D spriteTexture;
        float timer = 0f;
        float interval = 200f;
        int currentFrameX = 0;
        int currentFrameY = 0;
        int spriteHeight = 64;
        int spriteWidth = 64;
        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }

        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public Particle(Texture2D texture, int currentFrameX, int currentFrameY, int spriteWidth, int spriteHeight, float interval)
        {
            this.spriteTexture = texture;
            this.currentFrameX = currentFrameX;
            this.currentFrameY = currentFrameY;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            this.interval = interval;
        }

        public void ParticleAnimate(GameTime gameTime)
        {
            sourceRect = new Rectangle(currentFrameX * spriteWidth, currentFrameY * spriteHeight, spriteWidth, spriteHeight); //Set the source rectangle[position and size of current frame on the spritesheet]

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrameX++;

                //if the animation reaches the end, set it back to the beginning
                if (currentFrameX > ((Texture.Width / spriteWidth) - 1))
                {
                    currentFrameX = 0;

                    //Check if the particle texture is more than 1 tile high
                    if (Texture.Height > spriteHeight)
                    {
                        //if it is, go down 1 row
                        currentFrameY++;
                        if (Texture.Height <= (currentFrameY * spriteHeight)) //Check if it's on the last row, if so, reset row
                        {
                            currentFrameY = 0;
                        }
                    }
                }
                timer = 0f;
            }
        }
    }
}