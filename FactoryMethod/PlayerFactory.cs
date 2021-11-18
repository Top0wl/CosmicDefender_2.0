using System;
using SFML.System;

namespace CosmicDefender.FactoryMethod
{
    public class PlayerFactory : Factory
    {
        public override Entity createEntity()
        {
            Log();
            return new PlayerShip(Content.getInstance().GetShip1(), new Vector2f(0, 0), 100, new SingleShot());
        }

        public override void Log()
        {
            Console.WriteLine($"Создан {new PlayerShip(Content.getInstance().GetShip1(), new Vector2f(0, 0), 100, new SingleShot()).GetType()}");
        }
    }
}