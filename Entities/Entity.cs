using System;
using System.ComponentModel.Design;
using System.Threading;
using CosmicDefender.Controllers;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class Entity : IEntityVisitor, IEntityStats, IDrawableObjects
    {
        #region Fields
        public Sprite _sprite { get; set; }
        public Vector2f Coords { get => _sprite.Position ; set => _sprite.Position = new Vector2f(value.X,value.Y); }
        public Vector2f Speed { get; set; }
        public Vector2f Rotation { get; set; }
        public float MaxSpeed { get; set; }
        public float Acceleration { get; set; }
        public String Name { get; set; }
        public float Health { get; set; }
        public bool IsActive { get; set; }
        public float Dmg { get; set; }
        public Vector2f Direction
        {
            get => Normalization(Rotation);
        }
        #endregion
        
        #region Constructors
        public Entity(Sprite sprite, float maxSpeed, float acceleration, string name, float health)
        {
            _sprite = new Sprite(sprite);
            Speed = new Vector2f(0, 0);
            Rotation = new Vector2f(0, 0);
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            Name = name;
            Health = health;
            this.EnableCollide();
            this.Coords = new Vector2f(0, 0);
        }
        public Entity()
        {
        }
        #endregion
        
        #region Clone
        public virtual Entity DeepCopy()
        {
            Entity clone = (Entity) this.MemberwiseClone();
            clone._sprite = new Sprite(_sprite);
            clone.Acceleration = this.Acceleration;
            clone.Coords = new Vector2f(0, 0);
            clone.Health = this.Health;
            clone.Name = this.Name;
            clone.Rotation = new Vector2f(0, 0);
            clone.Speed = new Vector2f(0, 0);
            clone.MaxSpeed = this.MaxSpeed;
            clone.IsActive = false;
            return clone;
        }
        public Entity ShallowCopy()
        {
            return (Entity) this.MemberwiseClone();
        }
        #endregion
        
        #region Methods
        public virtual void Update(float time)
        {
            if (this.Health <= 0)
            {
                if (this.GetType() == typeof(PlayerShip))
                {
                    Menu.Menu.GetInstance().IsOpen = true;
                    ObjectManager.GetInstance().Clear();
                }
                else
                {
                    ObjectManager.GetInstance().DeleteEntity(this);
                }
            }
            //Обновить позиции всех элементов
            UpdatePosition(time);
            //Проверить позиции объектов
            CheckPostitions();
        }
        public virtual void CheckPostitions()
        {
            if (Coords.X > 1280)
            {
                Coords = new Vector2f(0, Coords.Y);
            }
            if (Coords.X < 0)
            {
                Coords = new Vector2f(1280, Coords.Y);
            }
            if (Coords.Y > 720)
            {
                Coords = new Vector2f(Coords.X, 0);
            }
            if (Coords.Y < 0)
            {
                Coords = new Vector2f(Coords.X, 720);
            }
        }
        public void UpdatePosition(float time)
        {
            this.Coords += Speed * time;
        }
        public void Force()
        {
            //Наращиваем скорость
            Speed += Acceleration * Direction;
            float constanta = (float)Math.Sqrt( (MaxSpeed * MaxSpeed) / ( Speed.X * Speed.X + Speed.Y * Speed.Y));
            //Максимальная скорость
            var Speed2 = Speed * constanta;
            float Dvelocity = LengthVector(Speed);
            float Dvelocity2 = LengthVector(Speed2);
            //Если Скорость выше максимальной, то присвоить
            //скорости маскимальную скорость
            if (Dvelocity > Dvelocity2)
            {
                Speed = Speed2;
            }
        }
        private Vector2f Normalization(Vector2f vec)
        {
            float length = LengthVector(vec);
            if (length != 0)
            {
                return new Vector2f(vec.X / length, vec.Y / length);
            }
            else
            {
                return vec;
            }
        }
        public float LengthVector(Vector2f vec)
        {
            float length = (float)Math.Sqrt((vec.X) * (vec.X) + (vec.Y) * (vec.Y));
            return length;
        }
        public virtual void Draw()
        {
            Window.getInstance().getWindow().Draw(_sprite);
        }
        #endregion

        public virtual void Damage(Entity Object1)
        {
            Object1.Health -= this.Dmg;
        }
        
        #region Реакции на другие объекты (Visiter)

        public virtual void Visit(Bullet bullet) { }
        public virtual void Visit(EnemyShip enemyShip) { }
        public virtual void Visit(PlayerShip playerShip) { }
        public virtual void Visit(Asteroid asteroid) { }
        public virtual void Visit(Entity entity) { }
        public abstract void Collide(Entity ent1, Entity ent2);
        
        #endregion

        #region Observer
        public void EnableCollide()
        {
            Collider.getInstance().OnCollide += Collide;
        }
        public void DisableCollide()
        {
            Collider.getInstance().OnCollide -= Collide;
        }
        #endregion
    }
}