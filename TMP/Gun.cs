using System.Runtime.Remoting.Messaging;
using System.Xml;
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

        private readonly IGunShot TypeDefaultType = new SingleShot();
            
        public Vector2f Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }
        public IGunShot GunShotImplementation
        {
            get => _gunShotImplementation;
            set => _gunShotImplementation = value;
        }

        public Gun(IGunShot Type)
        {
            _gunShotImplementation = Type;
        }

        public Gun()
        {
            _gunShotImplementation = TypeDefaultType;
        }
        public void Shot()
        {
            _gunShotImplementation.Shot();
        }
        public virtual void Update()
        {
            
        }
    }
}