using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework19
{
    [RequireComponent(typeof(BoxCollider))]
    public class CubeThrower : MonoBehaviour
    {
        [SerializeField] private float _delay;

        private Collider _spawnArea;

        private float _xMinPosition;
        private float _xMaxPosition;
        private float _zMinPosition;
        private float _zMaxPosition;

        private ObjectSpawner<Cube> _cubeSpawner;
        private ObjectPool<Cube> _cubesPool;

        private Coroutine _coroutineTurnOn;

        public event Action<Cube> OnCubeSpawned;

        public void Initialize(ObjectSpawner<Cube> spawner, ObjectPool<Cube> pool)
        {
            _spawnArea = GetComponent<Collider>();
            _cubesPool = pool;
            _cubeSpawner = spawner;

            _xMinPosition = _spawnArea.bounds.min.x;
            _xMaxPosition = _spawnArea.bounds.max.x;
            _zMinPosition = _spawnArea.bounds.min.z;
            _zMaxPosition = _spawnArea.bounds.max.z;
        }

        public void StartWork()
        {
            if (_coroutineTurnOn != null)
            {
                StopCoroutine(_coroutineTurnOn);
                _coroutineTurnOn = null;
            }

            _coroutineTurnOn = StartCoroutine(TurnOn());
        }

        private IEnumerator TurnOn()
        {
            WaitForSeconds wait = new WaitForSeconds(_delay);

            Cube cube;
            
            while (true)
            {
                if (_cubesPool.HasFreeObject)
                {
                    cube = _cubesPool.GetFreeObject();
                    RefreshCubePosition(cube);
                    OnCubeSpawned?.Invoke(cube);
                }
                else
                {
                    cube = RefreshCubePosition(_cubeSpawner.Spawn());
                    _cubesPool.TrackNewObject(cube);
                    OnCubeSpawned?.Invoke(cube);
                }

                yield return wait;
            }
        }

    private Cube RefreshCubePosition(Cube cube)
    {
        cube.transform.position = GetRandomPosition();

        return cube;
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