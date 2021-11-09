using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.Remoting.Messaging;

namespace CosmicDefender
{
    public class ProxySpawnerEntities : ISpawner
    {
        private SpawnerEntities _spawner;
        private GameLevel _level;
        private List<Entity> _entities;
        private int _leftCountObjects;
        
        private bool IsBossSpawn = false;




        private int _chanceSpawnPerTick = 10;
        
        
        
        
        public ProxySpawnerEntities(SpawnerEntities spawner, GameLevel lvl, List<Entity> ents)
        {
            _spawner = spawner;
            _level = lvl;
            _entities = ents;
            _leftCountObjects = lvl.AllCountEntities;
            _spawner.SpawnImplementation = new SpawnPlayer();
            _spawner.Spawn(_entities);
            
        }
        public override void Update()
        {
            if (CheckAccessSpawnBoss())
            {
                IsBossSpawn = true;
                _spawner.SpawnImplementation = new SpawnBoss();
                _spawner.Spawn(_entities);
            }
            if (CheckAccessSpawnEnemy())
            {
                //TODO: Подумать как сделать получше....
                //Спавним одну из сущностей
                SpawnRandomMinorObject();
            }
        }
        private bool CheckAccessSpawnBoss()
        {
            if (!IsBossSpawn)
            {
                //Если вражеские корабли все повержены, то заспавнить босса.
                if (_leftCountObjects == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckAccessSpawnEnemy()
        {
            //Если объектов на карте меньше чем их максимальное число
            if (_entities.Count <= _level.CountEntitiesOnMap)
            {
                //Если мы заспавненили ещё не все объекты.
                if (_leftCountObjects != 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void SpawnRandomMinorObject()
        {
            Random random = new Random();
            int randint = random.Next(1, 100);
            if (randint <= _chanceSpawnPerTick)
            {
                
            }
            List<ISpawn> MinorObjects = new List<ISpawn>()
            {
                new SpawnAstreroid(), 
                new SpawnEnemy(),
            };
            int index = random.Next(MinorObjects.Count);
            _spawner.SpawnImplementation = MinorObjects[index];
            _spawner.Spawn(_entities);
            _leftCountObjects--;
        }
    }
}