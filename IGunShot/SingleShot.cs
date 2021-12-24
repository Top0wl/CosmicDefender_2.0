using System;
using CosmicDefender.Controllers;
using CosmicDefender.ObjectPool;
using SFML.System;

namespace CosmicDefender
{
    public class SingleShot : IGunShot
    {
        private IGunShot _gunShotImplementation;

        public void Shot()
        {
            throw new NotImplementedException();
        }

        public void Shot(Pool<Bullet> pool)
        {
            Bullet bullet = pool.GetFreeElement();
            ObjectManager.GetInstance().AddEntity(bullet);
            //TODO: Задать билдер пули и прописать её логику и траекторию
        }

        public void Shot(Pool<Bullet> pool, Vector2f coords, Vector2f rotation)
        {
            throw new NotImplementedException();
        }

        public void Shot(Pool<Bullet> pool, Vector2f coords, Vector2f rotation, Vector2f speed)
        {
            Bullet bullet = pool.GetFreeElement();
            bullet.EnableCollide();
            
            bullet.Coords = coords;
            bullet.Rotation = rotation;
            bullet.Speed = new Vector2f(0,0);
            bullet.MaxSpeed = bullet.DefaultMaxSpeed;
            
            bullet.Speed += speed;
            bullet.MaxSpeed += bullet.LengthVector(speed);
            
            ObjectManager.GetInstance().AddEntity(bullet);
        }
    }
}