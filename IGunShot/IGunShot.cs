using CosmicDefender.ObjectPool;
using SFML.System;

namespace CosmicDefender
{
    public interface IGunShot
    {
        void Shot();
        void Shot(Pool<Bullet> pool);
        void Shot(Pool<Bullet> pool, Vector2f coords, Vector2f rotation);
        void Shot(Pool<Bullet> pool, Vector2f coords, Vector2f rotation, Vector2f speed);
    }
}