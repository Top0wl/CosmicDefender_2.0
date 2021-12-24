using System;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender.Menu
{
    public class MenuRectShips
    {
        public PlayerShip Ship;
        public Sprite SpriteShip;
        public Sprite SpriteRect;
        public String Name;
        public MenuRectShips(Sprite _SpriteRect, Sprite _SpriteShip, String _Name, Vector2f _Position, PlayerShip ship)
        {
            SpriteRect = _SpriteRect;
            SpriteShip = _SpriteShip;
            SpriteShip.Origin = new Vector2f(_SpriteShip.Texture.Size.X / 2, _SpriteShip.Texture.Size.Y / 2);
            Name = _Name;
            SpriteRect.Position = _Position;
            this.Ship = ship;
        }
    }
}