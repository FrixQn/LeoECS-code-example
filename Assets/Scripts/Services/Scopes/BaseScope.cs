using System.Collections.Generic;
using System;
using UnityEngine;

namespace ECSExample.Services
{
    public class BaseScope : MonoBehaviour
    {
        private Dictionary<Type, object> _servicesMap = new();

        public void RegisterService<T>(object service)
        {
            if (_servicesMap.ContainsKey(typeof(T)))
            {
                Debug.LogWarning($"Service with {typeof(T)} already registered.");
            }
            else
            {
                _servicesMap.Add(typeof(T), service);
            }
        }

        public T RegisterInstance<T>(T instance)
        {
            if (instance == null)
            {
                throw new NullReferenceException();
            }

            RegisterService<T>(instance);
            return instance;
        }

        public T GetServiceByType<T>()
        {
            if (_servicesMap.ContainsKey(typeof(T)))
                return (T)_servicesMap[typeof(T)];
            else
                throw new NullReferenceException();
        }

        private void OnDestroy()
        {
            foreach (var service in _servicesMap.Values)
            {
                if (service is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}
