using System.Collections.Generic;
using System.Configuration;
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
        public GameLevel _level;
        private Content _content;
        private Collider _collider;
        
        private AbstractFactory AF = new Level1Factory();
        public GameManager()
        {
            _content = new Content();
            _content.Load();
            _objectManager  = ObjectManager.GetInstance();
            //this._level = new GameLevel(_content.GetBackgroundLevel1(), 30, 100, new Level1Factory(), );
            this._collider = new Collider(_entities);
            this._spawner = new SpawnerEntities(this);

            
            // Animation.Animation AnimationExplosive1 = new Animation.Animation(Content.getInstance().GetTypeC(), 0, 0, 256, 256, 48, 1,0.1f, 1f, new Vector2f(100f,100f));
            // ObjectManager.GetInstance().AddEntity(AnimationExplosive1);
            //
            // Animation.Animation AnimationExplosive2 = new Animation.Animation(Content.getInstance().GetTypeA(), 0, 0, 50, 50, 20, 1,0.1f, 1f, new Vector2f(300f,100f));
            // ObjectManager.GetInstance().AddEntity(AnimationExplosive2);
            //
            // Animation.Animation AnimationExplosive3 = new Animation.Animation(Content.getInstance().GetTypeB(), 0, 0, 192, 192, 64, 1,0.1f, 1f, new Vector2f(600f,100f));
            // ObjectManager.GetInstance().AddEntity(AnimationExplosive3);
            
            
            
            
            //Asteroid aste = new Asteroid(new Animation.Animation(Content.getInstance().GetsAnimAsteroid1(), 0, 0, 85,
            //    100, 6, 5, 0.15f, 0.4f, new Vector2f(0,0)), "Asteroid", 100);
            // ObjectManager.GetInstance().AddEntity(aste);
            
            //Animation.Animation ast = new Animation.Animation(Content.getInstance().GetsAnimAsteroid1(), 0, 0, 85, 100, 6, 5, 0.15f, 0.4f, new Vector2f(100,100));
            //ObjectManager.GetInstance().AddEntity(ast);

            //Entity Player = AF.CreatePlayerShip();
            //Player.Coords = new Vector2f(100, 100);
            // Entity Enemy = AF.CreateEnemyShip();
            // Enemy.Coords = new Vector2f(300, 300);
            //_entities.Add(Player);
            //_entities.Add(Enemy);
        }
        public void Update()
        {
            float time = Time();
            
            _spawner.Update();
            _collider.Update();
            _level.Update(time);
            
            for (int i = 0; i < _entities.Count; i++)
            {
                var entity = _entities[i];
                entity.Update(time);
                entity.Draw();      
            }
        }
        private float Time()
        {
            float time = clock.ElapsedTime.AsMicroseconds();
            clock.Restart();
            time = time / 10000;
            return time;
        }

        public void SetLevel(GameLevel lvl)
        {
            this._level = lvl;
        }

        public GameLevel GetLevel()
        {
            return this._level;
        }
    }
}