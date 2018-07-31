using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Honour_In_Blood
{
    public class Player
    {
        Weapon equippedWeapon;
        AnimatedSprite _sprite;
        Vector2 pos; //Store position
        public static float speed = 0.35f; //Store speed that player moves across map
        SpriteFont debugFont;
        Game1 _core;
        float elapsedTime = 0; //Control variable for speed of movement
        MouseState MS;
        KeyboardState KS;
        Texture2D deathTexture; //Store texture sheet for when player dies
        bool isAlive = true; //Determine if player is alive

        //PLAYER STATS
        private float currentHealth, maxHealth;
        private decimal healthDisplay;
        float previousHealth;

        int wSpeed, wDamage, sDefence;
        int combatSpeed, combatAttack, combatDefence;

        float baseSpeed, baseAttack, baseDefence;
        decimal baseSpeedDisp, baseAttackDisp, baseDefenceDisp;

        float currentXP, XPRemain, XPNextLevel;
        decimal currentXPDisp, XPRemainDisp, XPNextLevelDisp;

        int playerMoney, totalPlayerMoney, previousPlayerMoney;
        int playerLevel;
        public int maxLevel = 120;
        //END STATS

        //Making stats accessible from other classes whilst maintaining integrity of original variables [allowing them to remain private]
        public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
        public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
        public decimal HealthDisplay { get { return healthDisplay; } set { healthDisplay = value; } }

        public decimal CurrentXPDisplay { get { return currentXPDisp; } set { currentXPDisp = value; } }
        public decimal XPRemainDisplay { get { return XPRemainDisp; } set { XPRemainDisp = value; } }
        public decimal XPNextLevelDisplay { get { return XPNextLevelDisp; } set { XPNextLevelDisp = value; } }

        public int WSpeed { get { return wSpeed; } set { wSpeed = value; } }
        public int WDamage { get { return wDamage; } set { wDamage = value; } }
        public int SDefence { get { return sDefence; } set { sDefence = value; } }

        public SpriteFont DebugFont { get { return debugFont; } set { debugFont = value; } }

        public MouseState MState { get { return MS; } set { MS = value; } }
        public KeyboardState KState { get { return KS; } set { KS = value; } }

        public Vector2 Position { get { return pos; } set { pos = value; } }

        public int PlayerLevel { get { return playerLevel; } set { playerLevel = value; } }

        public int PlayerMoney { get { return playerMoney; } set { playerMoney = value; } }
        public int TotalPlayerMoney { get { return totalPlayerMoney; } set { totalPlayerMoney = value; } }

        public float CurrentXP { get { return currentXP; } set { currentXP = value; } }
        public float XPToNextLevel { get { return XPNextLevel; } set { XPNextLevel = value; } }

        public Weapon EquippedWeapon { get { return equippedWeapon; } set { equippedWeapon = value; } }

        public int CombatAttack { get { return combatAttack; } set { combatAttack = value; } }
        public int CombatDefence { get { return combatDefence; } set { combatDefence = value; } }
        public int CombatSpeed { get { return combatSpeed; } set { combatSpeed = value; } }
        public decimal BaseAttackDisp { get { return baseAttackDisp; } set { baseAttackDisp = value; } }
        public decimal BaseDefenceDisp { get { return baseDefenceDisp; } set { baseDefenceDisp = value; } }
        public decimal BaseSpeedDisp { get { return baseSpeedDisp; } set { baseSpeedDisp = value; } }
        //End

        public Player(AnimatedSprite sprite, Game1 core)
        {
            _sprite = sprite;
            pos = new Vector2(2, 2); //Player's starting position on map
            _core = core;
            pos.X *= Map.TILE_WIDTH; //Allow pos to be co-ordinates on the map (2,2) rather than a specific position (128, 128)
            pos.Y *= Map.TILE_HEIGHT;
        }

        public void LoadContent(ContentManager Content)
        {
            _sprite = new AnimatedSprite(Content.Load<Texture2D>("Character/char_move"), 1, 0, 64, 64); //Load character sheet
            _sprite.Position = Position;
            debugFont = Content.Load<SpriteFont>("debugFont");

            deathTexture = Content.Load<Texture2D>("Placeholders/player_death"); //Death texture

            //Set all starting values for player stats
            playerLevel = 1;
            maxHealth = 100;
            currentHealth = maxHealth;
            currentXP = 0;
            XPNextLevel = 500;
            XPRemain = XPNextLevel;
            sDefence = 0;

            equippedWeapon = _core.weapons[0]; //Default equipped weapon on start is 'hand'

            playerMoney = 0; //Player starts with no money

            totalPlayerMoney = playerMoney;
            previousPlayerMoney = playerMoney;

            currentXPDisp = (decimal)currentXP;
            XPNextLevelDisp = (decimal)XPNextLevel;
            XPRemainDisp = (decimal)XPRemain;

            //combat variables initialised to prevent errors
            combatAttack = 0;
            combatSpeed = 0;
            combatDefence = 0;

            baseAttack = 10f;
            baseDefence = 5f;
            baseSpeed = 10f;

            baseAttackDisp = (decimal)baseAttack;
            baseDefenceDisp = (decimal)baseDefence;
            baseSpeedDisp = (decimal)baseSpeed;
        }

        public void Update(GameTime gameTime)
        {
            KS = Keyboard.GetState(); //Update Key presses and Mouse position
            MS = Mouse.GetState();

            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds; //Increment the float elapsedTime by the elapsed Game Time for a reference window

            _sprite.HandleSpriteMovement(gameTime);

            if (isAlive) //Only update if your player is alive
            {
                if (KS.IsKeyDown(Keys.W)) //When this key is pressed, run player animation for that direction
                {
                    _sprite.AnimateUp(gameTime);
                    if (elapsedTime >= speed) //When this statement is fulfilled, set new player positon based off of direction pressed and reset timer for movement
                    {
                        pos.Y -= Map.TILE_HEIGHT;
                        elapsedTime = 0;
                        if (IsCollision()) //If IsCollision method returns true (player is colliding with something) reset the position to where the player was before key press
                        {
                            pos.Y += Map.TILE_HEIGHT;
                        }
                    }
                }
                else if (KS.IsKeyDown(Keys.S))
                {
                    _sprite.AnimateDown(gameTime);
                    if (elapsedTime >= speed)
                    {
                        pos.Y += Map.TILE_HEIGHT;
                        elapsedTime = 0;
                        if (IsCollision())
                        {
                            pos.Y -= Map.TILE_HEIGHT;
                        }
                    }
                }
                else if (KS.IsKeyDown(Keys.A))
                {
                    _sprite.AnimateLeft(gameTime);
                    if (elapsedTime >= speed)
                    {
                        pos.X -= Map.TILE_WIDTH;
                        elapsedTime = 0;
                        if (IsCollision())
                        {
                            pos.X += Map.TILE_HEIGHT;
                        }
                    }
                }
                else if (KS.IsKeyDown(Keys.D))
                {
                    _sprite.AnimateRight(gameTime);
                    if (elapsedTime >= speed)
                    {
                        pos.X += Map.TILE_WIDTH;
                        elapsedTime = 0;
                        if (IsCollision())
                        {
                            pos.X -= Map.TILE_HEIGHT;
                        }
                    }
                }

                currentXPDisp = Math.Round((decimal)currentXP, 0); //Round the variables for display on a screen (so that no long decimals are shown)
                XPRemainDisp = Math.Round((decimal)XPRemain, 0);
                XPNextLevelDisp = Math.Round((decimal)XPNextLevel, 0);

                baseAttackDisp = Math.Round((decimal)baseAttack, 0);
                baseDefenceDisp = Math.Round((decimal)baseDefence, 0);
                baseSpeedDisp = Math.Round((decimal)baseSpeed, 0);

                XPRemain = XPNextLevel - currentXP; //Get the difference of XPNextLevel and currentXP and store in XPRemain for use

                //LEVELING SYSTEM
                if (playerLevel < maxLevel)
                {
                    if (currentXP >= XPNextLevel) //When your XP exceeds the required XP for the next level, increase level by 1 and carry remaining XP over to the next level
                    {
                        currentXP -= XPNextLevel;
                        XPNextLevel += XPNextLevel * 0.075f; //LEVEL FORMULA
                        if (playerLevel < maxLevel) // Only level up if your level is less than maximum
                        {
                            playerLevel++;
                            baseAttack += playerLevel * 0.15f; //Base Attack increase formula
                            baseDefence += playerLevel * 0.1f; //Base Defence increase formula

                            if (currentHealth == maxHealth)
                            {
                                maxHealth += playerLevel * 2f; //Max Health increase formula
                                currentHealth = maxHealth;
                            }
                            else
                            {
                                maxHealth += playerLevel * 2f; //When your health isn't maximum, increase current health by half of the increase of maximum health (provides sustain on the battlefield)
                                currentHealth += playerLevel * 1f;
                            }
                        }
                    }
                }
                else if (playerLevel >= maxLevel) //If player reaches maximum level, currentXP will always equal XP needed for next level
                {
                    currentXP = XPNextLevel;
                    XPRemain = 0;
                }

                if (KS.IsKeyDown(Keys.G)) //Debugging key
                {
                    currentXP += 5000f;
                }

                if (KS.IsKeyDown(Keys.H)) //Debugging key
                {
                    currentHealth -= 10f;
                }

                if (KS.IsKeyDown(Keys.U)) //Debugging key
                {
                    playerMoney += 10;
                }
                if (KS.IsKeyDown(Keys.Y)) //Debugging key
                {
                    playerMoney -= 10;
                }

                healthDisplay = (decimal)Math.Round(currentHealth, 0);

                if (currentHealth >= maxHealth) //Control statement, prevent player from having health greater than the maximum
                {
                    currentHealth = maxHealth;
                }
                if (currentHealth <= 0) //When current health drops below or equal to 0, player dies
                {
                    currentHealth = 0;
                    isAlive = false;
                }

                /*
                combatAttack = (int)baseAttack + equippedWeapon.damage;
                combatSpeed = (int)baseSpeed + equippedWeapon.speed;
                */

                //MAX MONEY YOU CAN HAVE ON-HAND
                if (playerMoney > 999999)
                {
                    playerMoney = 999999;
                }
                if (playerMoney <= 0) //Control statement to prevent negative integers for money
                {
                    playerMoney = 0;
                }

                //Total money obtained formula (Only increases if you gain money)
                if (playerMoney > previousPlayerMoney)
                {
                    totalPlayerMoney += (playerMoney - previousPlayerMoney);
                }

                previousPlayerMoney = playerMoney;

                previousHealth = currentHealth;

                wSpeed = equippedWeapon.speed;
                wDamage = equippedWeapon.damage;
            }
            else if (!isAlive) //When you die, set game state to game over
            {
                _sprite.Texture = deathTexture;
                _core.gameState = Game1.GameState.GameOver;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw player on-screen
            spriteBatch.Draw(_sprite.Texture, pos, _sprite.SourceRect, Color.White, 0f, _sprite.Origin, 1.0f, SpriteEffects.None, 0); //PLAYER
        }
        public bool IsCollision() //This method is used to detect any collision between the player and environment
        {
            foreach (Rectangle rect in _core.map.collisionRect)
            {
                if (rect.X == pos.X && rect.Y == pos.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}