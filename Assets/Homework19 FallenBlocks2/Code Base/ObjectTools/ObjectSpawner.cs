using UnityEngine;

namespace Homework19
{
    public class ObjectSpawner <T> where T : MonoBehaviour, ICreatableObject, IDisappeared<T>
    {
        private T _prefab;

        public ObjectSpawner(T prefab)
        {
            _prefab = prefab;
            Pool = new ObjectPool<T>();
        }
        
        public ObjectPool<T> Pool { get; }

        public T Spawn()
        {
            T spawnObject;
            
            spawnObject = Pool.HasFreeObject ? Pool.GetFreeObject() : Pool.TrackNewObject(GameObject.Instantiate(_prefab));
            
            spawnObject.Initialize();

            return spawnObject;
        }
    }
}