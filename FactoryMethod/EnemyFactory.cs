using System;

namespace CosmicDefender.FactoryMethod
{
    public class EnemyFactory : Factory
    {
        public override Entity createEntity()
        {
            Log();
            return new EnemyShip();
        }

        public override void Log()
        {
            Console.WriteLine($"Создан {new EnemyShip().GetType()}");
        }
    }
}