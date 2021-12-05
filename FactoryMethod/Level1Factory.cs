using System;
using CosmicDefender.Builders.Builders;
using SFML.System;

namespace CosmicDefender.FactoryMethod
{
    public class Level1Factory : AbstractFactory
    {
        // public override Entity CreatePlayerShip()
        // {
        //     Entity NewObj = new PlayerShipBuilder()
        //         .SetCoords(new Vector2f(100, 100))
        //         .SetHealth(100)
        //         .SetName("PlayerShip")
        //         .SetRotation(new Vector2f(200, 200))
        //         .SetSpeed(new Vector2f(5, 5))
        //         .Build();
        //     Log(NewObj);
        //     return NewObj;
        // }
    }
}