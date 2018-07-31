using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Honour_In_Blood
{
    class Menu
    {
        Game1 _core;

        //Declaring texture, rectangle, position and song variables here
        Texture2D start, exit, start_h, exit_h, start_state, exit_state, menu_back, title, stars1_1, stars1_2, stars2_1, stars2_2, stars3_1, stars3_2, stars4_1, stars4_2;
        Rectangle startRect, exitRect, titleRect;
        Vector2 mousePos, stars1_1Pos, stars1_2Pos, stars2_1Pos, stars2_2Pos, stars3_1Pos, stars3_2Pos, stars4_1Pos, stars4_2Pos;
        bool isSongPlaying;
        Song bgMusic;

        //DEBUG STUFF
        SpriteFont debugFont;

        public bool exitGame = false;

        //WINDOW SIZE
        int viewportWidth, viewportHeight;

        public Menu(Game1 game)
        {
            _core = game;

            viewportWidth = _core.viewportWidth;
            viewportHeight = _core.viewportHeight;

            //Setting position of the buttons to be relative to the window size to maintain proportion
            titleRect = new Rectangle(((viewportWidth / 2) - 452), (viewportHeight / 6), 904, 92);
            startRect = new Rectangle(((viewportWidth / 2) - 102), (viewportHeight / 2) - (viewportHeight / 6), 204, 92);
            exitRect = new Rectangle(((viewportWidth / 2) - 82), ((viewportHeight / 2) + 92), 164, 92);
            mousePos = new Vector2(0, 0); //Initialise mouse position to upper-left corner of screen

            //Setting stars' initial positions
            stars1_1Pos = new Vector2(0, 0);
            stars1_2Pos = new Vector2(viewportWidth, 0);
            stars2_1Pos = new Vector2(0, 0);
            stars2_2Pos = new Vector2(viewportWidth, 0);
            stars3_1Pos = new Vector2(0, 0);
            stars3_2Pos = new Vector2(viewportWidth, 0);
            stars4_1Pos = new Vector2(0, 0);
            stars4_2Pos = new Vector2(viewportWidth, 0);

            isSongPlaying = false;

        }
        public void LoadContent(ContentManager Content)
        {
            //All buttons, their highlighted texture and other menu textures loaded here
            start = Content.Load<Texture2D>("Menu/Buttons/start");
            start_h = Content.Load<Texture2D>("Menu/Buttons/start_h");
            exit = Content.Load<Texture2D>("Menu/Buttons/exit");
            exit_h = Content.Load<Texture2D>("Menu/Buttons/exit_h");
            debugFont = Content.Load<SpriteFont>("debugFont");
            menu_back = Content.Load<Texture2D>("Menu/Background/black");
            title = Content.Load<Texture2D>("Menu/Buttons/title");
            exit_state = Content.Load<Texture2D>("Menu/Buttons/exit");
            start_state = Content.Load<Texture2D>("Menu/Buttons/start");

            //STARS SHOWN ON SCREEN ON MAIN MENU LOADED HERE
            stars1_1 = Content.Load<Texture2D>("Menu/Background/stars1");
            stars1_2 = Content.Load<Texture2D>("Menu/Background/stars1");
            stars2_1 = Content.Load<Texture2D>("Menu/Background/stars2");
            stars2_2 = Content.Load<Texture2D>("Menu/Background/stars2");
            stars3_1 = Content.Load<Texture2D>("Menu/Background/stars3");
            stars3_2 = Content.Load<Texture2D>("Menu/Background/stars3");
            stars4_1 = Content.Load<Texture2D>("Menu/Background/stars4");
            stars4_2 = Content.Load<Texture2D>("Menu/Background/stars4");

            bgMusic = Content.Load<Song>("Music/menu");
        }
        public void Update(GameTime gameTime)
        {
            //Speeds that each star texture moves across the screen
            stars1_1Pos.X -= 3f;
            stars1_2Pos.X -= 3f;
            stars2_1Pos.X -= 5f;
            stars2_2Pos.X -= 5f;
            stars3_1Pos.X -= 1f;
            stars3_2Pos.X -= 1f;
            stars4_1Pos.X -= 2f;
            stars4_2Pos.X -= 2f;

            //Repeats star texture once it reaches the end of the screen
            if ((stars1_1Pos.X + viewportWidth) <= 0)
                stars1_1Pos.X = viewportWidth;
            if ((stars1_2Pos.X + viewportWidth) <= 0)
                stars1_2Pos.X = viewportWidth;
            if ((stars2_1Pos.X + viewportWidth) <= 0)
                stars2_1Pos.X = viewportWidth;
            if ((stars2_2Pos.X + viewportWidth) <= 0)
                stars2_2Pos.X = viewportWidth;
            if ((stars3_1Pos.X + viewportWidth) <= 0)
                stars3_1Pos.X = viewportWidth;
            if ((stars3_2Pos.X + viewportWidth) <= 0)
                stars3_2Pos.X = viewportWidth;
            if ((stars4_1Pos.X + viewportWidth) <= 0)
                stars4_1Pos.X = viewportWidth;
            if ((stars4_2Pos.X + viewportWidth) <= 0)
                stars4_2Pos.X = viewportWidth;

            MouseState MS = Mouse.GetState(); //Get the mouse position

            if (MS.Y >= startRect.Top && MS.Y <= startRect.Bottom && MS.X >= startRect.Left && MS.X <= startRect.Right) //If mouse is hovering over the start button, highlight it
            {
                if (MS.LeftButton == ButtonState.Pressed) //If the left mouse button is pressed, start the game
                {
                    _core.gameState = Game1.GameState.Playing;
                }
                start_state = start_h;
            }
            else if (MS.Y >= exitRect.Top && MS.Y <= exitRect.Bottom && MS.X >= exitRect.Left && MS.X <= exitRect.Right) //If mouse is hovering over the exit button, highlight it
            {
                if (MS.LeftButton == ButtonState.Pressed) //If the left mouse button is pressed, exit the game
                {
                    exitGame = true;
                }
                exit_state = exit_h;
            }
            else
            {
                start_state = start;
                exit_state = exit;
            }

            mousePos.X = MS.X; //Store mouse position in a vector2 variable
            mousePos.Y = MS.Y;

            if (_core.gameState == Game1.GameState.StartMenu) //Only play music when the start menu is playing
            {
                if (!isSongPlaying)//Control if statement to loop music
                {
                    MediaPlayer.Play(bgMusic);
                    MediaPlayer.Volume = 0.75f;
                    isSongPlaying = true;
                }

                if (MediaPlayer.State == MediaState.Stopped) //Conditional if statement to make sure song doesn't stop playing
                {
                    isSongPlaying = false;
                }
            }
            else
            {
                MediaPlayer.Stop();
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //BACKGROUND
            spriteBatch.Draw(menu_back, new Rectangle(0, 0, viewportWidth, viewportHeight), Color.White);

            //STARS
            spriteBatch.Draw(stars1_1, new Rectangle((int)stars1_1Pos.X, (int)stars1_1Pos.Y, viewportWidth, viewportHeight), Color.White);
            spriteBatch.Draw(stars1_2, new Rectangle((int)stars1_2Pos.X, (int)stars1_2Pos.Y, viewportWidth, viewportHeight), Color.White);
            spriteBatch.Draw(stars2_1, new Rectangle((int)stars2_1Pos.X, (int)stars2_1Pos.Y, viewportWidth, viewportHeight), Color.White);
            spriteBatch.Draw(stars2_2, new Rectangle((int)stars2_2Pos.X, (int)stars2_2Pos.Y, viewportWidth, viewportHeight), Color.White);
            spriteBatch.Draw(stars3_1, new Rectangle((int)stars3_1Pos.X, (int)stars3_1Pos.Y, viewportWidth, viewportHeight), Color.White);
            spriteBatch.Draw(stars3_2, new Rectangle((int)stars3_2Pos.X, (int)stars3_2Pos.Y, viewportWidth, viewportHeight), Color.White);
            spriteBatch.Draw(stars4_1, new Rectangle((int)stars4_1Pos.X, (int)stars4_1Pos.Y, viewportWidth, viewportHeight), Color.White);
            spriteBatch.Draw(stars4_2, new Rectangle((int)stars4_2Pos.X, (int)stars4_2Pos.Y, viewportWidth, viewportHeight), Color.White);

            //BUTTONS
            spriteBatch.Draw(start_state, startRect, Color.White);
            spriteBatch.Draw(exit_state, exitRect, Color.White);

            //TITLE
            spriteBatch.Draw(title, titleRect, Color.White);
        }
    }
}