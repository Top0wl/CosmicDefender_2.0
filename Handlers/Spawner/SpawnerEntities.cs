using System.Collections.Generic;

namespace CosmicDefender
{
    public class SpawnerEntities: ISpawner, ISpawn
    {
        private ISpawn _spawnImplementation;

        public ISpawn SpawnImplementation
        {
            get => _spawnImplementation;
            set => _spawnImplementation = value;
        }

        public override void Update()
        {
            
        }

        public void Spawn(List<Entity> entities)
        {
            SpawnImplementation.Spawn(entities);
        }


    }
}