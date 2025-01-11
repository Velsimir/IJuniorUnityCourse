using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homework19
{
    public class ObjectPool<T> : ICounter where T : MonoBehaviour, IDisappeared<T>
    {
        private List<T> _freeObjects;
        
        public ObjectPool()
        {
            _freeObjects = new List<T>();
        }
        
        public event Action NewObjectAdded;
        public event Action ObjectSent;
        
        public bool HasFreeObject => _freeObjects.Count > 0;
        public int Count => _freeObjects.Count;

        public T TrackNewObject(T newObject)
        {
            newObject.Disappeared += AddFreeObject;
            NewObjectAdded?.Invoke();

            return newObject;
        }

        public T GetFreeObject()
        {
            T objectFromPool = _freeObjects[0];
            _freeObjects.Remove(objectFromPool);
            objectFromPool.Disappeared += AddFreeObject;
            objectFromPool.gameObject.SetActive(true);
            
            ObjectSent?.Invoke();
            
            return objectFromPool;
        }

        private void AddFreeObject(T newObject)
        {
            newObject.gameObject.SetActive(false);
            _freeObjects.Add(newObject);
            newObject.Disappeared -= AddFreeObject;
        }
    }
}