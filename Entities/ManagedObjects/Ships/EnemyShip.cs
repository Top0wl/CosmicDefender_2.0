using System;
using CosmicDefender.Builders.Interfaces;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public class EnemyShip : Ship
    {
        public EnemyShip(Sprite sprite, float velocity, float acceleration, string name, float health, Gun weapon) 
            : base(sprite, velocity, acceleration, name, health, weapon)
        {
            
        }
        public override void Update(float time)
        {
            
        }
        
        #region Visiter
        public override void Visit(EnemyShip enemyShip)
        {
            //Корабли не будут наносить урон сталкиваясь между собой
        }
        public override void Visit(Bullet bullet)
        {
            Console.WriteLine($"{bullet.GetType()} посетила объект {this.GetType()} и нанёс урон");
            //Кораблю пуля должна нанести урон
        }
        public override void Accept(IEntityVisitor visitor)
        {
            visitor.Visit(this);
        }
        #endregion
    }
}