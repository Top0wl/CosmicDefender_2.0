using System;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public interface IEntityStats
    {
        public Vector2f Coords { get; set; }
        public Vector2f Speed { get; set; }
        public Vector2f Rotation { get; set; }
        public float MaxSpeed { get; set; }
        public float Acceleration { get; set; }
        public String Name { get; set; }
        public float Health { get; set; }
        public bool IsActive { get; set; }
    }
}