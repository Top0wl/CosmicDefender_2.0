using System.Threading;
using CosmicDefender.FactoryMethod;
using SFML.Graphics;

namespace CosmicDefender
{
    public class GameLevel : IDrawableObjects
    {
        public Boss EnemyBoss;
        public PlayerShip PlayerShip;
        
        public AbstractFactory AF;
        public Sprite _sprite { get; set; }
        
        private int _countEntitiesOnMap = 30;
        private int _allCountEntities = 150;
        public int CountEntitiesOnMap
        {
            get => _countEntitiesOnMap;
            //set => _countEntitiesOnMap = value;
        }
        public int AllCountEntities
        {
            get => _allCountEntities;
            //set => _allCountEntities = value;
        }
        public GameLevel(Sprite sprite, int countEntitiesOnMap, int allCountEntities, AbstractFactory af, Boss boss)
        {
            this.AF = af;
            this._sprite = sprite;
            this._countEntitiesOnMap = countEntitiesOnMap;
            this._allCountEntities = allCountEntities;
            this.EnemyBoss = boss;
        }
        
        public void Update(float time)
        {
            Draw();
        }

        public void Draw()
        {
            Window.getInstance().getWindow().Draw(_sprite);
        }
    }
}