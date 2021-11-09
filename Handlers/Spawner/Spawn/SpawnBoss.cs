using System;
using System.Collections.Generic;

namespace CosmicDefender
{
    public class SpawnBoss : ISpawn
    {
        public void Spawn(List<Entity> entities)
        {
            entities.Add(new EnemyShip());
            Console.WriteLine("Спавним босса");
        }
    }
}