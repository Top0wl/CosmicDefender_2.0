using System;
using System.Collections.Generic;
using System.Diagnostics;
using CosmicDefender.Controllers;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public class Bullet : ActiveObjects
    {
        public Bullet() { }
        public Bullet(Sprite sprite, float velocity, float acceleration, string name, float health) 
            : base(sprite, velocity, acceleration, name, health)
        {
            this._sprite.Scale = new Vector2f(0.2f, 0.2f);
            Collider.getInstance().OnCollide += Collide;
        }
        public override void Update(float time)
        {
            Force();
            CheckPostitions();
            UpdateSprite();
            base.Update(time);
        }
        private void UpdateSprite()
        {
            var RotateAngle = (float)((Math.Atan2(Rotation.Y, Rotation.X) * 180 / Math.PI) - 90);
            _sprite.Rotation = RotateAngle;
        }
        void Collide(Entity ent1, Entity ent2)
        {
            //Ent1 - объект 1
            //Ent2 - объект 2
            //Кто.Accept(кого)
            if (ent1.GetType() == this.GetType())
            {
                if (ent2.GetType() == typeof(EnemyShip))
                {
                    Console.WriteLine("log");
                    ent2.Accept(ent1);
                    ent1.Accept(ent2);
                }
            }
            Console.WriteLine($"Произошла коллизия между объектом {ent1.GetType()} и {ent2.GetType()}");
        }
        void CheckPostitions()
        {
            if (Coords.X < 0 || Coords.X > 1280 || Coords.Y < 0 || Coords.Y > 720)
            {
                this.IsActive = false;
                ObjectManager.GetInstance().DeleteEntity(this);
            }
        }
        public override void Accept(IEntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}