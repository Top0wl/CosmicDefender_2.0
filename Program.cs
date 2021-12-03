using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicDefender.FactoryMethod;


namespace CosmicDefender
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            GameManager gameManager = new GameManager();
            
            #region Singleton
            Window window = Window.getInstance();
            Window window2 = Window.getInstance();
            if (window == window2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            #endregion
            
            Content content = new Content();

            //Ship Player2 = new PlayerShip();

            //Создаём пушку
            Gun gun = new Gun(new SingleShot());
            //Обшиваем эту пушку траекторией
            gun = new Trajectory(gun);
            //Создаём игрока и ему присваиваем пушку
            //Ship Player = new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, gun);



            while (Window.getInstance().getWindow().IsOpen)
            {
                gameManager.Update();
                
                //.Update();
                //FactoryEntities fE = new FactoryEntities();
                //Entity player = fE.ProduceEntity(Entity.TypeEntities.PlayerShip_1);
                //Console.WriteLine($"Создан объект типа {player.GetType()}");
                
                Window.getInstance().Update();
            }
        }
    }
}
