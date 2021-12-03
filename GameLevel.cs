using System.Threading;
using SFML.Graphics;

namespace CosmicDefender
{
    public class GameLevel : IDrawableObjects
    {
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
        public GameLevel(Sprite sprite, int countEntitiesOnMap, int allCountEntities)
        {
            this._sprite = sprite;
            this._countEntitiesOnMap = countEntitiesOnMap;
            this._allCountEntities = allCountEntities;
        }
        public override void Update(float time)
        {
            
        }
    }
}