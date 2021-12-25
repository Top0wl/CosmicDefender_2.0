using System.Collections.Generic;

namespace CosmicDefender.Controllers
{
    public class ObjectManager
    {
        private static ObjectManager _instance;
        private List<Entity> _entities { get; set; }
        public ObjectManager()
        {
            _entities = new List<Entity>();
        }
        public static ObjectManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ObjectManager();
            }
            return _instance;
        }
        public void AddEntity(Entity ent)
        {
            _entities.Add(ent);
        }
        public void DeleteEntity(Entity ent)
        {
            _entities.Remove(ent);
        }
        public List<Entity> GetEntities()
        {
            return _entities;
        }

        public void Clear()
        {
            _entities.Clear();
        }

        public Entity GetPlayer()
        {
            foreach (var ent in _entities)
            {
                if (ent.GetType() == typeof(PlayerShip))
                {
                    return ent;
                }
            }
            return null;
        }
    }
    
}