using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using CosmicDefender.Controllers;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public class Bullet : ActiveObjects
    {
        public float DefaultMaxSpeed;
        public Bullet()
        {
        }
        public Bullet(Sprite sprite, float maxSpeed, float acceleration, string name, float health, float dmg) 
            : base(sprite, maxSpeed, acceleration, name, health)
        {
            Dmg = dmg;
            DefaultMaxSpeed = maxSpeed;
            //_sprite.Scale = new Vector2f(0.2f, 0.2f);
            //EnableCollide();
        }
        public override void Update(float time)
        {
            Force();
            UpdateSprite();
            base.Update(time);
        }
        private void UpdateSprite()
        {
            var RotateAngle = (float)((Math.Atan2(Rotation.Y, Rotation.X) * 180 / Math.PI) - 90);
            _sprite.Rotation = RotateAngle;
        }
        public override void CheckPostitions()
        {
            if (Coords.X < 0 || Coords.X > 1280 || Coords.Y < 0 || Coords.Y > 720)
            {
                this.IsActive = false;
                this.DisableCollide();
                ObjectManager.GetInstance().DeleteEntity(this);
            }
        }
        public Bullet DeepCopy()
        {
            Bullet clone = (Bullet) this.MemberwiseClone();
            clone._sprite = new Sprite(_sprite);
            clone.Acceleration = this.Acceleration;
            clone.Coords = new Vector2f(0, 0);
            clone.Health = this.Health;
            clone.Name = this.Name;
            clone.Rotation = new Vector2f(0, 0);
            clone.Speed = new Vector2f(0, 0);
            clone.MaxSpeed = this.MaxSpeed;
            clone.IsActive = false;
            return clone;
        }
        public override void Visit(Bullet bullet)
        {
            Console.WriteLine($"{bullet.GetType()} посетила объект {this.GetType()} и нанёс урон");
            bullet.DisableCollide();
            ObjectManager.GetInstance().AddEntity(Content.getInstance().GetExplosive1(bullet.Coords, 1f, 0.2f));
            ObjectManager.GetInstance().DeleteEntity(bullet);
        }
        public override void Visit(EnemyShip enemyShip)
        {
            Console.WriteLine($"{enemyShip.GetType()} посетила объект {this.GetType()} и нанёс урон");
            //enemyShip.DisableCollide();
            //ObjectManager.GetInstance().DeleteEntity(enemyShip);
        }
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