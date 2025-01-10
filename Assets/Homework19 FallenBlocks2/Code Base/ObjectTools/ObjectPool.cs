using System.Collections.Generic;
using UnityEngine;

namespace Homework19
{
    public class ObjectPool<T> where T : MonoBehaviour, IDisappeared<T>
    {
        private List<T> _freeObjects;
        
        public bool HasFreeObject => _freeObjects.Count > 0;

        public void Initialize()
        {
            _freeObjects = new List<T>();
        }

        public void TrackNewObject(T newObject)
        {
            newObject.Disappeared += AddFreeObject;
        }

        public T GetFreeObject()
        {
            T objectFromPool = _freeObjects[0];
            _freeObjects.Remove(objectFromPool);
            objectFromPool.Disappeared += AddFreeObject;
            objectFromPool.gameObject.SetActive(true);
            
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