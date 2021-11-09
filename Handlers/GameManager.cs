using System.Collections.Generic;

namespace CosmicDefender
{
    public class GameManager : Handlers
    {
        private List<Entity> _entities;
        private ISpawner _spawner;
        private GameLevel _level;
        private Content _content;
        public GameManager()
        {
            _content = new Content();
            _content.Load();
            this._entities = new List<Entity>();
            this._level = new GameLevel(_content.GetBackgroundLevel1(), 30, 100);
            SpawnerEntities realSpawnerEntities = new SpawnerEntities();
            this._spawner = new ProxySpawnerEntities(realSpawnerEntities, _level, _entities);
        }
        public void Update()
        {
            _level.Update();
            _level.Draw();
            _spawner.Update();
            foreach (var entity in _entities)
            {
                entity.Update();
               // entity.Draw();
            }
        }
    }
}