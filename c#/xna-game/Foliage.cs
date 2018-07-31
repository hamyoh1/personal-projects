using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Honour_In_Blood
{
    class Foliage
    {
        public Texture2D foliageSprite; //Foliage texture
        public int tileX, tileY, scaleX, scaleY; //Tile location and scale of the foliage
        public bool passable; //If false, player can't walk through the foliage
        public Rectangle sourceRect;

        public Foliage(Texture2D sprite, int TileX, int TileY, int ScaleX, int ScaleY, bool IsPassable)
        {
            foliageSprite = sprite;
            tileX = TileX;
            tileY = TileY;
            scaleX = ScaleX;
            scaleY = ScaleY;
            passable = IsPassable;

            sourceRect.X = tileX;
            sourceRect.Y = tileY;
            sourceRect.Width = foliageSprite.Width * scaleX;
            sourceRect.Height = foliageSprite.Height * scaleY;
        }

        public void LoadContent(ContentManager Content)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(foliageSprite, sourceRect, Color.White);
        }
    }
}