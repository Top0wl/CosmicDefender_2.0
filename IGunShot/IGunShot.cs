using CosmicDefender.ObjectPool;

namespace CosmicDefender
{
    public interface IGunShot
    {
        void Shot();
        void Shot(Pool<Bullet> pool);
    }
}