using System.Runtime.Remoting.Messaging;
using System.Xml;
using CosmicDefender.ObjectPool;
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
        private Pool<Bullet> _pool;
        public Gun(IGunShot Type)
        {
            _gunShotImplementation = Type;
            _pool = new Pool<Bullet>(new Bullet(), 10);
            
        }
        public Gun()
        {
            _gunShotImplementation = TypeDefaultType;
            _pool = new Pool<Bullet>(new Bullet(), 10);
        }
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
        public void Shot()
        {
            _gunShotImplementation.Shot(_pool);
        }
        public virtual void Update()
        {
            
        }
    }
}