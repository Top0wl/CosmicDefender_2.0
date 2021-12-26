using System;
using System.Collections.Generic;
using System.Linq;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public class Collider : Handlers
    {
        private static Collider _instance;
        public Action<Entity,Entity> OnCollide;
        private List<Entity> _entities;
        public static Collider getInstance()
        {
            if (_instance == null)
            {
                //_instance = new Collider();
            }
            return _instance;
        }
        public Collider(List<Entity> entities)
        {
            _instance = this;
            _entities = entities;
        }
        private static bool IsCollide(Sprite first, Sprite second)
        {
            Vector2f firstRect = new Vector2f(first.TextureRect.Width, first.TextureRect.Width);
            firstRect.X *= first.Scale.X;
            firstRect.Y *= first.Scale.Y;

            Vector2f secondRect = new Vector2f(second.TextureRect.Width, second.TextureRect.Width);
            secondRect.X *= second.Scale.X;
            secondRect.Y *= second.Scale.Y;

            float r1 = (firstRect.X + firstRect.Y) / 4;
            float r2 = (secondRect.X + secondRect.Y) / 4;
            float xd = first.Position.X - second.Position.X;
            float yd = first.Position.Y - second.Position.Y;

            return (Math.Sqrt(xd * xd + yd * yd) <= r1 + r2);
        }
        public void Update()
        {
            _entities.Reverse();
            var ents = new List<Entity>(_entities);
            _entities.Reverse();
            foreach (var item1 in ents.ToList())
            {
                foreach (var item2 in ents.ToList())
                {
                    if (item1 != item2)
                    {
                        if (IsCollide(item1._sprite, item2._sprite))
                        {
                            //Если коллизия произошла, то сделать событие
                            if ((item1.GetType() == typeof(EnemyShip) && item2.GetType() == typeof(EnemyShip)) || item1.GetType() == typeof(Animation.Animation) || item2.GetType() == typeof(Animation.Animation))
                            {
                            }
                            else 
                            OnCollide?.Invoke(item1, item2);
                            //Collide(_entities[i], _entities[j]);
                        }
                    }
                }
            }
        }
    }
}
                           