using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

            while (Window.getInstance().getWindow().IsOpen)
            {
                gameManager.Update();
                
                Content content = new Content();
                content.Load();
                
                Ship ship1 = new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot());
                //ship1.Shot();
                var ShipWithGun = new Gun2(ship1);
                ShipWithGun.Shot();
                ShipWithGun.Update();
                
                
                Ship ship2 = new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot());
                Bullet b = new Bullet();
                b.Damage(b, ship2, 30);
                
                Ship ship3 = new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot());
                Ship ship4 = new EnemyShip();
                ship4.Damage(ship4, ship3, 120);


                CompositeEnemy enemies = new CompositeEnemy();
                enemies.Add(new EnemyShip());
                enemies.Add(new EnemyShip());
                enemies.Add(new EnemyShip());
                enemies.MoveTo(new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot()));
                
                Ship ship7 = new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot());
                Bullet b2 = new Bullet();
                b.Damage(b2, ship2, 30);
                
                var ship5 = new AdapterDmgObjects(new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot()));
                Ship ship6 = new EnemyShip();
                ship5.Damage(ship5, ship6, 30);

                List<Entity> entities = new List<Entity>()
                {
                    new EnemyShip(),
                    new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot()),
                    new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot()),
                    new EnemyShip(),
                };

                IteratorEntities<Entity> ent = new IteratorEntities<Entity>(entities);
                foreach (var item in ent)
                {
                    Console.WriteLine($"{item}");
                }
                
                Window.getInstance().Update();
            }
        }
    }
}
