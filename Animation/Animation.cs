using System.Collections.Generic;
using System.Net.Sockets;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender.Animation
{
    public class Animation: Entity
    {
        public float Frame, Speed;
        public List<IntRect> frames = new List<IntRect>(); 

        public Animation(Sprite sprite, int x, int y, int w, int h, int countX, int countY, float speed, float scale, Vector2f coords)
        {
            this.Health = 100;
            this._sprite = new Sprite(sprite);
            this._sprite.Scale = new Vector2f(scale, scale);
            this.Coords = coords;
            _sprite.Origin = new Vector2f(w / 2, h / 2);
            Frame = 0;
            Speed = speed;
            for (int i = 0; i < countY; i++) {
                for (int j = 0; j < countX; j++)
                {
                    frames.Add(new IntRect(x + (j * w), y, w, h));
                }
                y += h;
                x = 0;
            }
            _sprite.TextureRect = frames[0];
        }
        public Animation(Sprite sprite, int x, int y, int w, int h, int countX, int countY, float speed, float scale)
        {
            this.Health = 100;
            this._sprite = new Sprite(sprite);
            this._sprite.Scale = new Vector2f(scale, scale);
            _sprite.Origin = new Vector2f(w / 2, h / 2);
            Frame = 0;
            Speed = speed;
            for (int i = 0; i < countY; i++) {
                for (int j = 0; j < countX; j++)
                {
                    frames.Add(new IntRect(x + (j * w), y, w, h));
                }
                y += h;
                x = 0;
            }
            _sprite.TextureRect = frames[0];
        } 
        
        public Animation(Sprite sprite, int x, int y, int w, int h, int count, float speed, float scale)
        {
            this.Health = 100;
            this._sprite = new Sprite(sprite);
            this._sprite.Scale = new Vector2f(scale, scale);
            this._sprite.Origin = new Vector2f(_sprite.Texture.Size.X/2, _sprite.Texture.Size.Y / 2);
            this.Coords = new Vector2f(x, y);
            Speed = speed;
            Frame = 0;
            for (int i = 0; i < count; i++)
            {
                frames.Add(new IntRect(x + (i * w), y, w, h));
            }
        }

        public override void Update(float time)
        {
            Frame += Speed;
            int n = frames.Count;
            if (Frame >= n) Frame -= n;
            if (n > 0)
                _sprite.TextureRect = frames[(int)Frame];
            if (this.isEnd())
            {
                this.Health = 0;
            }
            base.Update(time);
        }
        public bool isEnd()
        {
            return Frame + Speed >= frames.Count;
        }

        // public override void Draw()
        // {
        //     // _sprite.Position = new Vector2f(Coords.X, Coords.Y);
        //     // base.Draw();
        //     // Window.getInstance().getWindow().Draw(_sprite);
        // }

        public override void Collide(Entity ent1, Entity ent2)
        {

        }
    }
}