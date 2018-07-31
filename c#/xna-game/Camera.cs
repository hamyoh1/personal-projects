using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Honour_In_Blood
{
    public class Camera
    {
        public Matrix transform;
        Viewport view;
        public Vector2 centre;

        public Camera(Viewport viewport)
        {
            view = viewport;
        }

        public void Update(GameTime gameTime, Player player, Game1 core)
        {
            //Centre camera on the player
            centre = new Vector2((player.Position.X + (32) - (core.viewportWidth / 2)), (player.Position.Y + (32) - (core.viewportHeight / 2)));
            transform = Matrix.CreateScale(new Vector3(1,1,0)) *
                Matrix.CreateTranslation(new Vector3(-centre.X,-centre.Y,0));
        }
    }
}