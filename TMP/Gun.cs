using System.Runtime.Remoting.Messaging;
using System.Xml;
using CosmicDefender.ObjectPool;
using SFML.System;

namespace CosmicDefender
{
    public class Gun : Handlers
    {
        private int _coords;
        private int _cooldown;
        private int _damage;
        private string _name;
        private Vector2f _rotation;
        private IGunShot _gunShotImplementation;
        private readonly IGunShot TypeDefaultType = new SingleShot();
        private Pool<Bullet> _pool;
        public Gun(IGunShot Type)
        {
            _gunShotImplementation = Type;
            _pool = new Pool<Bullet>(new Bullet(new Vector2f(0,0), _rotation, 10), 10);
            
        }
        public Gun()
        {
            _gunShotImplementation = TypeDefaultType;
            _pool = new Pool<Bullet>(new Bullet(new Vector2f(0,0), _rotation, 10), 10);
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

        public void Shot(Vector2f coords, Vector2f rotation)
        {
            //Изменить координаты coords, чтобы пули вылетали не из корабля а с переди
            _gunShotImplementation.Shot(_pool, coords, this._rotation);
        }
    }
}