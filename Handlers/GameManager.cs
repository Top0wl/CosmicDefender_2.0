using System.Collections.Generic;
using System.Linq;
using CosmicDefender.Builders.Builders;
using CosmicDefender.Controllers;
using CosmicDefender.FactoryMethod;
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

        
        
        private AbstractFactory AF = new Level1Factory();
        
        public GameManager()
        {
            _content = new Content();
            _content.Load();
            _objectManager  = ObjectManager.GetInstance();
            this._level = new GameLevel(_content.GetBackgroundLevel1(), 30, 100);
            this._collider = new Collider(_entities);


            Entity Player = AF.CreatePlayerShip();
            Player.Coords = new Vector2f(100, 100);
            Entity Enemy = AF.CreateEnemyShip();
            Enemy.Coords = new Vector2f(300, 300);
            
            
            _entities.Add(Player);
            _entities.Add(Enemy);
        }
        public void Update()
        {
            float time = clock.ElapsedTime.AsMicroseconds();
            clock.Restart();
            time = time / 10000;
            
            
            _collider.Update();
            _level.Update(time);
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