using System;

namespace CosmicDefender
{
    public class MultiShot : IGunShot
    {
        public void Shot()
        {
            Console.WriteLine("MultiShot");
        }
    }
}