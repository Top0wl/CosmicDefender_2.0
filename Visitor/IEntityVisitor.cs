namespace CosmicDefender.Visitor
{
    public interface IEntityVisitor
    {
        public void Visit(Bullet bullet);
        public void Visit(EnemyShip enemyShip);
        public void Visit(Asteroid asteroid);
    }
}