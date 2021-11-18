using SFML.System;

namespace CosmicDefender.FactoryMethod
{
    public class Level1Factory : AbstractFactory
    {
        public override Entity CreatePlayerShip()
        { 
            Entity NewObj = new PlayerShip(Content.getInstance().GetShip1(), new Vector2f(0, 0), 100, new MultiShot());
            Log(NewObj);
            return NewObj;
        }
    }
}