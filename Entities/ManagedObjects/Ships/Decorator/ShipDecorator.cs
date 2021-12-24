using SFML.Graphics;

namespace CosmicDefender
{
    public abstract class ShipDecorator : Ship
    {
        protected Ship _ship;

        protected ShipDecorator(Sprite sprite, float maxSpeed, float acceleration, string name, float health, Gun weapon, float firingRate) :
            base(sprite, maxSpeed, acceleration, name, health, weapon, firingRate)
        {
            
        }
    }
}