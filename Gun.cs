using System.Runtime.Remoting.Messaging;
using SFML.System;

namespace CosmicDefender
{
    public class Gun
    {
        private int _cooldown;
        private int _damage;
        private Vector2f _rotation;
        private string _name;
        private IGunShot _gunShotImplementation;

        //private List<Bullet> Bullets;
        
        public Gun(IGunShot Type)
        {
            _gunShotImplementation = Type;
        }
        
        public void Shot()
        {
            _gunShotImplementation.Shot();
        }
    }
}