using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CosmicDefender.Controllers;
using CosmicDefender.FactoryMethod;
using SFML.System;

namespace CosmicDefender
{
    public class SpawnerEntities: ISpawner
    {
        private GameManager GameManager;
        private Random rnd = new Random();

        public GameLevel Level
        {
            get => GameManager.GetLevel();
        }

        private ISpawn _spawnImplementation;
        public ISpawn SpawnImplementation
        {
            get => _spawnImplementation;
            set => _spawnImplementation = value;
        }

        public SpawnerEntities(GameManager gameManager)
        {
            this.GameManager = gameManager;
            //Entity player = this.Level.PlayerShip;
            //ObjectManager.GetInstance().AddEntity(player);
        }

        public override void Update()
        {
            int randomint = rnd.Next(1, 100);
            //Шанс спавна
            if (randomint > 1 && randomint < 4)
            {
                //Спавн выбор:
                //1 - астероид
                //2 - враг
                int ChooseEnt = rnd.Next(0, 2);
                if (ChooseEnt == 0)
                {
                    _spawnImplementation = new SpawnAstreroid();
                    Spawn(Level.AF);
                }
                else if (ChooseEnt == 1)
                {
                    _spawnImplementation = new SpawnEnemy();
                    Spawn(Level.AF);
                }
            }

            int randombossspawn = rnd.Next(1, 1000);
            if (randombossspawn == 1)
            {
                _spawnImplementation = new SpawnBoss();
                Spawn(Level.AF);
            }
        }

        public void Spawn(AbstractFactory af)
        {
            SpawnImplementation.Spawn(af);
        }
    }
}