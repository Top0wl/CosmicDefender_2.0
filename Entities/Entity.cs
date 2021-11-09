using System;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class Entity : IDrawableObjects
    {
        protected Vector2f _coords;
        protected Vector2f _speed;
        protected Vector2f _rotation;
        protected String _name;
        protected int _health;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
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