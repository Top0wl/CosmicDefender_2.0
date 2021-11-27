using System;
using CosmicDefender.ObjectPool;

namespace CosmicDefender
{
    public class SingleShot : IGunShot
    {
        public void Shot()
        {
            Console.WriteLine("SingleShot");
        }

        public void Shot(Pool<Bullet> pool)
        {
            Bullet bullet = pool.GetFreeElement();
            //TODO: Задать билдер пули и прописать её логику и траекторию
        }
    }
}