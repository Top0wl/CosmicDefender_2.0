using System;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class Entity : IDrawableObjects
    {
        //Поля
        #region Fields
        protected Vector2f _coords
        {
            get { return this._sprite.Position; }
            set { this._sprite.Position = value; }
        }
        protected Vector2f _speed;
        protected float _acceleration = 0.3f;
        protected Vector2f _rotation;
        protected String _name;
        
        
        protected bool IsActive = true;
        protected int _health;
        protected float speed;
        
        #endregion
        
        //Геттеры / Сеттеры
        #region Getters / Setters
        
        public Vector2f Coords
        {
            get => _coords;
            set => _coords = value;
        }
        public Vector2f Speed
        {
            get => _speed;
            set => _speed = value;
        }
        public float Acceleration
        {
            get => _acceleration;
            set => _acceleration = value;
        }
        public Vector2f Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Health
        {
            get => _health;
            set => _health = value;
        }
        public void SetActive(bool active)
        {
            this.IsActive = active;
        }
        public bool GetActive()
        {
            return IsActive;
        }

        #endregion
        
        
        
        public enum TypeEntities
        {
            //PlayerShips
            PlayerShip_1,
            //Astroids
            Asteroid_1,
            //Enemies
            EnemyShip_Simple,
            EnemyShip_Boss_Level1,
        }
        
        public Entity ShallowCopy()
        {
            return (Entity) this.MemberwiseClone();
        }

    }
    
}