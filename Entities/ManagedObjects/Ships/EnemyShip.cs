using System;
using System.ComponentModel.Design;
using CosmicDefender.Builders.Interfaces;
using CosmicDefender.Controllers;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CosmicDefender
{
    public class EnemyShip : Ship
    {
        public float DistantShot = 500;
        public EnemyShip(Sprite sprite, float maxSpeed, float acceleration, string name, float health, Gun weapon, float firingRate) 
            : base(sprite, maxSpeed, acceleration, name, health, weapon, firingRate)
        {
            
        }
        public override void Update(float time)
        {
            Force();
            if (CheckDistant() < DistantShot  && CheckFireRating())
            {
                Weapon.Shot();
                Timer.Restart();
            }
            base.Update(time);
        }

        private float CheckDistant()
        {
            //Находим игрока
            Entity target = ObjectManager.GetInstance().GetPlayer();
            //Находим вектор между мышью и кораблём
            Vector2f Rotate = target.Coords - Coords;

            return LengthVector(Rotate);
        }

        public override void UpdateRotation()
        {
            //Находим игрока
            Entity target = ObjectManager.GetInstance().GetPlayer();
            //Находим вектор между мышью и кораблём
            Vector2f Rotate = target.Coords - Coords;
            //Преобразуем
            float rotat = (float)((Math.Atan2(Rotate.Y, Rotate.X) * 180 / Math.PI) + 90);
            //Поворачиваем спрайт
            _sprite.Rotation = rotat;
            //Обновляем поворот корабля
            Rotation = Rotate;
        }
        
        
        
        #region Visiter
        public override void Visit(EnemyShip enemyShip)
        {
            //Корабли не будут наносить урон сталкиваясь между собой
        }
        public override void Visit(Bullet bullet)
        {
            Console.WriteLine($"{bullet.GetType()} посетила объект {this.GetType()} и нанёс урон");
            bullet.DisableCollide();
            bullet.Damage(this);
            ObjectManager.GetInstance().AddEntity(Content.getInstance().GetExplosive1(bullet.Coords, 1f, 0.2f));
            ObjectManager.GetInstance().DeleteEntity(bullet);
        }
        public override void Visit(PlayerShip playerShip)
        {
            Console.WriteLine($"{playerShip.GetType()} посетила объект {playerShip.GetType()} и нанёс урон");
            //Корабли не будут наносить урон сталкиваясь между собой
        }
        #endregion
        public override void Collide(Entity ent1, Entity ent2)
        {
            if (this == ent1)
            {
                Console.WriteLine($"Произошла коллизия между объектом {ent1.GetType()} и {ent2.GetType()}");
                ent2.Visit(this);
            }
        }
    }
}