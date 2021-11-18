using System;
using System.Runtime.Remoting;
using System.Xml.XPath;
using SFML.System;

namespace CosmicDefender.FactoryMethod
{
    public abstract class AbstractFactory
    {
        private Entity _log;
        //TODO: нужно сделать различные конструкторы, чтобы были различные сущности
        public virtual Entity CreateEnemyShip()
        {
            Entity NewObj = new EnemyShip();
            Log(NewObj);
            return NewObj;
        }
        public virtual Entity CreatePlayerShip()
        {
            Entity NewObj = new PlayerShip(Content.getInstance().GetShip1(), new Vector2f(0, 0), 100, new SingleShot());
            Log(NewObj);
            return NewObj;
        }
        public virtual Entity CreateEnemyMiniBossShip()
        {
            Entity NewObj = new EnemyShip();
            Log(NewObj);
            return NewObj;
        }

        public virtual Entity CreateEnemyBossShip()
        {
            Entity NewObj = new EnemyShip();
            Log(NewObj);
            return NewObj;
        }
        
        public void Log(Entity NewObj)
        {
            Console.WriteLine($"Создан {NewObj.GetType()}");
        }
    }
}