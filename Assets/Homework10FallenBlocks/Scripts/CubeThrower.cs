using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework10
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(CubeSpawner))]
    public class CubeThrower : MonoBehaviour
    {
        [SerializeField] private float _delay;
        
        private CubeSpawner _cubeSpawner;
        private Collider _spawnArea;
        private float _xMinPosition;
        private float _xMaxPosition;
        private float _zMinPosition;
        private float _zMaxPosition;
        
        private void Awake()
        {
            _spawnArea = GetComponent<Collider>();
            _cubeSpawner = GetComponent<CubeSpawner>();
            
            _xMinPosition = _spawnArea.bounds.min.x;
            _xMaxPosition = _spawnArea.bounds.max.x;
            _zMinPosition = _spawnArea.bounds.min.z;
            _zMaxPosition = _spawnArea.bounds.max.z;

            StartCoroutine(TurnOn());
        }
        
        private IEnumerator TurnOn()
        {
            WaitForSeconds wait = new WaitForSeconds(_delay);
            
            while (true)
            {
                Throw(_cubeSpawner.GetFreeCube());
                
                yield return wait;
            }
        }
        
        private void Throw(Cube cube)
        {
            cube.Refresh(GetRandomPosition());
        }

        private Vector3 GetRandomPosition()
        {
            float xPosition = Random.Range(_xMinPosition, _xMaxPosition);
            float yPosition = transform.position.y - 1;
            float zPosition = Random.Range(_zMinPosition, _zMaxPosition);

            return new Vector3(xPosition, yPosition, zPosition);
        }
    }
}