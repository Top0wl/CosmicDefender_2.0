using System;

namespace CosmicDefender
{
    public class AdapterDmgObjects : ActiveObjects
    {
        private Ship _ship;
        
        public AdapterDmgObjects(Ship ship)
        {
            _ship = ship;
        }
        
        public virtual void Damage(Entity Object1, Entity Object2, int _damage)
        {
            Console.WriteLine($"Объект {_ship.GetType()} наносит урон объекту {Object2.GetType()} в размере {_damage}");
        }
    }
}