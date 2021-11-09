namespace CosmicDefender
{
    public abstract class ISpawner : Handlers
    {
        private GameLevel Level;
        public abstract void Update();
    }
}