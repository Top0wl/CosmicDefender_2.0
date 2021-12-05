using SFML.Graphics;

namespace CosmicDefender
{
    public abstract class ShipDecorator : Ship
    {
        protected Ship _ship;

        protected ShipDecorator(Sprite sprite, float velocity, float acceleration, string name, float health, Gun weapon) :
            base(sprite, velocity, acceleration, name, health, weapon)
        {
            
        }
    }
}