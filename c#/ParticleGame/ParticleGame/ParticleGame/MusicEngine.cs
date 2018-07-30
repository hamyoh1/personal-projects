using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleGame
{
    public class MusicEngine
    {
        KeyboardState KS, oldKS;
        Song serenity, EOL, RIL, FOE;
        int trackNo = 0;
        public List<Song> trackList = new List<Song>();
        public static SpriteFont mediaFont;

        public MusicEngine(float volume)
        {
            MediaPlayer.Volume = volume;
        }

        public void LoadContent(ContentManager Content)
        {
            serenity = Content.Load<Song>("Tracks/serenity");
            EOL = Content.Load<Song>("Tracks/essenceoflove");
            RIL = Content.Load<Song>("Tracks/realityislonely");
            FOE = Content.Load<Song>("Tracks/fieldsofelysium");
            mediaFont = Content.Load<SpriteFont>("Fonts/mediaFont");
            populateList(trackList);
            MediaPlayer.Play(trackList[trackNo]);
        }

        public void Update(GameTime gameTime)
        {
            KS = Keyboard.GetState();
            if (KS.IsKeyDown(Keys.Right) && oldKS.IsKeyUp(Keys.Right))
            {
                trackNo++;
                if (trackNo > trackList.Count - 1)
                {
                    trackNo = 0;
                }
                MediaPlayer.Stop();
                MediaPlayer.Play(trackList[trackNo]);
            }
            else if (KS.IsKeyDown(Keys.Left) && oldKS.IsKeyUp(Keys.Left))
            {
                trackNo--;
                if (trackNo < 0)
                {
                    trackNo = trackList.Count - 1;
                }
                MediaPlayer.Stop();
                MediaPlayer.Play(trackList[trackNo]);
            }

            if (KS.IsKeyDown(Keys.Space) && oldKS.IsKeyUp(Keys.Space))
            {
                if (MediaPlayer.State == MediaState.Playing)
                    MediaPlayer.Pause();
                else { MediaPlayer.Resume(); }
            }

            if (KS.IsKeyDown(Keys.Up))
            {
                MediaPlayer.Volume += 0.005f;
                Math.Floor((decimal)MediaPlayer.Volume);
            }
            else if (KS.IsKeyDown(Keys.Down))
            {
                MediaPlayer.Volume -= 0.005f;
                Math.Floor((decimal)MediaPlayer.Volume);
            }
            oldKS = KS;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(mediaFont, Convert.ToString(MediaPlayer.State), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(mediaFont, "Volume: " + Convert.ToString(Math.Round((decimal)MediaPlayer.Volume, 2) * 100), new Vector2(10, 50), Color.White);
        }

        public void populateList(List<Song> songList)
        {
            trackList.Add(serenity);
            trackList.Add(EOL);
            trackList.Add(RIL);
            trackList.Add(FOE);
        }
    }
}
