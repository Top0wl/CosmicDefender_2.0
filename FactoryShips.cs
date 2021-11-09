using System;
using System.Diagnostics;
using SFML.Graphics;
using SFML.System;
using TypeEntities = CosmicDefender.Entity.TypeEntities;

namespace CosmicDefender
{
    public class FactoryEntities
    {
        public Entity ProduceEntity(TypeEntities type)
        {
            Content content = Content.getInstance();
            switch (type)
            {
                case TypeEntities.PlayerShip_1:
                    return new PlayerShip(content.GetShip1(), new Vector2f(0, 0), 100, new SingleShot());
                //TODO: Добавить Asteroid и другие объекты
                case TypeEntities.Asteroid_1: 
                    return null;
                case TypeEntities.EnemyShip_Simple: 
                    return new EnemyShip();
                case TypeEntities.EnemyShip_Boss_Level1: 
                    return new EnemyShip();
                default: return null;
            }
        }
    }
}