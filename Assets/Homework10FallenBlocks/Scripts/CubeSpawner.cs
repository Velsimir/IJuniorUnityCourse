using System.Collections.Generic;
using UnityEngine;

namespace Homework10
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private Cube _cubesPrefab;
        [SerializeField] private List<Cube> _freeCubes;
        
        public Cube GetFreeCube()
        {
            Cube cube;
            
            if (_freeCubes.Count > 0)
            {
                cube = _freeCubes[0];
                _freeCubes.Remove(cube);
                cube.Disappeared += AddFreeCube;
                return cube;
            }
            else
            {
                cube = Create();
                cube.Disappeared += AddFreeCube;
                return cube;
            }
        }

        private Cube Create()
        {
            return Instantiate(_cubesPrefab);
        }

        private void AddFreeCube(Cube cube)
        {
            _freeCubes.Add(cube);
            cube.Disappeared -= AddFreeCube;
        }
    }
}