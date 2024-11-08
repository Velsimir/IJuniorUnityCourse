using System;
using UnityEngine;

namespace Homework10FallenBlocks
{
    [RequireComponent(typeof(CubeThrower))]
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private Cube _cubesPrefab;

        public event Action<Cube> CubeSpawned;
        
        private CubeThrower _cubeThrower;

        private void Awake()
        {
            _cubeThrower = GetComponent<CubeThrower>();
        }

        private void OnEnable()
        {
            _cubeThrower.FreeCubesEnded += Create;
        }

        private void OnDisable()
        {
            _cubeThrower.FreeCubesEnded -= Create;
        }

        public void Create()
        {
            CubeSpawned?.Invoke(Instantiate(_cubesPrefab));
        }
    }
}