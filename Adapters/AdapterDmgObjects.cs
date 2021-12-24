using System;
using SFML.Graphics;

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
        public override void Update(float time)
        {
            
        }
        public override void Collide(Entity ent1, Entity ent2)
        {
            
        }
    }
}