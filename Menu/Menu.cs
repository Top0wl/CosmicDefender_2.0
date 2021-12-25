using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CosmicDefender.Controllers;
using CosmicDefender.FactoryMethod;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CosmicDefender.Menu
{
    public class Menu : Handlers
    {
        private static Menu _instance;
        
        private GameManager GameManager;
        
        private PlayerShipFactory af = new PlayerShipFactory();
        private BossFactory bossfactory = new BossFactory();
        private int listShips;
        private int listLevels;
        private Sprite BackGround;
        private PlayerShip SelectShip;
        private GameLevel SelectLevel;
        public bool IsOpen { get; set; }
        public List<MenuRectLevels> RectLevels = new List<MenuRectLevels>();
        public List<MenuRectButtons> RectButtons = new List<MenuRectButtons>();
        public List<MenuRectShips> RectShips = new List<MenuRectShips>();
        
        public Menu()
        {
            this.GameManager = GameManager.GetInstance();
            this.SelectShip = af.CreateShip1();
            this.SelectShip._sprite.Position = new Vector2f(640, 360);
            this.SelectShip._sprite.Scale = new Vector2f(1f, 1f);
            this.SelectLevel = new GameLevel(Content.getInstance().GetBackgroundLevel6(), 100, 100, new Level1Factory(), bossfactory.CreateBoss1());
            this.IsOpen = true;
            this.listLevels = 1;
            this.listShips = 1;
            this.BackGround = new Sprite(Content.getInstance().GetBackgroundLevel1());
            this.LoadRectLevels1();
            this.LoadRectButtons();
            this.LoadRectShips1();
        }
        public static Menu GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Menu();
            }
            return _instance;
        }
        public void LoadRectButtons()
        {
            this.RectButtons.Add( new MenuRectButtons(Content.getInstance().GetMenuButton(), "ButtonPlay",
                new Vector2f(560f, 600f)));
            this.RectButtons.Add(new MenuRectButtons(Content.getInstance().GetListUpButton(), "ButtonUp", new Vector2f(1100, 35)));
            this.RectButtons.Add(new MenuRectButtons(Content.getInstance().GetListDownButton(), "ButtonDown", new Vector2f(1100, 685)));
        }
        public void LoadRectLevels1()
        {
            this.RectLevels.Clear();
            this.RectLevels.Add(new MenuRectLevels(Content.getInstance().GetLevel1(), "Level1", new Vector2f(20, 75), 
                new GameLevel(Content.getInstance().GetBackgroundLevel1(), 100, 100, new Level1Factory(), bossfactory.CreateBoss1())));
            this.RectLevels.Add(new MenuRectLevels(Content.getInstance().GetLevel2(), "Level2", new Vector2f(20, 175), 
                new GameLevel(Content.getInstance().GetBackgroundLevel2(), 100, 100, new Level1Factory(), bossfactory.CreateBoss1())));;
            this.RectLevels.Add(new MenuRectLevels(Content.getInstance().GetLevel3(), "Level3", new Vector2f(20, 275), 
                new GameLevel(Content.getInstance().GetBackgroundLevel3(), 100, 100, new Level1Factory(), bossfactory.CreateBoss1())));
            this.RectLevels.Add(new MenuRectLevels(Content.getInstance().GetLevel4(), "Level4", new Vector2f(20, 375), 
                new GameLevel(Content.getInstance().GetBackgroundLevel4(), 100, 100, new Level1Factory(), bossfactory.CreateBoss1())));
            this.RectLevels.Add(new MenuRectLevels(Content.getInstance().GetLevel5(), "Level5", new Vector2f(20, 475), 
                new GameLevel(Content.getInstance().GetBackgroundLevel5(), 100, 100, new Level1Factory(), bossfactory.CreateBoss1())));
            this.RectLevels.Add(new MenuRectLevels(Content.getInstance().GetLevel6(), "Level6", new Vector2f(20, 575), 
                new GameLevel(Content.getInstance().GetBackgroundLevel6(), 100, 100, new Level1Factory(), bossfactory.CreateBoss1())));
        }
        public void LoadRectShips1()
        {
            this.RectShips.Clear();
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip1_lock(),Content.getInstance().GetShip1() , "Ship1", new Vector2f(1000, 75), af.CreateShip1()));
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip2_lock(),Content.getInstance().GetShip2() , "Ship2", new Vector2f(1000, 175), af.CreateShip2()));
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip3_lock(),Content.getInstance().GetShip3() , "Ship3", new Vector2f(1000, 275), af.CreateShip3()));
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip4_lock(),Content.getInstance().GetShip4() , "Ship4", new Vector2f(1000, 375), af.CreateShip4()));
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip5_lock(),Content.getInstance().GetShip5() , "Ship5", new Vector2f(1000, 475), af.CreateShip5()));
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip6_lock(),Content.getInstance().GetShip6() , "Ship6", new Vector2f(1000, 575), af.CreateShip6()));
        }
        public void LoadRectShips2()
        {
            this.RectShips.Clear();
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip7_lock(),Content.getInstance().GetShip7() , "Ship7", new Vector2f(1000, 75), af.CreateShip7()));
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip8_lock(),Content.getInstance().GetShip8() , "Ship8", new Vector2f(1000, 175), af.CreateShip8()));
            this.RectShips.Add(new MenuRectShips(Content.getInstance().GetShip9_lock(),Content.getInstance().GetShip9() , "Ship9", new Vector2f(1000, 275), af.CreateShip9()));
        }
        public void Update()
        {
            if (listLevels == 1) LoadRectLevels1();
            //if (listShips == 1) LoadRectShips1(); else LoadRectShips2();
            foreach (MenuRectShips RectShip in this.RectShips.ToList())
            {
                if (Contains(RectShip.SpriteRect, Mouse.GetPosition(Window.getInstance().getWindow()).X, Mouse.GetPosition(Window.getInstance().getWindow()).Y))
                {
                    RectShip.SpriteRect.Scale = new Vector2f(1.05f, 1.05f);
                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        SelectShip = RectShip.Ship;
                        SelectShip._sprite.Position = new Vector2f(640, 360);
                        SelectShip._sprite.Scale = new Vector2f(1f, 1f);
                    }
                }
                else
                { 
                    RectShip.SpriteRect.Scale = new Vector2f(1.0f, 1.0f);
                } 
            }
            
            foreach (MenuRectButtons RectButtons in this.RectButtons.ToList())
            {
                if (Contains(RectButtons.SpriteRect, Mouse.GetPosition(Window.getInstance().getWindow()).X,
                    Mouse.GetPosition(Window.getInstance().getWindow()).Y))
                {
                    //Program.Window.Draw(RectButtons.SpriteRect);
                    if (RectButtons.Name == "ButtonUp" || RectButtons.Name == "ButtonDown")
                    {
                        RectButtons.SpriteRect.Color = Color.Red;
                    }
                    else
                    {
                        RectButtons.SpriteRect.Color = new Color(0, 100, 255);
                    }

                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        //Событие что нажалось в меню
                        //Если нажалось кнопка смены листа то
                        if (RectButtons.Name == "ButtonUp")
                        {
                            listShips = 1;
                            LoadRectShips1();
                        }
                        if (RectButtons.Name == "ButtonDown")
                        {
                            listShips = 2;
                            LoadRectShips2();
                        }
                        if (RectButtons.Name == "ButtonPlay")
                        {
                            SelectLevel.PlayerShip = SelectShip;
                            GameManager.SetLevel(SelectLevel);
                            this.IsOpen = false;
                            SelectShip._sprite.Scale = new Vector2f(0.4f, 0.4f);
                            ObjectManager.GetInstance().AddEntity(SelectShip);
                        }
                    }
                }
                else RectButtons.SpriteRect.Color = Content.getInstance().GetColorButtonUp().Color;
            }

            foreach (MenuRectLevels RectLevels in this.RectLevels.ToList())
            {
                if (Contains(RectLevels.SpriteRect, Mouse.GetPosition(Window.getInstance().getWindow()).X,
                    Mouse.GetPosition(Window.getInstance().getWindow()).Y))
                {
                    RectLevels.SpriteRect.Scale = new Vector2f(1.05f, 1.05f);
                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        SelectLevel = RectLevels.Level;
                        BackGround = SelectLevel._sprite;
                    }
                }
                else
                {
                    //RectLevels.SpriteRect.Color = Program.content.GetColorButtonUp().Color;
                    RectLevels.SpriteRect.Scale = new Vector2f(1.0f, 1.0f);
                    //RectLevels.SpriteRect.Position = new Vector2f(RectLevels.SpriteRect.Position.X + 10f, RectLevels.SpriteRect.Position.Y);
                }
            }

            Draw();
        }

        public void Draw()
        {
            Window.getInstance().getWindow().Draw(this.BackGround);
            Window.getInstance().getWindow().Draw(Content.getInstance().GetMenuLevels());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetMenuShips());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetMenuTable());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetCircle1());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetCircle2());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetCircle3());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetCircle4());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetMenuButton());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetTextPlay());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetListUpButton());
            Window.getInstance().getWindow().Draw(Content.getInstance().GetListDownButton());
            Window.getInstance().getWindow().Draw(SelectShip._sprite);
            foreach (var rectLevel in RectLevels)
            {
                Window.getInstance().getWindow().Draw(rectLevel.SpriteRect);
            }
            foreach (var rectShip in RectShips)
            {
                Window.getInstance().getWindow().Draw(rectShip.SpriteRect);
            }
        }
        public bool Contains(Sprite sprite, int x, int y)
        {
            int num = (int)Math.Min(sprite.Position.X, sprite.Position.X + sprite.Texture.Size.X);
            int num2 = (int)Math.Max(sprite.Position.X, sprite.Position.X + sprite.Texture.Size.X);
            int num3 = (int)Math.Min(sprite.Position.Y, sprite.Position.Y + sprite.Texture.Size.Y);
            int num4 = (int)Math.Max(sprite.Position.Y, sprite.Position.Y + sprite.Texture.Size.Y);
            return ((x >= num) && ((x < num2) && ((y >= num3) && (y < num4))));
        }
    }
}