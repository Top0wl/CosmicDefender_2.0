using System;
using System.Runtime.InteropServices;
using CosmicDefender.Builders.Interfaces;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class Ship : Entity
    {
        public Gun Weapon { get; set; }

        protected Ship(Sprite sprite, float velocity, float acceleration, string name, float health, Gun weapon) 
            : base(sprite, velocity, acceleration, name, health)
        {
            Weapon = weapon;
        }

        public Ship()
        {
            
        }

        // public Ship ShallowCopy()
        // {
        //     return (Ship) this.MemberwiseClone();
        // }
        // public Ship DeepCopy()
        // {
        //     Ship clone = (Ship) this.MemberwiseClone();
        //     clone.Guns = new Gun();
        //     return clone;
        // }
    }
}