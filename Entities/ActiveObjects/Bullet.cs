using System;
using System.Collections.Generic;
using System.Diagnostics;
using SFML.System;

namespace CosmicDefender
{
    public class Bullet : ActiveObjects
    {
        private Vector2f _coords
        {
            get { return this._sprite.Position; }
            set { this._sprite.Position = value; }
        }

        public Bullet()
        {
            Collider.getInstance().OnCollide += Collide;
        }
        public Bullet(Vector2f coords, Vector2f rotation, float speed)
        {
            this._sprite = Content.getInstance().GetBullet();
            this._sprite.Scale = new Vector2f(0.2f, 0.2f);
            this._coords = coords;
            this._rotation = rotation;
            this.speed = speed;
            Collider.getInstance().OnCollide += Collide;
        }
        public override void Update(float time)
        {
            UpdateSprite();
            var NormalizeRotation = Normalization(_rotation);
            this._coords += speed * NormalizeRotation;
            
        }

        private void UpdateSprite()
        {
            var RotateAngle = (float)((Math.Atan2(Rotation.Y, Rotation.X) * 180 / Math.PI) - 90);
            _sprite.Rotation = RotateAngle;
        }

        void Collide(Entity ent1, Entity ent2)
        {
            Console.WriteLine($"Произошла колизия между объектом {ent1.GetType()} и {ent2.GetType()}");
        }
        
            private Vector2f Normalization(Vector2f vector)
            {
                float d = (float)Math.Sqrt((vector.X) * (vector.X) + (vector.Y) * (vector.Y));
                vector = vector / (10 * d);
                return vector;
            }
    }
}