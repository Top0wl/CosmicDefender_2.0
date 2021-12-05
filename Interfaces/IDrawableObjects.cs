using SFML.Graphics;

namespace CosmicDefender
{
    public interface IDrawableObjects
    {
        public Sprite _sprite { get; set; }
        public void Update(float time);
        public void Draw();
    }
}