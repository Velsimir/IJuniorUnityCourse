using UnityEngine;

namespace Homework19
{
    public class ObjectSpawner <T> where T : MonoBehaviour, ICreatableObject
    {
        private T _prefab;
        
        public void Initialize(T prefab)
        {
            _prefab = prefab;
        }

        public T Spawn()
        {
            T spawnObject = GameObject.Instantiate(_prefab);
            
            spawnObject.Initialize();

            return spawnObject;
        }
    }
}