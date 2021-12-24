using System;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender.Menu
{
    public class MenuRectButtons
    {
        public Sprite SpriteRect { get; set; }
        public String Name { get; set; }

        public MenuRectButtons(Sprite spriteRect, String name, Vector2f _Position)
        {
            this.SpriteRect = spriteRect;
            this.SpriteRect.Position = _Position;
            this.Name = name;
        }
    }
}