using System;
using System.Runtime.Remoting.Messaging;
using System.Xml;
using CosmicDefender.ObjectPool;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public class Gun : Handlers
    {
        //Parrent
        public Ship ship { get; set; }
        //Gun
        public IGunShot GunShotImplementation { get; private set; }
        public Vector2f CoordsSpawnBullet 
        {
            get
            {
                float coef = (float)Math.Sqrt((float)(Math.Pow(((ship._sprite.Texture.Size.X * ship._sprite.Scale.X) / 2), 2) + Math.Pow(((ship._sprite.Texture.Size.Y * ship._sprite.Scale.X) / 2), 2)));
                return new Vector2f(ship.Coords.X + ship.Direction.X * coef, ship.Coords.Y + ship.Direction.Y * coef);
            }
        }
        //Bullet
        public Sprite BulletSprite { get; private set; }
        public float BulletVelocity { get; private set; }
        public float BulletAcceleration { get; private set; }
        public Pool<Bullet> BulletsPool { get; private set; }
        
        public Gun() { }
        public Gun(IGunShot Type, Sprite bulletSprite, float bulletVelocity, float bulletAcceleration, float dmg)
        {
            this.GunShotImplementation = Type;
            this.BulletSprite = bulletSprite;
            this.BulletVelocity = bulletVelocity;
            this.BulletAcceleration = bulletAcceleration;
            this.BulletsPool = new Pool<Bullet>(new Bullet(BulletSprite, 
                    BulletVelocity,BulletAcceleration,"Bullet", 100, dmg), 2);
        }
        public virtual void Shot()
        {
            //Изменить координаты coords, чтобы пули вылетали не из корабля а с переди
            GunShotImplementation.Shot(BulletsPool, CoordsSpawnBullet, ship.Rotation, ship.Speed);
        }
        public virtual void Update()
        {
            
        }
    }
}