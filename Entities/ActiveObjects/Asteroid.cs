using System;
using CosmicDefender.Controllers;
using CosmicDefender.FactoryMethod;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public class Asteroid : ActiveObjects
    {
        private Animation.Animation AnimationAsteroid;
        public Asteroid(Animation.Animation animation, string name, float health)
        {
            Random rnd = new Random();
            float rotation = rnd.Next(0, 360);
            float maxSpeed = (float)rnd.Next(10, 200) / 100;
            this.Health = health;
            this.MaxSpeed = maxSpeed;
            this.Acceleration = maxSpeed;
            this.Name = name;
            this.AnimationAsteroid = animation;
            this._sprite = AnimationAsteroid._sprite;
            this.AnimationAsteroid._sprite.Rotation = rotation;
            this.Rotation = new Vector2f((float) Math.Cos(Math.PI * (rotation - 90) / 180.0f) * -1, (float)Math.Sin(Math.PI * (rotation - 90) / 180.0f) * -1);
        }

        public Asteroid(Sprite sprite, float maxSpeed, float acceleration, string name, float health) : base(sprite,
            maxSpeed, acceleration, name, health)
        {
            
        }
        public override void Update(float time)
        {
            this.Force();
            this._sprite = AnimationAsteroid._sprite;
            AnimationAsteroid.Update(time);
            base.Update(time);
        }
        public override void Collide(Entity ent1, Entity ent2)
        {
            if (this == ent1)
            {
                Console.WriteLine($"Произошла коллизия между объектом {ent1.GetType()} и {ent2.GetType()}");
                ent2.Visit(this);
            }
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
            Console.WriteLine($"{playerShip.GetType()} посетила объект {this.GetType()} и нанёс урон");
            playerShip.Damage(this);
            //Корабли не будут наносить урон сталкиваясь между собой
        }
    }
}