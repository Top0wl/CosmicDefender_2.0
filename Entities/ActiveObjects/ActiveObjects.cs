using System;
using System.Xml.XPath;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class ActiveObjects : Entity
    {
        public ActiveObjects() { }
        
        public ActiveObjects(Sprite sprite, float maxSpeed, float acceleration, string name, 
            float health) : base(sprite, maxSpeed, acceleration, name, health)
        {
            
        }

        public virtual void Damage(Entity Object1)
        {
            Object1.Health -= this.Dmg;
        }
    }
}