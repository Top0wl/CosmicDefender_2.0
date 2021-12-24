using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender.ObjectPool
{
    public class Pool<T> where T : Bullet, new()
    {
        public T _prefab { get; }
        public bool _autoExpand { get; set; }
        private List<T> _pool;

        public Pool(T _prefab, int count)
        {
            this._prefab = _prefab;
            this.CreatePool(count);
            _autoExpand = true;
        }
        private void CreatePool(int count)
        {
            this._pool = new List<T>();
            for (int i = 0; i < count; i++)
            {
                this.CreateObject();
            }
        }
        private T CreateObject(bool isActiveByDefault = false)
        {
            T createdObject = (T) _prefab.DeepCopy();
            createdObject.IsActive = isActiveByDefault;
            this._pool.Add(createdObject);
            return createdObject;
        }
        /// <summary>
        /// Проверка есть ли элемент в pool'е. Возвращаем bool и сам элемент
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool HasFreeElement(out T element)
        {
            foreach (var item in _pool)
            {
                //Если объект отключен, то его можно вернуть
                if (item.IsActive == false)
                {
                    element = item;
                    item.IsActive = true;
                    return true;
                }
            }
            element = null;
            return false;
        }
        public T GetFreeElement()
        {
            UpdatePool();
            if (this.HasFreeElement(out T element))
                return element;
            if (this._autoExpand)
                return this.CreateObject(true);

            throw new Exception($"There is no free elements in pool of type {typeof(T)}");

        }
        private void UpdatePool()
        {
            foreach (var item in _pool)
            {
                if (item.IsActive == false)
                {
                    
                }
            }
        }
    }
}