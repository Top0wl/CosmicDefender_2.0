using System;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class Ship : Entity
    {
        protected Gun _guns;
        public Gun Guns
        {
            get => _guns;
            set => _guns = value;
        }
        public IGunShot GunsImplement
        {
            get => _guns.GunShotImplementation;
            set => _guns.GunShotImplementation = value;
        }
        public Ship ShallowCopy()
        {
            return (Ship) this.MemberwiseClone();
        }
        public Ship DeepCopy()
        {
            Ship clone = (Ship) this.MemberwiseClone();
            clone.Guns = new Gun();
            return clone;
        }
        public void LogWhoIsThis()
        {
            Console.WriteLine($"This {this.GetType()}, Name {this._name}, Type_Gun : {Guns.GunShotImplementation}");
        }
    }
}