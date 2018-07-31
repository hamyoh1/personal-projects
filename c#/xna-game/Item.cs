using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Honour_In_Blood
{
    public class Item //Parent class to Weapon, Armour, Consumable etc. Holds all variables that are used by all these classes
    {
        public string name { get; set; }
        public string type { get; set; }
        public string worth { get; set; }
        public Texture2D itemTexture { get; set; }
        public int X, Y, width, height;
        public Rectangle sourceRect = new Rectangle();
        public int levelReq { get; set; }
        public int itemID { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }
}