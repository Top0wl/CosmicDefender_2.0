using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    public abstract class Ship : Entity
    {
        private readonly ActiveObjects _dmgAdapter = new Bullet();
        public virtual void Damage(Entity Object1, Entity Object2, int damage)
        {
            _dmgAdapter.Damage(Object1,Object2, damage);
        }
    }
}