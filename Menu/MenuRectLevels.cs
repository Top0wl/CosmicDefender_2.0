using System;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender.Menu
{
    public class MenuRectLevels
    {
        public Sprite Background;
        public Sprite SpriteRect;
        public String Name;
        public GameLevel Level;

        public MenuRectLevels(Sprite spriteRect, String name, Vector2f position, GameLevel level)
        {
            SpriteRect = spriteRect;
            SpriteRect.Position = position;
            Name = name;
            this.Level = level;
            // Background = background;
        }
    }
}