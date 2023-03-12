using System;
using System.Collections.Generic;
using UnityEngine;

namespace ElasticRush.Utilities
{
    public class ObjectPool<T> where T : Component
    {
        private GameObject _prefab;
        private Transform _container;
        private Queue<T> _pool = new Queue<T>();

        public ObjectPool(GameObject prefab)
        {
            if (prefab == null)
                throw new ArgumentNullException(nameof(prefab), "Prefab can't be null");

            if (prefab.GetComponent<T>() == null)
                throw new ArgumentNullException(nameof(prefab), $"Prefab does not have the necessary component");

            _prefab = prefab;

            if (_container == null)
                _container = new GameObject($"Pool - {_prefab.name}").transform;

            _container.SetParent(Helpers.GetGeneralPoolsContainer());
        }

        public void AddInstance(T instance)
        {
            if (instance.transform.parent != _container)
                instance.transform.SetParent(_container);

            _pool.Enqueue(instance);
            instance.gameObject.SetActive(false);
        }

        public T GetInstance()
        {
            if (_pool.Count <= 0)
                return CreateInstance();

            return _pool.Dequeue();
        }

        private T CreateInstance()
        {
            GameObject instance = UnityEngine.Object.Instantiate(_prefab, _container);
            T instanceComponent = instance.GetComponent<T>();
            return instanceComponent;
        }
    }
}