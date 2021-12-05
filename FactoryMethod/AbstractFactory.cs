using System;
using System.Runtime.Remoting;
using System.Xml.XPath;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender.FactoryMethod
{
    public abstract class AbstractFactory
    {
        private Entity _log;
        //TODO: нужно сделать различные конструкторы, чтобы были различные сущности
        public virtual Entity CreateEnemyShip()
        {
            Entity NewObj = new EnemyShip(Content.getInstance().GetShip2(), 0.1f, 0.1f, "EnemyShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(), 5, 5));
            Log(NewObj);
            return NewObj;
        }
        public virtual Entity CreatePlayerShip()
        {
            Entity NewObj = new PlayerShip(Content.getInstance().GetShip1(), 2, 0.1f, "EnemyShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),1,1),
                2f, 1f);
            Log(NewObj);
            return NewObj;
        }
        // public virtual Entity CreateEnemyMiniBossShip()
        // {
        //     Entity NewObj = new EnemyShip();
        //     Log(NewObj);
        //     return NewObj;
        // }
        //
        // public virtual Entity CreateEnemyBossShip()
        // {
        //     Entity NewObj = new EnemyShip();
        //     Log(NewObj);
        //     return NewObj;
        // }
        public void Log(Entity NewObj)
        {
            Console.WriteLine($"Создан {NewObj.GetType()}");
        }
    }
}