using System.Collections.Generic;
using UnityEngine;

namespace Homework10
{
    public class CubesPool : MonoBehaviour
    {
        [SerializeField] private List<Cube> _freeCubes;
        
        public bool HasFreeCubes { get { return _freeCubes.Count > 0; } }
        
        public Cube GetFreeCube()
        {
            Cube cube = _freeCubes[0];
            _freeCubes.Remove(cube);
            
            return cube;
        }

        public void AddFreeCube(Cube cube)
        {
            _freeCubes.Add(cube);
        }
    }
}