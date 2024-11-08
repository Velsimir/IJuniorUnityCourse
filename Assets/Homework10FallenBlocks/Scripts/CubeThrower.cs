using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework10FallenBlocks
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(CubeSpawner))]
    public class CubeThrower : MonoBehaviour
    {
        [SerializeField] private List<Cube> _freeCubes;
        [SerializeField] private float _delay;

        public event Action FreeCubesEnded;
        
        private Collider _spawnArea;
        private float _xMinPosition;
        private float _xMaxPosition;
        private float _zMinPosition;
        private float _zMaxPosition;
        private CubeSpawner _cubeSpawner;
        
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

        private void OnEnable()
        {
            _cubeSpawner.CubeSpawned += AddCube;
        }

        private void OnDisable()
        {
            _cubeSpawner.CubeSpawned -= AddCube;
        }
        
        private IEnumerator TurnOn()
        {
            WaitForSeconds wait = new WaitForSeconds(_delay);
            
            while (true)
            {
                Cube cube = GetFreeCube();

                if (cube != null)
                    Throw(cube);
                else
                    FreeCubesEnded?.Invoke();
                
                yield return wait;
            }
        }

        private void AddCube(Cube cube)
        {
            cube.Disappeared -= AddCube;
            _freeCubes.Add(cube);
        }

        private void Throw(Cube cube)
        {
            cube.Disappeared += AddCube;
            cube.Refresh(GetRandomPosition());
            _freeCubes.Remove(cube);
        }

        private Cube GetFreeCube()
        {
            if (_freeCubes.Count > 0)
                return _freeCubes[0];
            else
                return null;
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