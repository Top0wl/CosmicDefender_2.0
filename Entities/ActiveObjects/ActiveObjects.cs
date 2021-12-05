using System;
using System.Xml.XPath;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class ActiveObjects : Entity
    {
        public ActiveObjects() { }
        
        public ActiveObjects(Sprite sprite, float velocity, float acceleration, string name, 
            float health) : base(sprite, velocity, acceleration, name, health)
        {
            
        }

        public virtual void Damage(Entity Object1, Entity Object2, int _damage)
        {
            Console.WriteLine($"Объект {Object1.GetType()} наносит урон объекту {Object2.GetType()} в размере {_damage}");
        }
    }
}