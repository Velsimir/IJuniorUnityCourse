using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework8
{
    public class CubeCreator : MonoBehaviour
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private int _minAmount;
        [SerializeField] private int _maxAmount;
        [SerializeField] private float _explodeForce;
        [SerializeField] private float _explodeRadius;
        
        private List<Rigidbody> _rigidbodiesToExplode;

        private void Awake()
        {
            Create(_cubePrefab);
        }

        private void Create(Cube cubeExploded)
        {
            cubeExploded.OnExplode -= Create;
            
            _rigidbodiesToExplode = new List<Rigidbody>();
            
            for (int i = 0; i < Random.Range(_minAmount, _maxAmount); i++)
            {
                Cube cube = Instantiate(_cubePrefab, cubeExploded.transform.position, cubeExploded.transform.rotation);
                cube.OnExplode += Create;
                cube.Init(GetExplodeChance(cubeExploded), GetRandomColor(), GetNewSize(cubeExploded));
                
                _rigidbodiesToExplode.Add(cube.Rigidbody);
                
                Explode(cube);
            }
        }

        private void Explode(Cube cube)
        {
            foreach (var rigidbody in _rigidbodiesToExplode)
            {
                rigidbody.AddExplosionForce(_explodeForce, cube.transform.position, _explodeRadius);
            }
        }

        private Color GetRandomColor()
        {
            float red = Random.Range(0f, 1f);
            float green = Random.Range(0f, 1f);
            float blue = Random.Range(0f, 1f);
            
            return new Color(red, green, blue);
        }

        private float GetExplodeChance(Cube cube)
        {
            float halfDevider = 2;

            return cube.ChanceExplode / halfDevider;
        }

        private Vector3 GetNewSize(Cube cube)
        {
            float halfDevider = 2;
            
            Vector3 newSize = new Vector3(cube.Size.x / halfDevider, cube.Size.y / halfDevider, cube.Size.z / halfDevider);

            return newSize;
        }
    }
}