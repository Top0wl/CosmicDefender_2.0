using System;
using System.Collections.Generic;
using CosmicDefender.Controllers;
using CosmicDefender.FactoryMethod;
using SFML.System;

namespace CosmicDefender
{
    public class SpawnAstreroid : ISpawn
    {
        public void Spawn(AbstractFactory af)
        {
            Vector2f SpawnPos = SpawnPosition();
            Entity asteroid = af.CreateAsteroid();
            asteroid.Coords = new Vector2f(SpawnPos.X,SpawnPos.Y);
            
            ObjectManager.GetInstance().AddEntity(asteroid);
            Console.WriteLine("Спавним астероид");
        }

        public Vector2f SpawnPosition()
        {
            Random rnd = new Random();
            //Сверху снизу?
            int updownleftright = rnd.Next(0, 3);
            //Сверху
            if (updownleftright == 0)
            {
                int y = (int)Window.getInstance().getWindow().Size.Y;
                int x = rnd.Next(0, (int)Window.getInstance().getWindow().Size.X);
                return new Vector2f(x, y);
            }
            //Снизу
            else if (updownleftright == 1)
            {
                int y = 0;
                int x = rnd.Next(0, (int)Window.getInstance().getWindow().Size.X);
                return new Vector2f(x, y);
            }
            //Слева
            else if(updownleftright == 2)
            {
                int x = 0;
                int y = rnd.Next(0, (int)Window.getInstance().getWindow().Size.Y);
                return new Vector2f(x, y);
            }
            else if(updownleftright == 3)
            {
                int x = (int)Window.getInstance().getWindow().Size.X;
                int y = rnd.Next(0, (int)Window.getInstance().getWindow().Size.Y);
                return new Vector2f(x, y);
            }
            return new Vector2f(0, 0);
        }
    }
}