using System;
using System.Threading;
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

namespace Honour_In_Blood
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;

        GameOver gameOverScreen;
        SpriteBatch spriteBatch;
        public Player player;
        Menu menu;
        public Map map;
        AnimatedSprite sprite;
        SpriteFont debugFont;
        public Inventory inventory;
        KeyboardState oldKS;
        Weapon weapon;
        public HUD playerHUD;
        public Camera camera;
        MouseState MS;
        Texture2D mousePointer;
        Vector2 mousePos;

        public List<Item> items;
        public List<Weapon> weapons;

        public int level; //0 = Start Menu, 1 = Paused, 2 = Level 1...

        public int viewportWidth, viewportHeight;

        ItemDrawList itemTest;

        public enum GameState //Declaring all states the game can be in
        {
            StartMenu,
            Playing,
            Paused,
            Inventory,
            GameOver,
        }

        public GameState gameState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Mouse.SetPosition(0, 0); //Set mouse position to the upper left corner of the screen on startup

            graphics.IsFullScreen = true; //Set the game to play in full screen if true
            
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; //Set width and height to be equal to screen resolution
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            viewportWidth = graphics.PreferredBackBufferWidth; //Allow a public variable to be set to the window size to be accessed from other classes
            viewportHeight = graphics.PreferredBackBufferHeight;

            gameState = GameState.StartMenu; //On startup, have the game begin with the start menu
            
        }

        protected override void Initialize() //Initializes all classes and sets their parameters
        {
            player = new Player(sprite, this);
            menu = new Menu(this);
            map = new Map(this);
            inventory = new Inventory(12, 4, this, weapon, player);
            playerHUD = new HUD(player, this);
            camera = new Camera(GraphicsDevice.Viewport);
            oldKS
                = Keyboard.GetState();

            //Add all items from the .xml file database into lists to be used from within XNA
            System.IO.Stream stream = TitleContainer.OpenStream("Content\\XML_CONTENT/ItemList.xml");

            XDocument doc = XDocument.Load(stream);

            items = new List<Item>();
            weapons = new List<Weapon>();

            items = (from item in doc.Descendants("Items")
                     select new Item()
                     {

                     }).ToList();

            weapons = (from w in doc.Descendants("Weapon")
                       select new Weapon(player, this)
                       {
                           name = w.Element("Name").Value,
                           itemTexture = Content.Load<Texture2D>(w.Element("ItemTexture").Value),
                           type = w.Element("Type").Value,
                           worth = w.Element("Worth").Value,
                           levelReq = Convert.ToInt32(w.Element("LevelReq").Value),
                           itemID = Convert.ToInt32(w.Element("ItemID").Value),
                           Is2Hand = Convert.ToBoolean(w.Element("Is2Hand").Value),
                           damage = Convert.ToInt32(w.Element("Damage").Value),
                           speed = Convert.ToInt32(w.Element("Speed").Value),
                           price = Convert.ToInt32(w.Element("Price").Value),
                           description = w.Element("Description").Value
                       }).ToList();

            itemTest = new ItemDrawList(this);

            gameOverScreen = new GameOver(this, player);
            
            base.Initialize();
        }

        protected override void LoadContent() //Load all classes here, as well as mouse texture and font
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mousePointer = Content.Load<Texture2D>("mouse");
            menu.LoadContent(Content);
            player.LoadContent(Content);
            map.LoadContent(Content);
            inventory.LoadContent(Content);
            playerHUD.LoadContent(Content);
            itemTest.LoadContent(Content);
            gameOverScreen.LoadContent(Content);

            debugFont = Content.Load<SpriteFont>("debugFont");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            MS = Mouse.GetState(); //Update the mouses position
            mousePos.X = MS.X; //Store these positions into a Vector2 variable
            mousePos.Y = MS.Y;

            if (menu.exitGame == true) //When the boolean exitGame in the Menu class is true, exit the game
                this.Exit();

            inventory.Update(gameTime);
            
            base.Update(gameTime);

            UpdateInput();

            if (gameState == GameState.Playing) //Only update the player when the state of the game is Playing, saves computer resources by not updating unnecessary things
                player.Update(gameTime);

            if (gameState == GameState.StartMenu) //Only update the menu when the state of the game is StartMenu, saves computer resources
                menu.Update(gameTime);


            if (gameState == GameState.GameOver) //Only update the game over screen when the state of the game is GameOver, saves computer resources
                gameOverScreen.Update(gameTime);

            //Update all other classes
            map.Update(gameTime);
            playerHUD.Update(gameTime);
            camera.Update(gameTime, player, this);
        }

        private void UpdateInput()
        {
            KeyboardState newKS = Keyboard.GetState(); //Update keyboard input

            if (newKS.IsKeyDown(Keys.Escape) && gameState != GameState.Inventory) //If the inventory is not showing and the Escape key is pressed, exit the game
            {
                if (!oldKS.IsKeyDown(Keys.Escape))
                {
                    this.Exit();
                }
            }

            //If the StartMenu, Inventory and GameOver states are not active and the "I" key is pressed, show the inventory
            if (newKS.IsKeyDown(Keys.I) && gameState != GameState.StartMenu && gameState != GameState.Inventory && gameState != GameState.GameOver)
            {
                if (!oldKS.IsKeyDown(Keys.I))
                {
                    gameState = Game1.GameState.Inventory;
                }
            }
            //If the escape key is pressed and the inventory is showing, exit the inventory and continue the game
            else if (newKS.IsKeyDown(Keys.Escape) && gameState == GameState.Inventory)
            {
                if (!oldKS.IsKeyDown(Keys.Escape))
                {
                    gameState = Game1.GameState.Playing;
                }
            }

            oldKS = newKS; //Set previous keyboard state to current
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,camera.transform); //Draw the following classes using the camera class to centre the player
            
            if (gameState == GameState.Playing || gameState == GameState.Inventory) //Only draw these classes if the game is not showing the start menu or game over screen
            {
                map.Draw(spriteBatch);
                itemTest.Draw(spriteBatch);
                itemTest.DrawOverlay(spriteBatch);
                player.Draw(spriteBatch);
            }

            spriteBatch.End();

            spriteBatch.Begin();
            if (gameState == GameState.StartMenu) //Draw the mouse pointer and the menu if the game state is on StartMenu
            {
                menu.Draw(spriteBatch);
                spriteBatch.Draw(mousePointer, new Rectangle((int)mousePos.X, (int)mousePos.Y, mousePointer.Width, mousePointer.Height), Color.White);
            }
            if (gameState == GameState.Playing || gameState == GameState.Inventory) //Draw the player's HUD if the game is playing or inventory is shown
            {
                playerHUD.Draw(spriteBatch);
                spriteBatch.Draw(mousePointer, new Rectangle((int)mousePos.X, (int)mousePos.Y, mousePointer.Width, mousePointer.Height), Color.White);
            }
            if (gameState == GameState.Inventory) //Draw the inventory if the GameState is set to Inventory, also draw the mouse
            {
                inventory.Draw(spriteBatch);
                spriteBatch.Draw(mousePointer, new Rectangle((int)mousePos.X, (int)mousePos.Y, mousePointer.Width, mousePointer.Height), Color.White);
            }
            if (gameState == GameState.GameOver) //Draw game over screen if GameState is set to GameOver, also draw the mouse
            {
                gameOverScreen.Draw(spriteBatch);
                spriteBatch.Draw(mousePointer, new Rectangle((int)mousePos.X, (int)mousePos.Y, mousePointer.Width, mousePointer.Height), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}