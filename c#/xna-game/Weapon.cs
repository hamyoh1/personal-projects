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
    public class Weapon : Item
    {
        Player _player;
        Game1 _core;
        public Texture2D swordInfoBack { get; set; }
        public int damage { get; set; }
        public int speed { get; set; }
        Particle rareParticle, commonParticle, legendaryParticle, lightningParticle;
        bool loopCheck = false;
        bool IsPickedUp = false;
        public bool Is2Hand { get; set; }
        bool overlayDraw = false;

        KeyboardState OldKS = Keyboard.GetState();
        KeyboardState NewKS;

        public Weapon(Player player, Game1 core)
        {
            _core = core;
            _player = player;
        }

        public void LoadContent(ContentManager Content)
        {
            //Load all particles
            commonParticle = new Particle(Content.Load<Texture2D>("Particles/common_particle"), 0, 0, 64, 64, 250f);
            rareParticle = new Particle(Content.Load<Texture2D>("Particles/particle_test1"), 0, 0, 64, 64, 100f);
            legendaryParticle = new Particle(Content.Load<Texture2D>("Particles/particle_test_legendary"), 0, 0, 64, 64, 150f);
            lightningParticle = new Particle(Content.Load<Texture2D>("Particles/lightningparticle"), 0, 0, 64, 64, 150f);

            //Load the background texture for the info box when pressing 'r' while standing on an item
            swordInfoBack = Content.Load<Texture2D>("weaponinfo_back");

            sourceRect.X *= Map.TILE_WIDTH; //Multiply position by map's tile width and height to make it so position acts as co-ordinates
            sourceRect.Y *= Map.TILE_HEIGHT;
        }

        public void Update(GameTime gameTime)
        {
            if (!IsPickedUp) //As long as the item isn't picked up, update everything[saves resources when working with larger numbers of items]
            {
                commonParticle.ParticleAnimate(gameTime);
                rareParticle.ParticleAnimate(gameTime);
                legendaryParticle.ParticleAnimate(gameTime);
                lightningParticle.ParticleAnimate(gameTime);

                UpdateInput();

                if (loopCheck) //If loopCheck is true, run PickupItem method and set loopCheck to false to prevent recursive method calls
                {
                    PickupItem();
                    loopCheck = false;
                }
            }
        }

        private void UpdateInput() //This method handles all key-presses, 'C' for pickup, 'R' for showing weapon info
        {
            NewKS = Keyboard.GetState();
            if (_player.Position.X >= sourceRect.X && _player.Position.X <= (itemTexture.Width + sourceRect.X) && _player.Position.Y <= (itemTexture.Height + sourceRect.Y) && _player.Position.Y >= sourceRect.Y)
            {
                if (NewKS.IsKeyDown(Keys.C))
                {
                    if (!OldKS.IsKeyDown(Keys.C))
                    {
                        if (_player.PlayerLevel >= levelReq)
                        {
                            loopCheck = true;
                            IsPickedUp = true;
                        }
                    }
                }
                else if (NewKS.IsKeyDown(Keys.R))
                {
                    if (!OldKS.IsKeyDown(Keys.R))
                    {
                        overlayDraw = true;
                    }
                }
                if (NewKS.IsKeyUp(Keys.R))
                {
                    if (!OldKS.IsKeyUp(Keys.R))
                    {
                        overlayDraw = false;
                    }
                }
            }
            OldKS = NewKS;
        }


        public void PickupItem() //This method uses nested 'for' loops to check inventory array for next '0' space and assigns this the value of the ID of the weapon picked up
        {
            for (int Y = 0; Y < _core.inventory.InventoryArr.GetLength(1); Y++)
            {
                for (int X = 0; X < _core.inventory.InventoryArr.GetLength(0); X++)
                {
                    int inventoryValue = (int)_core.inventory.InventoryArr.GetValue(X, Y);

                    if (inventoryValue == 0)
                    {
                        _core.inventory.InventoryArr.SetValue(itemID, X, Y);
                        return;
                    }
                    
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsPickedUp) //Draw all textures when the item is not picked up
            {
                spriteBatch.Draw(itemTexture, sourceRect, Color.White);
                if (worth == "Common")
                {
                    spriteBatch.Draw(commonParticle.Texture, sourceRect, commonParticle.SourceRect, Color.White);
                }

                else if (worth == "Rare")
                {
                    spriteBatch.Draw(rareParticle.Texture, sourceRect, rareParticle.SourceRect, Color.White);
                }

                else if (worth == "Legendary")
                {
                    if (name == "Zeus' Masterbolt")
                    {
                        spriteBatch.Draw(lightningParticle.Texture, sourceRect, lightningParticle.SourceRect, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(legendaryParticle.Texture, sourceRect, legendaryParticle.SourceRect, Color.White);
                    }
                }
            }
        }

        public void DrawOverlay(SpriteBatch spriteBatch)
        {
            if (!IsPickedUp) //Show information only if player is above level requirement
            {
                if (_player.Position.X >= sourceRect.X && _player.Position.X <= (itemTexture.Width + sourceRect.X) - 1 && _player.Position.Y <= (itemTexture.Height + sourceRect.Y) - 1 && _player.Position.Y >= sourceRect.Y)
                {
                    if (overlayDraw)
                    {
                        if (_player.PlayerLevel >= levelReq)
                        {
                            spriteBatch.Draw(swordInfoBack, new Rectangle((int)_player.Position.X + 64, (int)_player.Position.Y - 20, 250, 120), Color.White);
                            if (_player.WSpeed < speed)
                                spriteBatch.DrawString(_player.DebugFont, "Speed: " + speed, new Vector2(_player.Position.X + 90, _player.Position.Y + 60), Color.Green);
                            else if (_player.WSpeed > speed)
                                spriteBatch.DrawString(_player.DebugFont, "Speed: " + speed, new Vector2(_player.Position.X + 90, _player.Position.Y + 60), Color.Red);
                            else if (_player.WSpeed == speed)
                                spriteBatch.DrawString(_player.DebugFont, "Speed: " + speed, new Vector2(_player.Position.X + 90, _player.Position.Y + 60), Color.White);
                            if (_player.WDamage < damage)
                                spriteBatch.DrawString(_player.DebugFont, "Damage: " + damage, new Vector2(_player.Position.X + 90, _player.Position.Y + 40), Color.Green);
                            else if (_player.WDamage > damage)
                                spriteBatch.DrawString(_player.DebugFont, "Damage: " + damage, new Vector2(_player.Position.X + 90, _player.Position.Y + 40), Color.Red);
                            else if (_player.WDamage == damage)
                                spriteBatch.DrawString(_player.DebugFont, "Damage: " + damage, new Vector2(_player.Position.X + 90, _player.Position.Y + 40), Color.White);


                            spriteBatch.DrawString(_player.DebugFont, "Name: " + name, new Vector2(_player.Position.X + 90, _player.Position.Y), Color.White);
                            spriteBatch.DrawString(_player.DebugFont, "Type: " + type, new Vector2(_player.Position.X + 90, _player.Position.Y + 20), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(swordInfoBack, new Rectangle((int)_player.Position.X + 64, (int)_player.Position.Y - 20, 200, 100), Color.White);
                            spriteBatch.DrawString(_player.DebugFont, "Level required: " + levelReq, new Vector2(_player.Position.X + 90, _player.Position.Y), Color.Red);
                        }
                    }
                }
            }
        }
    }
}