using System;
using System.ComponentModel.Design;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class Entity : IEntityVisitor, IEntityStats, IDrawableObjects
    {
        #region Fields
        public Sprite _sprite { get; set; }
        public Vector2f Coords { get => _sprite.Position ; set => _sprite.Position = value; }
        public Vector2f Speed { get; set; }
        public Vector2f Rotation { get; set; }
        public float Velocity { get; set; }
        public float Acceleration { get; set; }
        public String Name { get; set; }
        public float Health { get; set; }
        public bool IsActive { get; set; }
        public Vector2f Direction
        {
            get => Normalization(Rotation);
        }
        #endregion

        #region Constructors
        public Entity(Sprite sprite, float velocity, float acceleration, string name, float health)
        {
            _sprite = sprite;
            Speed = new Vector2f(0, 0);
            Rotation = new Vector2f(0, 0);
            Velocity = velocity;
            Acceleration = acceleration;
            Name = name;
            Health = health;
        }
        public Entity()
        {
        }

        #endregion
        
        #region Clone
        public Entity DeepCopy()
        {
            Entity clone = (Entity) this.MemberwiseClone();
            clone._sprite = new Sprite(_sprite);
            clone.Acceleration = this.Acceleration;
            clone.Coords = new Vector2f(0, 0);
            clone.Health = this.Health;
            clone.Name = this.Name;
            clone.Rotation = new Vector2f(0, 0);
            clone.Speed = new Vector2f(0, 0);
            clone.Velocity = this.Velocity;
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
            //Обновить позиции всех элементов
            UpdatePosition(time);
            //Проверить позиции объектов

        }

        public void CheckPostitions()
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
            // if (Coords.X > 1280)
            // {
            //     Coords = new Vector2f(0, Coords.Y);
            // }
            // if (Coords.X < 0)
            // {
            //     Coords = new Vector2f(1280, Coords.Y);
            // }
            // if (Coords.Y > 720)
            // {
            //     Coords = new Vector2f(Coords.X, 0);
            // }
            // if (Coords.Y < 0)
            // {
            //     Coords = new Vector2f(Coords.X, 720);
            // }
        }
        public void Force()
        {
            //Наращиваем скорость
            Speed += Acceleration * Direction;
            float constanta = (float)Math.Sqrt( (Velocity * Velocity) / ( Speed.X * Speed.X + Speed.Y * Speed.Y));
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
        
        public void Draw()
        {
            Window.getInstance().getWindow().Draw(_sprite);
        }
        #endregion

        #region Реакции на другие объекты (Visiter)
        public virtual void Visit(Bullet bullet) { }
        public virtual void Visit(EnemyShip enemyShip) { }
        public virtual void Visit(Asteroid asteroid) { }
        public virtual void Accept(IEntityVisitor visitor) { }
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

        
    }
    
}