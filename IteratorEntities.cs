using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CosmicDefender
{
    public class IteratorEntities<T> : IEnumerable<T>
    {
        private readonly List<T> _storage;

        public IteratorEntities(List<T> storage)
        {
            _storage = storage;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var len = _storage.Count;
            for (int i = 0; i < len; i++)
                yield return _storage[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}