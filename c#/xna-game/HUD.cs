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
    public class HUD
    {
        //Variable declaration
        SpriteFont debugFont;
        Game1 _core;
        Player _player;
        Texture2D healthBar, barDepleted, EXPBar, barBack, moneyBar, manaBar, staminaBar, moneyIcon;
        Rectangle healthRect, barRect, EXPRect, barRect2, barBackRect, moneyRect, manaRect, staminaRect, barRect3, barRect4;
        Rectangle healthSource, EXPSource;
        float healthWidth, EXPWidth;

        MouseState MS, newMS;
        bool loopCheck = false;
        public bool drawStats = false;
        bool statsOpen = false;

        Texture2D statsBack, handSlot;
        Rectangle statsRect, handRect, statsRect2, statsSource, statsSelect;

        //barRect = healthBar, barRect2 = EXPBar, barRect3 = manaBar, barRect4 = staminaBar

        public HUD(Player player, Game1 core)
        {
            _player = player;
            _core = core;
        }

        public void LoadContent(ContentManager Content)
        {
            //Load textures for all bars, slots and other hud textures
            healthBar = Content.Load<Texture2D>("HUD/Stats/healthbar");
            barDepleted = Content.Load<Texture2D>("HUD/Stats/bar_depleted");
            EXPBar = Content.Load<Texture2D>("HUD/Stats/expbar");
            barBack = Content.Load<Texture2D>("HUD/Backs/box_frame");
            moneyBar = Content.Load<Texture2D>("HUD/Stats/moneybar");
            manaBar = Content.Load<Texture2D>("HUD/Stats/manabar");
            staminaBar = Content.Load<Texture2D>("HUD/Stats/staminabar");
            moneyIcon = Content.Load<Texture2D>("HUD/coin");
            statsBack = Content.Load<Texture2D>("HUD/Backs/stats_tp_r");
            handSlot = Content.Load<Texture2D>("Inventory/inventory_slot2");

            //Set the rectangles for all textures to store their positions on-screen, all sizes relative to window size to maintain readability across any machine
            EXPRect = new Rectangle(((_core.viewportWidth / 2) - ((_core.viewportWidth - (_core.viewportWidth / 5)) / 2)), (_core.viewportHeight - EXPBar.Height), _core.viewportWidth - (_core.viewportWidth / 5), EXPBar.Height);
            EXPSource = new Rectangle(0, 0, EXPBar.Width, EXPBar.Height);

            barRect = new Rectangle(_core.viewportWidth - barBack.Width + 19, 12, healthBar.Width, healthBar.Height);
            barRect2 = new Rectangle(((_core.viewportWidth / 2) - ((_core.viewportWidth - (_core.viewportWidth / 5)) / 2)), (_core.viewportHeight - EXPBar.Height), _core.viewportWidth - (_core.viewportWidth / 5), EXPBar.Height);
            barRect3 = new Rectangle(_core.viewportWidth - barBack.Width + 19, 38, manaBar.Width, manaBar.Height);
            barRect4 = new Rectangle(_core.viewportWidth - barBack.Width + 19, 64, staminaBar.Width, staminaBar.Height);

            barBackRect = new Rectangle(_core.viewportWidth - barBack.Width, 0, barBack.Width, barBack.Height);

            healthRect = new Rectangle(_core.viewportWidth - barBack.Width + 19, 12, healthBar.Width, healthBar.Height);
            healthSource = new Rectangle(0, 0, healthBar.Width, healthBar.Height);
            manaRect = new Rectangle(_core.viewportWidth - barBack.Width + 19, 38, manaBar.Width, manaBar.Height);
            staminaRect = new Rectangle(_core.viewportWidth - barBack.Width + 19, 64, staminaBar.Width, staminaBar.Height);

            moneyRect = new Rectangle(_core.viewportWidth - barBack.Width + 124, 92, moneyBar.Width, moneyBar.Height);

            statsRect = new Rectangle(_core.viewportWidth - barBack.Width + 62, barBack.Height - 3, statsBack.Width, statsBack.Height);
            statsRect2 = new Rectangle(_core.viewportWidth - barBack.Width + 62, barBack.Height - 3, statsBack.Width, statsBack.Height);

            statsSource = new Rectangle(0, 0, 188, 35);

            statsSelect = new Rectangle(statsRect2.X, statsRect2.Y, 188, 35);

            handRect = new Rectangle(_core.viewportWidth - barBack.Width - 91, 0, 93, 93);

            debugFont = Content.Load<SpriteFont>("debugFont");
            _core.inventory.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            MS = newMS;
            newMS = Mouse.GetState();

            healthWidth = (_player.CurrentHealth / _player.MaxHealth) * barDepleted.Width; //Set width of the health bar texture to be the percentage of health remaining, with 100% being full size
            EXPWidth = (_player.CurrentXP / _player.XPToNextLevel) * barRect2.Width; //Same principle as health bar
            healthRect.Width = (int)healthWidth;
            healthSource.Width = (int)healthWidth;
            EXPRect.Width = (int)EXPWidth;
            EXPSource.Width = (int)EXPWidth;

            if (statsSelect.Contains(newMS.X, newMS.Y))
            {
                if (newMS.LeftButton == ButtonState.Pressed && MS.LeftButton == ButtonState.Released)
                {
                    if (statsOpen)
                    {
                        statsOpen = false;
                    }
                    else
                    {
                        statsOpen = true;
                    }
                }
            }

            if (statsOpen)
            {
                statsSource = new Rectangle(0, 0, statsBack.Width, statsBack.Height);
            }
            else if (!statsOpen)
            {
                statsSource = new Rectangle(0, 0, statsSelect.Width, statsSelect.Height);
            }

            if (handRect.Contains(MS.X, MS.Y)) //If the player is hovering over the currently equipped weapon slot run through this statement
            {
                if (newMS.RightButton == ButtonState.Pressed && MS.RightButton == ButtonState.Released) //Detect if right button is click, if so, set loopCheck to true
                {
                    loopCheck = true;
                }
            }

            if (loopCheck) //When loopCheck is true, run the Unequip method and set loopCheck to false to prevent repetitive looping
            {
                Unequip();
                loopCheck = false;
            }
            statsRect2.Height = statsSource.Height;
        }

        public void Unequip() //This method runs a check on the inventory array and detects the first 0 that is available and sets this space to be equal to the unequipped weapon's ID
        {
            foreach (Weapon wep in _core.weapons)
            {
                if (_player.EquippedWeapon.itemID == wep.itemID && _player.EquippedWeapon.itemID != 1) //Prevents the unequip of the default 'hand' weapon
                {
                    for (int y = 0; y < _core.inventory.InventoryArr.GetLength(1); y++)
                    {
                        for (int x = 0; x < _core.inventory.InventoryArr.GetLength(0); x++)
                        {
                            int inventoryIndex = (int)_core.inventory.InventoryArr.GetValue(x, y);
                            if (inventoryIndex == 0)
                            {
                                _core.inventory.InventoryArr[x, y] = wep.itemID;
                                _player.EquippedWeapon = _core.weapons[0];
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) //Draws all items onto the HUD including values of stats
        {
            spriteBatch.Draw(barBack, barBackRect, new Rectangle(0,0,barBack.Width, barBack.Height), Color.White);
            spriteBatch.Draw(barDepleted, barRect, Color.White);
            spriteBatch.Draw(healthBar, healthRect, healthSource, Color.White);

            //MANA AND STAMINA BARS ARE NON-FUNCTIONAL DUE THEIR INCOMPLETE ADDITION TO THE GAME
            spriteBatch.Draw(manaBar, manaRect, Color.White);
            spriteBatch.Draw(staminaBar, staminaRect, Color.White);
            //
            spriteBatch.Draw(barDepleted, barRect2, new Rectangle(0, 0, 1, 1), Color.White);
            spriteBatch.Draw(moneyBar, moneyRect, Color.White);
            spriteBatch.Draw(moneyIcon, new Rectangle(moneyRect.X + 90, moneyRect.Y, moneyIcon.Width, moneyIcon.Height), Color.White);
            spriteBatch.Draw(EXPBar, EXPRect, EXPSource, Color.White);
            spriteBatch.DrawString(debugFont, _player.CurrentXPDisplay + "/" + _player.XPNextLevelDisplay, new Vector2((_core.viewportWidth / 2) - ((debugFont.MeasureString(_player.CurrentXPDisplay + "/" + _player.XPNextLevelDisplay).X) / 2), _core.viewportHeight - debugFont.MeasureString("A").Y + 6), Color.White);
            spriteBatch.DrawString(debugFont, _player.HealthDisplay + "/" + _player.MaxHealth, new Vector2(_core.viewportWidth - barBack.Width + 19 + (healthBar.Width / 2) - (debugFont.MeasureString(_player.HealthDisplay + "/" + _player.MaxHealth).X / 2), 12), Color.White);
            spriteBatch.DrawString(debugFont, Convert.ToString(_player.PlayerMoney), new Vector2(_core.viewportWidth - barBack.Width + 212 - (debugFont.MeasureString(""+_player.PlayerMoney).X), 90), Color.White);
            spriteBatch.Draw(statsBack, statsRect2, statsSource, Color.White);

            if (handRect.Contains(MS.X, MS.Y)) //When mouse is hovering over equip slot, show the stats of the equipped weapon
            {
                if (_core.gameState == Game1.GameState.Inventory)
                {
                    drawStats = true;
                }
            }
            else
            {
                drawStats = false;
            }
            //Draw Player's stats

            if (statsOpen)
            {
                spriteBatch.DrawString(debugFont, "ATK: " + (_player.BaseAttackDisp + _player.EquippedWeapon.damage) + " (+" + _player.EquippedWeapon.damage + ")", new Vector2((statsRect.X + statsRect.Width) - (statsRect.Width / 2) - (debugFont.MeasureString("ATK: " + (_player.BaseAttackDisp + _player.EquippedWeapon.damage) + " (+" + _player.WDamage + ")").X / 2), statsRect.Y + 2 * (statsRect.Height / 6)), Color.White);

                //FIX LINE BELOW (MATHS OF DEFENCE NOT COMPLETE[DEFENSIVE ITEMS YET TO BE IMPLEMENTED INTO GAME])!
                spriteBatch.DrawString(debugFont, "DEF: " + _player.BaseDefenceDisp + " (+" + _player.SDefence + ")", new Vector2((statsRect.X + statsRect.Width) - (statsRect.Width / 2) - (debugFont.MeasureString("DEF: " + _player.BaseDefenceDisp + " (+" + _player.SDefence + ")").X / 2), statsRect.Y + 3 * (statsRect.Height / 6)), Color.White);
                spriteBatch.DrawString(debugFont, "LVL: " + _player.PlayerLevel + "/" + _player.maxLevel, new Vector2((statsRect.X + statsRect.Width) - (statsRect.Width / 2) - (debugFont.MeasureString("LVL: " + _player.PlayerLevel + "/" + _player.maxLevel).X / 2), statsRect.Y + (statsRect.Height / 6)), Color.White);
                spriteBatch.DrawString(debugFont, "SPD: " + (_player.BaseSpeedDisp + _player.EquippedWeapon.speed) + " (+" + _player.EquippedWeapon.speed + ")", new Vector2((statsRect.X + statsRect.Width) - (statsRect.Width / 2) - (debugFont.MeasureString("SPD: " + (_player.BaseSpeedDisp + _player.EquippedWeapon.speed) + " (+" + _player.EquippedWeapon.speed + ")").X / 2), (statsRect.Y) + 4 * (statsRect.Height / 6)), Color.White);
                spriteBatch.DrawString(debugFont, "XP Remain: " + (_player.XPNextLevelDisplay - _player.CurrentXPDisplay), new Vector2(statsRect.X + statsRect.Width - (statsRect.Width / 2) - (debugFont.MeasureString("XP Remain: " + (_player.XPNextLevelDisplay - _player.CurrentXPDisplay)).X / 2), statsRect.Y + 5 * (statsRect.Height / 6)), Color.White);
            }
            spriteBatch.Draw(handSlot, handRect, Color.White);
            spriteBatch.Draw(_player.EquippedWeapon.itemTexture, handRect, Color.White);
        }
    }
}