using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public class EnemyShip : Ship
    {
        public EnemyShip() {  }
        public EnemyShip(string name, Gun gun)
        {
            this._name = name;
            this.Guns = gun;
        }
        public EnemyShip(Sprite ShipSprite, Vector2f Coords, int Velocity, IGunShot TypeOfGun)
        {
            _sprite = new Sprite(ShipSprite);
            ((Entity) this).Coords = Coords;
            Speed = new Vector2f(Velocity, Velocity);
            Guns = new Gun(TypeOfGun);
            Guns = new Trajectory(Guns);
            ((Entity) this).Coords = Coords;
            _sprite.Position = ((Entity) this).Coords;
            _name = "EnemyShip";
        }
        
        public override void Update(float time)
        {
            
        }
    }
}