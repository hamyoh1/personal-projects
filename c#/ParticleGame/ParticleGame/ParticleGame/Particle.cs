using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleGame
{
    public class Particle
    {
        public float _aliveTime;
        public Vector2 position;
        public int width, height, minS, maxS;
        public static Random random = new Random();
        public Color _color;
        public Vector2 _influence, _gravity;
        public float controlTimer = 100f, timer = 0f;
        public float shiftTimer = 0f;
        public string _tag = "", _tag2 = "";
        public bool _isGravityDown = false;
        public byte alphaChannel = 255;
        public float decayAmount;
        public int _ID = 0;


        public bool destroy = false;

        public Particle(string particleID, string tag, string tag2, int minSize, int maxSize, bool isGravityDown, Vector2 influence, Vector2 spawnPos, float aliveTime, Color color)
        {
            minS = minSize;
            maxS = maxSize;
            _aliveTime = aliveTime;
            _color = color;
            _influence = influence;
            _isGravityDown = isGravityDown;
            _tag = tag;
            _tag2 = tag2;

            if (_isGravityDown)
            {
                _gravity = new Vector2(0, 9.8f);
            }
            else if(!_isGravityDown)
            {
                _gravity = new Vector2(0, -9.8f);
            }


            position = spawnPos;

            width = random.Next(minS, maxS);
            height = width;
            position.X -= width / 2;
            decayAmount = (alphaChannel + 57) / _aliveTime;
        }

        public void Update(GameTime gameTime)
        {
            _color.A = alphaChannel;
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_aliveTime != 999999f)
            {
                _aliveTime--;
            }
            if (_aliveTime <= 0)
            {
                destroy = true;
            }
            
            position.Y += _gravity.Y;
            position.Y += _influence.Y;
            position.X += _influence.X;
            if (timer >= controlTimer)
            {
                if (_influence.X > 0)
                {
                    _influence.X--;
                    timer = 0f;
                }
                else if (_influence.X < 0)
                {
                    _influence.X++;
                    timer = 0f;
                }
                else{ timer = 0f; }
            }

            if (_tag == "slowshift" || _tag2 == "slowshift")
            {
                shiftTimer++;
                if (shiftTimer >= 20)
                {
                    position.X += random.Next(-1, 2);

                    shiftTimer = 0f;
                }
            }
            else if (_tag == "fastshift" || _tag2 == "fastshift")
            {
                shiftTimer++;
                if (shiftTimer >= 5)
                {
                    position.X += random.Next(-1, 2);
                    shiftTimer = 0f;
                }
            }
            if (_tag == "fade" || _tag2 == "fade")
            {
                alphaChannel-= (byte)decayAmount;
                if (alphaChannel <= decayAmount)
                {
                    alphaChannel = (byte)decayAmount;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.particleBaseTexture, new Rectangle((int)position.X, (int)position.Y, width, height), _color);
        }
    }
}