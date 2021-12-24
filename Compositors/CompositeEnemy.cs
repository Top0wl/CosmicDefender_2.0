using System;
using System.Collections.Generic;

namespace CosmicDefender
{
    public class CompositeEnemy : Handlers
    {
        private List<Ship> _children = new List<Ship>();
        public void Add(Ship ship)
        {
            this._children.Add(ship);
        }
        public void Remove(Ship ship)
        {
            this._children.Add(ship);
        }
        public void MoveTo(Ship ship)
        {
            foreach (var child in _children)
            {
                Console.WriteLine($"Объект {child.GetType()} двигается в сторону {ship.GetType()}");
            }
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}