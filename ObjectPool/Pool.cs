using System;
using System.Collections.Generic;

namespace CosmicDefender.ObjectPool
{
    public class Pool<T> where T : Entity, new()
    {
        public T _prefab { get; }
        public bool _autoExpand { get; set; }
        private List<T> _pool;

        public Pool(T _prefab, int count)
        {
            this._prefab = _prefab;
            this.CreatePool(count);
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
            T createdObject = new T();
            createdObject.SetActive(isActiveByDefault);
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
                if (item.GetActive() == false)
                {
                    element = item;
                    item.SetActive(true);
                    return true;
                }
            }
            element = null;
            return false;
        }
        public T GetFreeElement()
        {
            if (this.HasFreeElement(out T element))
                return element;
            if (this._autoExpand)
                return this.CreateObject(true);

            throw new Exception($"There is no free elements in pool of type {typeof(T)}");

        }
    }
}