using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework10
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(CubesPool))]
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private Cube _cubesPrefab;

        private CubesPool _cubesPool;
        private Collider _spawnArea;
        private float _xMinPosition;
        private float _xMaxPosition;
        private float _zMinPosition;
        private float _zMaxPosition;
        
        private void Awake()
        {
            _spawnArea = GetComponent<Collider>();
            _cubesPool = GetComponent<CubesPool>();
            
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
                Cube cube;
                
                if (_cubesPool.HasFreeCubes)
                    cube = _cubesPool.GetFreeCube();
                else
                    cube = Create();
                
                cube.Disappeared += DeactivateCube;

                Throw(cube);
                
                yield return wait;
            }
        }
        
        private void Throw(Cube cube)
        {
            cube.Refresh(GetRandomPosition());
        }

        private Cube Create()
        {
            Cube cube = Instantiate(_cubesPrefab);
            
            return cube;
        }

        private void DeactivateCube(Cube cube)
        {
            cube.Disappeared -= DeactivateCube;
            _cubesPool.AddFreeCube(cube);
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