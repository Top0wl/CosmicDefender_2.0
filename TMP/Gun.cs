using System.Runtime.Remoting.Messaging;
using SFML.System;

namespace CosmicDefender
{
    public class Gun : Handlers
    {
        private int _cooldown;
        private int _damage;
        private Vector2f _rotation;
        private string _name;
        private IGunShot _gunShotImplementation;
        public Vector2f Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }
        public Gun(IGunShot Type)
        {
            _gunShotImplementation = Type;
        }
        public Gun() { }
        public void Shot()
        {
            _gunShotImplementation.Shot();
        }
        public virtual void Update()
        {
            
        }
    }
}