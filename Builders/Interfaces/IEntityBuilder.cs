using SFML.System;

namespace CosmicDefender.Builders.Interfaces
{
    public interface IEntityBuilder
    {
        public IEntityBuilder SetCoords(Vector2f Coords);
        public IEntityBuilder SetSpeed(Vector2f Speed);
        public IEntityBuilder SetRotation(Vector2f Rotation);
        public IEntityBuilder SetName(string Name);
        public IEntityBuilder SetHealth(int Health);
        public Entity Build();
    }
}