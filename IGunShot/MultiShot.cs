using System;
using CosmicDefender.ObjectPool;

namespace CosmicDefender
{
    public class MultiShot : IGunShot
    {
        public void Shot()
        {
            Console.WriteLine("MultiShot");
        }

        public void Shot(Pool<Bullet> pool)
        {
            throw new NotImplementedException();
        }
    }
}