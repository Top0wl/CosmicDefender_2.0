using System.Collections.Generic;
using System.Linq;
using CosmicDefender.Builders.Builders;
using CosmicDefender.Controllers;
using SFML.System;

namespace CosmicDefender
{
    public class GameManager : Handlers
    {
        private Clock clock = new Clock();
        
        private ObjectManager _objectManager;
        private List<Entity> _entities => _objectManager.GetEntities();
        private ISpawner _spawner;
        private GameLevel _level;
        private Content _content;
        private Collider _collider;
        
        public GameManager()
        {
            _content = new Content();
            _content.Load();
            _objectManager  = ObjectManager.GetInstance();
            this._level = new GameLevel(_content.GetBackgroundLevel1(), 30, 100);
            //SpawnerEntities realSpawnerEntities = new SpawnerEntities();
            //this._spawner = new ProxySpawnerEntities(realSpawnerEntities, _level, _entities);
            this._collider = new Collider(_entities);
            
            //Создаём пушку
            Gun gun = new Gun(new SingleShot());
            //Обшиваем эту пушку траекторией
            gun = new Trajectory(gun);
            //Создаём игрока и ему присваиваем пушку
            
            Ship Player = new PlayerShip(_content.GetShip1(), new Vector2f(100, 100), 0, gun);
            //Ship Enemy = new EnemyShip(_content.GetsShootShip(), new Vector2f(500, 500), 10, new DoubleShot());
            _entities.Add(Player);
            //_entities.Add(Enemy);
        }
        public void Update()
        {
            float time = clock.ElapsedTime.AsMicroseconds();
            clock.Restart();
            time = time / 10000;
            
            
            _collider.Update();
            _level.Update();
            _level.Draw();

            for (int i = 0; i < _entities.Count; i++)
            {
                var entity = _entities[i];
                entity.Update(time);
                entity.Draw();
            }
        }
    }
}