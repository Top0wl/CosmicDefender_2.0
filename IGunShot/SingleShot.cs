using System;
using CosmicDefender.Controllers;
using CosmicDefender.ObjectPool;
using SFML.System;

namespace CosmicDefender
{
    public class SingleShot : IGunShot
    {
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
            Bullet bullet = pool.GetFreeElement();

            bullet.Coords = coords;
            bullet.Rotation = rotation;
            
            ObjectManager.GetInstance().AddEntity(bullet);
        }
    }
}