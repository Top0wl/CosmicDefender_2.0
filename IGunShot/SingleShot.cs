using System;

namespace CosmicDefender
{
    public class SingleShot : IGunShot
    {
        public void Shot()
        {
            Console.WriteLine("SingleShot");
        }
    }
}