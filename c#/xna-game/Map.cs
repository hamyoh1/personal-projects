using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Honour_In_Blood
{
    public class Map
    {
        Game1 _core;
        public static int TILE_WIDTH = 64; //This size cannot change, static size of a tile
        public static int TILE_HEIGHT = 64;
        Foliage tree1, grass1;
        public List<Rectangle> collisionRect;
        List<Foliage> foliageList;
        SpriteFont debugFont;
        Texture2D rectTexture;
        public List<Weapon> mapWeapons;

        int tileStartX, tileStartY;

        //Tile Map Variables
        Texture2D brick, grass, special, water;

        public int[,] map = { //Entire map stored in an array, different maps can be loaded using different arrays
                        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, }, 
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 1, 1, 1, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 1, 1, 1, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 1, 1, 1, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 1, 4, 4, 4, 4, 1, 1, 1, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 1, 4, 1, 1, 4, 1, 1, 1, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 1, 4, 4, 4, 4, 1, 1, 1, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 1, 4, 4, 4, 4, 1, 1, 1, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, },
                        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },

                     };

        public int[] collisionValues = { 1, 4,}; //Holds all values of tiles that have collision property
        

        public Map(Game1 core)
        {
            _core = core;
        }

        public void LoadContent(ContentManager Content)
        {
            //Load all tiles here
            brick = Content.Load<Texture2D>("Map/Tiles/brick");
            grass = Content.Load<Texture2D>("Map/Tiles/grass");
            special = Content.Load<Texture2D>("Map/Tiles/special");
            water = Content.Load<Texture2D>("Map/Tiles/water");

            //Load all foliage here
            tree1 = new Foliage(Content.Load<Texture2D>("Map/Foliage/Tree1"), 6, 14, 2, 2, false);
            grass1 = new Foliage(Content.Load<Texture2D>("Map/Foliage/Grass2"), 10, 3, 1, 1, true);

            //Debug Texture/Font
            rectTexture = Content.Load<Texture2D>("rectangleOverlay");
            debugFont = Content.Load<SpriteFont>("debugFont");
            //

            //Initialise Lists
            collisionRect = new List<Rectangle>();
            foliageList = new List<Foliage>();
            mapWeapons = new List<Weapon>();

            tileStartX = (int)_core.camera.transform.Translation.X; //Set the corner tile
            tileStartY = (int)_core.camera.transform.Translation.Y;


            //ADDING RECTANGLES TO LIST OF TILES THAT COLLIDE
            for (int indexX = 0; indexX < map.GetLength(0); indexX++)
            {
                for (int indexY = 0; indexY < map.GetLength(1); indexY++)
                {
                    int mapValue = (int)map.GetValue(indexX, indexY);
                    for (int collisionCheck = 0; collisionCheck < collisionValues.GetLength(0); collisionCheck++)
                    {
                        if (mapValue == (int)collisionValues.GetValue(collisionCheck))
                        {
                            collisionRect.Add(new Rectangle(indexX * TILE_WIDTH, indexY * TILE_HEIGHT, TILE_WIDTH, TILE_HEIGHT));
                        }
                    }
                }
            }

            //ADDING FOLIAGE INTO THE LIST TO BE DRAWN IN-GAME
            foliageList.Add(new Foliage(tree1.foliageSprite, 6, 14, 2, 2, false));
            foliageList.Add(new Foliage(grass1.foliageSprite, 5, 15, 1, 1, true));


            //ADDING RECTANGLES TO FOLIAGE THAT COLLIDES USING NESTED 'FOR' LOOPS
            foreach (Foliage foliage in foliageList)
            {
                if (!foliage.passable) //Adds only if the foliage is not passable
                {
                    for (int scaleXSort = 0; scaleXSort < foliage.scaleX; scaleXSort++)
                    {
                        for (int scaleYSort = 0; scaleYSort < foliage.scaleY; scaleYSort++)
                        {
                            collisionRect.Add(new Rectangle(foliage.tileX * TILE_WIDTH + (TILE_WIDTH * scaleXSort), foliage.tileY * TILE_HEIGHT + (TILE_HEIGHT * scaleYSort), foliage.foliageSprite.Width, foliage.foliageSprite.Height));
                        }
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int indexX = 0; indexX < map.GetLength(0); indexX++) //Using nested 'for' loops, checks map array and stores value in 'mapValue' variable and updates for every index of the array
            {
                for (int indexY = 0; indexY < map.GetLength(1); indexY++)
                {
                    int mapValue = (int)map.GetValue(indexX, indexY); //Checks this value and draw corresponding tile ID onto the screen

                    if (mapValue == 0)
                    {

                    }
                    //Fix tile system, currently inefficient, using lists of object 'Tile' a more efficient method of drawing can be done
                    else if (mapValue == 1)
                    {
                        spriteBatch.Draw(brick, new Rectangle(indexX * TILE_WIDTH - tileStartX , indexY * TILE_HEIGHT - tileStartY, TILE_WIDTH, TILE_HEIGHT), Color.White);
                    }
                    else if (mapValue == 2)
                    {
                        spriteBatch.Draw(grass, new Rectangle(indexX * TILE_WIDTH - tileStartX, indexY * TILE_HEIGHT - tileStartY, TILE_WIDTH, TILE_HEIGHT), Color.White);
                    }
                    else if (mapValue == 3)
                    {
                        spriteBatch.Draw(special, new Rectangle(indexX * TILE_WIDTH - tileStartX, indexY * TILE_HEIGHT - tileStartY, TILE_WIDTH, TILE_HEIGHT), Color.White);
                    }
                    else if (mapValue == 4)
                    {
                        spriteBatch.Draw(water, new Rectangle(indexX * TILE_WIDTH - tileStartX, indexY * TILE_HEIGHT - tileStartY, TILE_WIDTH, TILE_HEIGHT), Color.White);
                    }
                    else { }
                }
            }

            foreach (Foliage foliage in foliageList) //Draws all foliage stored in List in location set when the foliage was initially loaded
            {
                spriteBatch.Draw(foliage.foliageSprite, new Rectangle(foliage.tileX * TILE_WIDTH, foliage.tileY * TILE_HEIGHT, foliage.foliageSprite.Width * foliage.scaleX, foliage.foliageSprite.Height * foliage.scaleY), Color.White);
            }

            foreach (Weapon wep in mapWeapons) //Draws all weapons from list mapWeapons onto the map
            {
                spriteBatch.Draw(wep.itemTexture, new Rectangle(wep.X, wep.Y, wep.width, wep.height), wep.sourceRect, Color.White);
            }

            //DEBUG - When "B" key is held down, shows an overlay on tiles that collide
            if (_core.player.KState.IsKeyDown(Keys.B))
            {

                foreach (Rectangle rect in collisionRect)
                {
                    spriteBatch.Draw(rectTexture, new Rectangle(rect.X, rect.Y, rect.Width, rect.Height), Color.White);
                }
            }
            else if (_core.player.KState.IsKeyUp(Keys.B))
            {

            }
        }
    }
}