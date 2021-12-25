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
            Entity NewObj = new EnemyShip(Content.getInstance().GetsShootShip(), 1, 0.1f, "EnemyShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(), 2, 1, 1), 
                0.2f);
            Log(NewObj);
            return NewObj;
        }
        public virtual Entity CreatePlayerShip()
        {
            Entity NewObj = new PlayerShip(Content.getInstance().GetShip1(), 2f, 0.1f, "EnemyShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 10),
                0.1f);
            Log(NewObj);
            return NewObj;
        }

        public virtual Entity CreateAsteroid()
        {
            Entity NewObj = new Asteroid(new Animation.Animation(Content.getInstance().GetsAnimAsteroid1(), 0, 0, 85,
                100, 6, 5, 0.15f, 0.4f, new Vector2f(0,0)), "Asteroid", 100);
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