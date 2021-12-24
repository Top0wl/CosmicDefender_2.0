using System.Collections.Generic;
using CosmicDefender.FactoryMethod;
using SFML.System;

namespace CosmicDefender
{
    public interface ISpawn
    {
        void Spawn(AbstractFactory af);
        Vector2f SpawnPosition();
    }
}