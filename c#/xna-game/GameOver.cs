using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Honour_In_Blood
{
    public class GameOver
    {
        Game1 _core;
        Player _player;
        bool isSongPlaying;
        Song bgMusic;
        Video gameOver;
        VideoPlayer vidPlayer;
        Texture2D vidTexture;
        Rectangle vidRectangle;
        int controlInt;
        SpriteFont gameOverFont;
        int spacing;
        int finalScore = 0;

        public GameOver(Game1 core, Player player)
        {
            isSongPlaying = false;
            _core = core;
            _player = player;
        }

        public void LoadContent(ContentManager Content)
        {
            //Load all content for game over screen[video, music, font]
            bgMusic = Content.Load<Song>("Music/gameOver");
            gameOver = Content.Load<Video>("Video/gameOverScreen");
            gameOverFont = Content.Load<SpriteFont>("Font/gameOverFont");
            vidPlayer = new VideoPlayer();
            spacing = _core.viewportHeight / 22; //Set spacing of the lines of stats
            vidRectangle = new Rectangle(0, 0, _core.viewportWidth, _core.viewportHeight); //Set the video size
            controlInt = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (_core.gameState == Game1.GameState.GameOver)
            {
                if (!isSongPlaying) //Control statement to loop music
                    {
                        MediaPlayer.Play(bgMusic);
                        MediaPlayer.Volume = 0.75f;
                        isSongPlaying = true;
                        MediaPlayer.IsRepeating = true;
                    }
                    if (controlInt <= 0) //Prevent video from playing multiple times
                    {
                        vidPlayer.Play(gameOver);
                        controlInt++;

                        //Score formula created by me [check log for formula]
                        finalScore = (int)Math.Round(((_player.PlayerLevel*_player.PlayerLevel)*(_player.maxLevel))+(_player.PlayerLevel * _player.maxLevel * ((_player.CurrentXP + 1)/_player.XPToNextLevel)) + _player.TotalPlayerMoney,0);
                    }

                    vidTexture = vidPlayer.GetTexture(); //Stream video as a series of textures constantly updated, store in vidTexture, draw vidTexture to screen
            }
            else { isSongPlaying = false; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw player's final stats onto the screen and the video
            spriteBatch.Draw(vidTexture, vidRectangle, Color.White);
            spriteBatch.DrawString(gameOverFont, "Stats:", new Vector2((_core.viewportWidth / 2) - (gameOverFont.MeasureString("Stats:").X /2), _core.viewportHeight / 2), Color.White);
            spriteBatch.DrawString(gameOverFont, "Player Level: " + _player.PlayerLevel + " / " + _player.maxLevel, new Vector2((_core.viewportWidth / 2) - (gameOverFont.MeasureString("Player Level: " + _player.PlayerLevel + " / " + _player.maxLevel).X / 2), (_core.viewportHeight / 2) + spacing), Color.White);
            spriteBatch.DrawString(gameOverFont, "XP: " + _player.CurrentXPDisplay + " / " + _player.XPNextLevelDisplay, new Vector2((_core.viewportWidth / 2) - (gameOverFont.MeasureString("XP: " + _player.CurrentXPDisplay + " / " + _player.XPNextLevelDisplay).X / 2), (_core.viewportHeight / 2) + (spacing * 2)), Color.White);
            spriteBatch.DrawString(gameOverFont, "XP To Next Level: " + (_player.XPNextLevelDisplay - _player.CurrentXPDisplay), new Vector2((_core.viewportWidth / 2) - (gameOverFont.MeasureString("XP To Next Level: " + (_player.XPNextLevelDisplay - _player.CurrentXPDisplay)).X / 2), (_core.viewportHeight / 2) + (spacing * 3)), Color.White);
            
            spriteBatch.DrawString(gameOverFont, "Total Money Obtained: " + _player.TotalPlayerMoney + " AUR", new Vector2((_core.viewportWidth / 2) - (gameOverFont.MeasureString("Total Money Obtained: " + _player.TotalPlayerMoney + " AUR").X / 2), (_core.viewportHeight / 2) + (spacing * 4)), Color.White);
            spriteBatch.DrawString(gameOverFont, "Score: " + finalScore, new Vector2((_core.viewportWidth / 2) - (gameOverFont.MeasureString("Score: " + finalScore).X / 2), (_core.viewportHeight / 2) + (spacing * 5)), Color.White);
        }
    }
}