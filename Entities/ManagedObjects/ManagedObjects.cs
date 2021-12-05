using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class ManagedObjects : Entity
    {
        protected ManagedObjects(Sprite sprite, float velocity, float acceleration, string name, float health) 
            : base(sprite, velocity, acceleration, name, health)
        {
            
        }
    }
}