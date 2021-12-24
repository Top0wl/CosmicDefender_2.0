using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class ManagedObjects : Entity
    {
        protected ManagedObjects(Sprite sprite, float maxSpeed, float acceleration, string name, float health) 
            : base(sprite, maxSpeed, acceleration, name, health)
        {
            
        }
    }
}