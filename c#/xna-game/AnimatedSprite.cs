using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Honour_In_Blood
{
    public class AnimatedSprite
    {
        KeyboardState currentKBState;
        KeyboardState previousKBState;
        Texture2D spriteTexture;
        float timer = 0f;
        float interval = 200f;
        int currentFrameX = 0;
        int currentFrameY = 0;
        int spriteWidth = 64;
        int spriteHeight = 64;
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

        public AnimatedSprite(Texture2D texture, int currentFrameX, int currentFrameY, int spriteWidth, int spriteHeight)
        {
            this.spriteTexture = texture;
            this.currentFrameX = currentFrameX;
            this.currentFrameY = currentFrameY;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            previousKBState = currentKBState;
            currentKBState = Keyboard.GetState();

            sourceRect = new Rectangle(currentFrameX * spriteWidth, currentFrameY * spriteHeight, spriteWidth, spriteHeight);

            //If no keys are pressed, return the frame to 0
            if (currentKBState.GetPressedKeys().Length == 0)
            {
                if (currentFrameX > 0 && currentFrameX < 4 && currentFrameY == 0)
                {
                    currentFrameX = 0;
                    currentFrameY = 0;
                }
                if (currentFrameX > 0 && currentFrameX < 4 && currentFrameY == 1)
                {
                    currentFrameX = 0;
                    currentFrameY = 1;
                }
                if (currentFrameX > 0 && currentFrameX < 4 && currentFrameY == 2)
                {
                    currentFrameX = 0;
                    currentFrameY = 2;
                }
                if (currentFrameX > 0 && currentFrameX < 4 && currentFrameY >= 3)
                {
                    currentFrameX = 0;
                    currentFrameY = 3;
                }

                /*
                 Down - currentFrameY = 0
                 Up - currentFrameY = 1
                 Left - currentFrameY = 2
                 Right - currentFrameY = 3
                 */
            }
        }

            public void AnimateRight(GameTime gameTime)
            {
                currentFrameY = 3;

                //If a key is pressed start the animation
                if (currentKBState != previousKBState)
                {
                    currentFrameX = 1;
                }

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                //Once <interval> time has passed, go to the next frame of animation and reset the timer
                if (timer > interval)
                {
                    currentFrameX++;

                    //if the animation reaches the end, set it back to the beginning
                    if (currentFrameX > 3)
                    {
                        currentFrameX = 0;
                    }
                    timer = 0f;
                }

            }

            public void AnimateUp(GameTime gameTime)
            {
                currentFrameY = 1;

                if (currentKBState != previousKBState)
                {
                    currentFrameX = 1;
                }

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer > interval)
                {
                    currentFrameX++;

                    if (currentFrameX > 3)
                    {
                        currentFrameX = 0;
                    }
                    timer = 0f;
                }
            }

            public void AnimateDown(GameTime gameTime)
            {
                currentFrameY = 0;

                if (currentKBState != previousKBState)
                {
                    currentFrameX = 1;
                }

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer > interval)
                {
                    currentFrameX++;

                    if (currentFrameX > 3)
                    {
                        currentFrameX = 0;
                    }
                    timer = 0f;
                }
            }

            public void AnimateLeft(GameTime gameTime)
            {
                currentFrameY = 2;

                if (currentKBState != previousKBState)
                {
                    currentFrameX = 1;
                }

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer > interval)
                {
                    currentFrameX++;

                    if (currentFrameX > 3)
                    {
                        currentFrameX = 0;
                    }
                    timer = 0f;
                }
            }
        }
    }