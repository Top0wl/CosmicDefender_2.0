using System;
using System.Collections.Generic;
using SFML.System;

namespace CosmicDefender
{
    public class SpawnPlayer : ISpawn
    {
        public void Spawn(List<Entity> entities)
        {
            //TODO: временный костыль, чтобы посмотреть работоспособность
            Content content = new Content();
            content.Load();
            //
            PlayerShip ship = new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot());
            Console.WriteLine("Спавним корабль игрока");
            entities.Add(ship);
        }
    }
}