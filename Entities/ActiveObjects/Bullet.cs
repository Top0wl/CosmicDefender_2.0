using System.Diagnostics;
using SFML.System;

namespace CosmicDefender
{
    public class Bullet : ActiveObjects
    {

        public Bullet()
        {
            
        }

        public Bullet(Vector2f coords, Vector2f rotation)
        {
            this.Coords = coords;
            this.Rotation = rotation;
            //this._speed = 
        }
    }
}