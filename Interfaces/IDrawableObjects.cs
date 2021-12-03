using SFML.Graphics;

namespace CosmicDefender
{
    public abstract class IDrawableObjects : IDrawable
    {
        public Sprite _sprite { get; set; }
        public abstract void Update(float time);
        public virtual void Update() { }

        public void Draw()
        {
            Window.getInstance().getWindow().Draw(_sprite);
        }
    }
}