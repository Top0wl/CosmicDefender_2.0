using CosmicDefender.Builders.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender.Builders.Builders
{
    public class PlayerShipBuilder : IShipBuilder
    {
        private Ship _ship;
        public PlayerShipBuilder() => _ship = new PlayerShip();
        public Entity Build() => _ship;
        public IShipBuilder SetSprite(Sprite sprite)
        {
            _ship._sprite = new Sprite(sprite);
            return this;
        }
        public IEntityBuilder SetCoords(Vector2f Coords)
        {
            _ship.Coords = Coords;
            return this;
        }
        public IEntityBuilder SetSpeed(Vector2f Speed)
        {
            _ship.Speed = Speed;
            return this;
        }
        public IEntityBuilder SetRotation(Vector2f Rotation)
        {
            _ship.Rotation = Rotation;
            return this;
        }
        public IEntityBuilder SetName(string Name)
        {
            _ship.Name = Name;
            return this;
        }
        public IEntityBuilder SetHealth(int Health)
        {
            _ship.Health = Health;
            return this;
        }
        public IShipBuilder SetGun(Gun gun)
        {
            _ship.Weapon = gun;
            return this;
        }
    }
}