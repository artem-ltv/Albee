using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Albee
{
    public class ObjectsPool<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private readonly GameObject _container;
        private readonly int _capacity;
        private readonly T _prefab;

        private List<T> _pool = new List<T>();

        public ObjectsPool(T prefab, GameObject container, int capacity)
        {
            _prefab = prefab;
            _container = container;
            _capacity = capacity;

            CreatePool();
        }

        public T Get()
        {
            var result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

            if (result == null)
            {
                var created = CreateObject();

                result = created;
            }

            result.gameObject.SetActive(true);

            return result;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void CreatePool()
        {
            for (int i = 0; i < _capacity; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject()
        {
            var spawned = Instantiate(_prefab, _container.transform);

            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);

            return spawned;
        }
    }
}
