using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Xml.Linq;

namespace ParticleGame
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static Random random = new Random();
        MusicEngine ME;
        MouseState MS, oldMS;

        List<Particle> particleList;
        List<Particle> typesOfParticles;
        public static Texture2D particleBaseTexture;
        float timer = 0f, timerMax = 0f;
        int particleMax = 10000;
        char alpBetGam = 'a';
        int vA = 1, vB = 0;
        int particleSelection = 0, maxIDs = 5;
        string selectedParticle;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            IsMouseVisible = true;
            Window.Title = "Particle Engine v" + vA + "." + vB + alpBetGam;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ME = new MusicEngine(.1f);
            ME.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            particleList = new List<Particle>();
            particleBaseTexture = Content.Load<Texture2D>("Images/particleBaseTexture");
            MS = Mouse.GetState();
            oldMS = MS;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            MS=Mouse.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.C))
                particleList.Clear();
            if (MS.ScrollWheelValue > oldMS.ScrollWheelValue)
            {
                particleSelection++;
                if (particleSelection > maxIDs)
                {
                    particleSelection = 0;
                }
            }
            else if (MS.ScrollWheelValue < oldMS.ScrollWheelValue)
            {
                particleSelection--;
                if (particleSelection < 0)
                {
                    particleSelection = maxIDs;
                }
            }

            if (particleSelection == 0)
            {
                selectedParticle = "Fire";
            }
            else if (particleSelection == 1)
            {
                selectedParticle = "Water";
            }
            else if (particleSelection == 2)
            {
                selectedParticle = "Snow";
            }
            else if (particleSelection == 3)
            {
                selectedParticle = "Ice";
            }
            else if (particleSelection == 4)
            {
                selectedParticle = "Wood";
            }
            else
            {
                selectedParticle = "Nothing";
            }
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer >= timerMax)
            {
                if (particleList.Count < particleMax)
                {
                    if (MS.LeftButton == ButtonState.Pressed)
                    {
                        ParticleDraw(particleSelection);
                    }
                    SnowParticle();
                }
            }
            foreach (Particle particle in particleList.ToList())
            {
                particle.Update(gameTime);
                if (particle.destroy)
                {
                    particleList.Remove(particle);
                }
                if (particle.position.Y >= GraphicsDevice.Viewport.Height)
                {
                    if (particle._color.A > particle.decayAmount)
                    {
                        particle._aliveTime++;
                        
                        particle.position.Y = GraphicsDevice.Viewport.Height - particle.height;
                    }
                    else
                    {
                        particle.destroy = true;
                    }
                }
            }
            if (particleList.Count + 50 >= particleMax)
            {
                particleList[0].destroy = true;
            }
            ME.Update(gameTime);
            oldMS = MS;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            foreach (Particle particle in particleList)
            {
                particle.Draw(spriteBatch);
            }
            ME.Draw(spriteBatch);
            spriteBatch.DrawString(MusicEngine.mediaFont, "Count: " + particleList.Count, new Vector2(10, 100), Color.White);
            spriteBatch.DrawString(MusicEngine.mediaFont, selectedParticle, new Vector2(10, 150), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ParticleDraw(int selectionID)
        {
            if (selectionID == 0) //FIRE
            {
                particleList.Add(new Particle("fire", "fastshift", "fade", 1, 10, false, new Vector2(random.Next(-2, 3), 6f), new Vector2(MS.X, MS.Y), 75f, new Color(255, 0, 0))); //fire
                particleList.Add(new Particle("fire", "fastshift", "fade", 1, 10, false, new Vector2(random.Next(-2, 3), 6f), new Vector2(MS.X, MS.Y), 50f, new Color(255, 0, 0))); //fire
                particleList.Add(new Particle("smoke", "fastshift", "fade", 5, 12, false, new Vector2(random.Next(-2, 3), 4f), new Vector2(MS.X, MS.Y), 100f, new Color(50, 50, 50))); //smoke
                particleList.Add(new Particle("light", "fastshift", "fade", 7, 15, false, new Vector2(random.Next(-1, 2), random.Next(8, 11)), new Vector2(MS.X, MS.Y), 20f, new Color(255, 255, 0))); //light
            }
            else if (selectionID == 1) //WATER
            {
                int i = random.Next(50, 255);
                for (int x = 0; x < 3; x++)
                {
                    particleList.Add(new Particle("water", "fastshift", null, 1, 7, true, new Vector2(random.Next(-2, 3), 3f), new Vector2(MS.X, MS.Y), 100f, new Color(0, 0, i)));
                }
            }
            else if (selectionID == 2) //SNOW
            {
                int i = random.Next(50, 255);
                for (int x = 0; x < 3; x++)
                {
                    particleList.Add(new Particle("snow", "fastshift", null, 1, 7, true, new Vector2(random.Next(-2, 3), 0), new Vector2(MS.X, MS.Y), 100f, new Color(i, i, i)));
                }
            }
            else if (selectionID == 3) //ICE
            {
                particleList.Add(new Particle("ice", null, null, 15, 15, true, new Vector2(0, -9.8f), new Vector2(MS.X, MS.Y), 999999f, new Color(75, 75, 255)));
            }
            else if (selectionID == 4) //WOOD
            {
                particleList.Add(new Particle("wood", null, null, 15, 15, true, new Vector2(0, -9.8f), new Vector2(MS.X, MS.Y), 999999f, new Color(174, 103, 44)));
            }
        }
        public void SnowParticle()
        {
            int i = random.Next(50, 255);
            particleList.Add(new Particle("snow", "slowshift", "fade", 1, 7, true, new Vector2(random.Next(-1, 2), random.Next(-3, 2)), new Vector2(random.Next(0, GraphicsDevice.Viewport.Width), 0), random.Next(50, 150), new Color(i, i, i)));
            particleList.Add(new Particle("snow", "slowshift", "fade", 1, 7, true, new Vector2(random.Next(-1, 2), random.Next(-3, 2)), new Vector2(random.Next(0, GraphicsDevice.Viewport.Width), 0), random.Next(50, 150), new Color(i, i, i)));
            particleList.Add(new Particle("snow", "slowshift", "fade", 1, 7, true, new Vector2(random.Next(-1, 2), random.Next(-3, 2)), new Vector2(random.Next(0, GraphicsDevice.Viewport.Width), 0), random.Next(50, 150), new Color(i, i, i)));
            particleList.Add(new Particle("snow", "slowshift", "fade", 1, 7, true, new Vector2(random.Next(-1, 2), random.Next(-3, 2)), new Vector2(random.Next(0, GraphicsDevice.Viewport.Width), 0), random.Next(50, 150), new Color(i, i, i)));
        }
    }
}