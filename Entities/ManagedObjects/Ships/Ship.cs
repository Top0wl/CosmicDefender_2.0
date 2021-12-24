using System;
using System.Runtime.InteropServices;
using CosmicDefender.Builders.Interfaces;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CosmicDefender
{
    public abstract class Ship : Entity
    {
        public Clock Timer = new Clock();
        public float _firingRate { get; } //5f
        public Gun Weapon { get; set; }
        protected Ship(Sprite sprite, float maxSpeed, float acceleration, string name, float health, Gun weapon,  float firingRate) 
            : base(sprite, maxSpeed, acceleration, name, health)
        {
            Weapon = weapon;
            weapon.ship = this;
            _firingRate = firingRate;
        }
        public Ship()
        {
            
        }
        public override void Update(float time)
        {
            UpdateRotation();
            Weapon.Update();
            base.Update(time);
        }

        public bool CheckFireRating()
        {
            if (Timer.ElapsedTime.AsSeconds() >= _firingRate) return true;
            return false;

        }

        public abstract void UpdateRotation();
    }
}