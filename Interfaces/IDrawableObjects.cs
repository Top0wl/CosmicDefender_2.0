using SFML.Graphics;

namespace CosmicDefender
{
    public abstract class IDrawableObjects : IDrawable
    {
        protected Sprite _sprite;
        public abstract void Update();

        public void Draw()
        {
            Window.getInstance().getWindow().Draw(_sprite);
        }
    }
}