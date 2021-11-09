using System;
using System.Xml.XPath;

namespace CosmicDefender
{
    public abstract class ActiveObjects : Entity
    {
        public override void Update()
        {
            
        }
        public virtual void Damage(Entity Object1, Entity Object2, int _damage)
        {
            Console.WriteLine($"Объект {Object1.GetType()} наносит урон объекту {Object2.GetType()} в размере {_damage}");
        }
    }
}