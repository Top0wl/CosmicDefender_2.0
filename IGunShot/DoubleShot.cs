using System;
using CosmicDefender.ObjectPool;

namespace CosmicDefender
{
    public class DoubleShot : IGunShot
    {
        public void Shot()
        {
            Console.WriteLine("DoubleShot");
        }

        public void Shot(Pool<Bullet> pool)
        {
            throw new NotImplementedException();
        }
    }
}