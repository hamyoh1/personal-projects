
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
    public class Inventory
    {
        public int iSpaceX, iSpaceY; //Size of inventory
        int[,] inventory; //Array to store all items ID's into to serve as the player's 'inventory'
        int[,] equipment = {
                               {0, 0, 0, 0, 0, }, //index[0,0] = Helm, index[0,1] = Gauntlet, index[0,2] = Body, index[0,3] = Shield, index[0,4] = Legs
                           };

        public Texture2D inventorySlot, inventoryBack;
        Game1 _core;
        SpriteFont debugFont;
        Weapon _item;
        MouseState MS, newMS;
        List<Rectangle> slotList; //List of Rectangles of each slot in the inventory except the armour slots
        List<Rectangle> armourList; //List of Rectangles of each armour slot
        int indexCheckX = 0;
        int indexCheckY = 0;
        bool equip = false;
        Player _player;
        Weapon playerPreviousEquipped;

        public Rectangle infoRect;

        Texture2D debugOverlay;

        public int[,] InventoryArr
        {
            get { return inventory; }
            set { inventory = value; }
        }

        public int[,] EquipmentArr
        {
            get { return equipment; }
            set { equipment = value; }
        }

        public int ISpaceX
        {
            get { return iSpaceX; }
            set { iSpaceX = value; }
        }

        public int ISpaceY
        {
            get { return iSpaceY; }
            set { iSpaceY = value; }
        }

        public Inventory(int inventorySpaceX, int inventorySpaceY, Game1 core, Weapon item, Player player)
        {
            this.iSpaceX = inventorySpaceX;
            this.iSpaceY = inventorySpaceY;
            _core = core;
            _item = item;
            _player = player;
        }

        public void LoadContent(ContentManager Content)
        {
            inventory = new int[iSpaceX, iSpaceY];
            //Loading textures for inventory
            inventorySlot = Content.Load<Texture2D>("Inventory/inventory_slot2");
            inventoryBack = Content.Load<Texture2D>("Inventory/inventory_back2");

            debugFont = Content.Load<SpriteFont>("debugFont");

            inventory[0, 0] = 2; //For debugging purposes, the inventory is pre-loaded with weapons
            inventory[1, 0] = 3;
            inventory[3, 0] = 4;
            inventory[4, 0] = 2;

            slotList = new List<Rectangle>();
            armourList = new List<Rectangle>();

            infoRect = new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + 320, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + 15, 248, 177);

            playerPreviousEquipped = _core.weapons[0]; //Initialise currently equipped weapon to the hand on start

            debugOverlay = Content.Load<Texture2D>("rectangleOverlay");

            //Using nested 'for' loops to add a rectangle for each slot, this way no matter what size inventory is defined this will not disrupt the loop
            for (int Y = 0; Y < iSpaceY; Y++)
            {
                for (int X = 0; X < iSpaceX; X++)
                {
                    slotList.Add(new Rectangle(X * inventorySlot.Width + (_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)), Y * inventorySlot.Height + (_core.viewportHeight / 2) - (inventorySlot.Height * (iSpaceY / 3)) + inventorySlot.Height, inventorySlot.Width, inventorySlot.Height));
                }
            }

            //Armour slots had to be manually added as these slots are static and the amount of them will never change

            armourList.Add(new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY), inventorySlot.Width, inventorySlot.Height));
            armourList.Add(new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)), (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height, inventorySlot.Width, inventorySlot.Height));
            armourList.Add(new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height, inventorySlot.Width, inventorySlot.Height));
            armourList.Add(new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width * 2, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height, inventorySlot.Width, inventorySlot.Height));
            armourList.Add(new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height * 2, inventorySlot.Width, inventorySlot.Height));

            /* NOTE[Shows which slots correspond with which piece of armour]:
             * armourList index:
             * [0] = Helm
             * [1] = Gauntlet
             * [2] = Body
             * [3] = Shield
             * [4] = Legs
             * */

            foreach (Weapon wep in _core.weapons)
            {
                wep.LoadContent(Content); //Load all weapons in XML database through the core game class
            }
        }

        public void Update(GameTime gameTime)
        {
            MS = newMS; //Update old Mouse position
            newMS = Mouse.GetState(); //Get new mouse position

            foreach (Weapon wep in _core.weapons)
            {
                wep.Update(gameTime); //Update all weapons in XML database through core game class
            }
            foreach (Rectangle rect in slotList)
            {
                if (rect.Contains(MS.X, MS.Y)) //Check if mouse is hovering over any inventory slots
                {
                    if (MS.RightButton == ButtonState.Released && newMS.RightButton == ButtonState.Pressed) //If mouse is hovering over a slot and the right mouse button is pressed, set equip to true
                    {
                        equip = true;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw inventory back texture
            spriteBatch.Draw(inventoryBack, new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)), (_core.viewportHeight / 2)-(inventorySlot.Height * iSpaceY), iSpaceX * inventorySlot.Width, iSpaceY * inventorySlot.Height), Color.White);
            
            //Using nested 'for' loops the inventory slots are drawn individually
            for (int Y = 0; Y < iSpaceY; Y++)
            {
                for (int X = 0; X < iSpaceX; X++)
                {
                    spriteBatch.Draw(inventorySlot, new Rectangle(X * inventorySlot.Width + (_core.viewportWidth/2)-(inventorySlot.Width*(iSpaceX/2)), Y * inventorySlot.Height + (_core.viewportHeight/2)-(inventorySlot.Height*(iSpaceY/3)) +inventorySlot.Height, inventorySlot.Width, inventorySlot.Height), Color.White);
                    
                    foreach (Weapon wep in _core.weapons)
                    {
                        if (InventoryArr[X, Y] == wep.itemID) //Draw all weapons stored in the inventory array, determined by the integers corresponding with the weapon's ID
                        {
                            spriteBatch.Draw(wep.itemTexture, new Rectangle((X * inventorySlot.Width) + (_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)), (Y * inventorySlot.Height) + (_core.viewportHeight / 2) - (inventorySlot.Height * (iSpaceY / 3)) + inventorySlot.Height, inventorySlot.Width, inventorySlot.Height), Color.White);
                        }
                    }
                }
            }

            //Checking if mouse is hovering over an inventory slot, if it is show stats
            foreach (Rectangle rect in slotList)
            {
                if (rect.Contains(MS.X, MS.Y))
                {
                    indexCheckX = slotList.IndexOf(rect);

                    for (int YCheck = 0; YCheck < iSpaceY; YCheck++) //Algorithm to prevent 'out of range' error for X-index of inventory array, allows conversion of 1D slotList array to 2D inventory array
                    {
                        if (indexCheckX >= iSpaceX * YCheck && indexCheckX < iSpaceX * (YCheck + 1))
                        {
                            indexCheckY = YCheck;
                            indexCheckX -= iSpaceX * YCheck;
                        }
                    }

                    foreach (Weapon wep in _core.weapons)
                    {
                        if (InventoryArr[indexCheckX, indexCheckY] == wep.itemID)
                        {
                            spriteBatch.DrawString(debugFont, "Name: " + wep.name, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + (infoRect.Height / 8)), Color.Black);
                            spriteBatch.DrawString(debugFont, "ATK: " + wep.damage, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 2 * (infoRect.Height / 8)), Color.Black);
                            spriteBatch.DrawString(debugFont, "SPD: " + wep.speed, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 3 * (infoRect.Height / 8)), Color.Black);
                            spriteBatch.DrawString(debugFont, "Rarity: " + wep.worth, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 4 * (infoRect.Height / 8)), Color.Black);
                            spriteBatch.DrawString(debugFont, "Type: " + wep.type, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 5 * (infoRect.Height / 8)), Color.Black);
                            spriteBatch.DrawString(debugFont, "Level Required: " + wep.levelReq, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 6 * (infoRect.Height / 8)), Color.Black);
                            if (equip) //If a weapon is equipped run through this statement
                            {
                                if (_player.EquippedWeapon != _core.weapons[0]) //If the player weapon is not a hand
                                {
                                    if (_player.PlayerLevel >= wep.levelReq) //If player's level is equal to or greater than weapons level requirement
                                    {
                                        playerPreviousEquipped = _player.EquippedWeapon;
                                        _player.EquippedWeapon = wep; //Equip the weapon
                                        InventoryArr[indexCheckX, indexCheckY] = playerPreviousEquipped.itemID; //Place previously equipped weapon into the next free slot in inventory
                                        equip = false;
                                    }
                                }
                                else
                                {
                                    if (_player.PlayerLevel >= wep.levelReq) //If no real weapon is equipped and the player has his hand 'equipped', simply equip the weapon from the inventory and set the slot to be empty
                                    {
                                        _player.EquippedWeapon = wep;
                                        InventoryArr[indexCheckX, indexCheckY] = 0;
                                        equip = false;
                                    }
                                }
                            }

                        }

                    }
                    }
                }
            if (_core.playerHUD.drawStats)
            {
                spriteBatch.DrawString(debugFont, "Name: " + _player.EquippedWeapon.name, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + (infoRect.Height / 8)), Color.Black);
                spriteBatch.DrawString(debugFont, "ATK: " + _player.EquippedWeapon.damage, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 2 * (infoRect.Height / 8)), Color.Black);
                spriteBatch.DrawString(debugFont, "SPD: " + _player.EquippedWeapon.speed, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 3 * (infoRect.Height / 8)), Color.Black);
                spriteBatch.DrawString(debugFont, "Rarity: " + _player.EquippedWeapon.worth, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 4 * (infoRect.Height / 8)), Color.Black);
                spriteBatch.DrawString(debugFont, "Type: " + _player.EquippedWeapon.type, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 5 * (infoRect.Height / 8)), Color.Black);
                spriteBatch.DrawString(debugFont, "Level Required: " + _player.EquippedWeapon.levelReq, new Vector2(infoRect.X + (infoRect.Width / 12), infoRect.Y + 6 * (infoRect.Height / 8)), Color.Black);
            }
            //HELM SLOT
            spriteBatch.Draw(inventorySlot, new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY), inventorySlot.Width, inventorySlot.Height), Color.White);
            spriteBatch.DrawString(debugFont, " " + equipment[0, 0], new Vector2((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY)), Color.White);

            //GAUNTLET SLOT
            spriteBatch.Draw(inventorySlot, new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)), (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height, inventorySlot.Width, inventorySlot.Height), Color.White);
            spriteBatch.DrawString(debugFont, " " + equipment[0, 1], new Vector2((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)), (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height), Color.White);

            //BODY SLOT
            spriteBatch.Draw(inventorySlot, new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height, inventorySlot.Width, inventorySlot.Height), Color.White);
            spriteBatch.DrawString(debugFont, " " + equipment[0, 2], new Vector2((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height), Color.White);

            //SHIELD SLOT
            spriteBatch.Draw(inventorySlot, new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width * 2, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height, inventorySlot.Width, inventorySlot.Height), Color.White);
            spriteBatch.DrawString(debugFont, " " + equipment[0, 2], new Vector2((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width * 2, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height), Color.White);

            //LEGS SLOT
            spriteBatch.Draw(inventorySlot, new Rectangle((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height * 2, inventorySlot.Width, inventorySlot.Height), Color.White);
            spriteBatch.DrawString(debugFont, " " + equipment[0, 2], new Vector2((_core.viewportWidth / 2) - (inventorySlot.Width * (iSpaceX / 2)) + inventorySlot.Width, (_core.viewportHeight / 2) - (inventorySlot.Height * iSpaceY) + inventorySlot.Height * 2), Color.White);
        }
    }
}