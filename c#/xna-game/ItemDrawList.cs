using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Honour_In_Blood
{
    class ItemDrawList //Test class for drawing items on the map
    {
        Game1 _core;
        Weapon longsword, masterbolt;
        List<Weapon> weaponList;

        public ItemDrawList(Game1 core)
        {
            _core = core;
            longsword = _core.weapons[1];
            masterbolt = _core.weapons[4];
        }

        public void LoadContent(ContentManager Content)
        {
            longsword.sourceRect = new Rectangle(3, 2, 64, 64);
            masterbolt.sourceRect = new Rectangle(4, 2, 64, 64);

            weaponList = new List<Weapon>();
            weaponList.Add(longsword);
            weaponList.Add(masterbolt);

            foreach (Weapon wep in weaponList)
            {
                wep.LoadContent(Content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Weapon wep in weaponList)
            {
                wep.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Weapon wep in weaponList)
            {
                wep.Draw(spriteBatch);
            }
        }

        public void DrawOverlay(SpriteBatch spriteBatch)
        {
            foreach (Weapon wep in weaponList)
            {
                wep.DrawOverlay(spriteBatch);
            }
        }
    }
}