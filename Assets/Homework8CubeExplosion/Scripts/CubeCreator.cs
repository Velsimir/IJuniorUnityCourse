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
        
        private void Awake()
        {
            Create(_cubePrefab);
        }

        private void Create(Cube cubeExploded)
        {
            cubeExploded.Exploding -= Create;
            
            List<Rigidbody> rigidbodiesToExplode = new List<Rigidbody>();
            
            for (int i = 0; i < Random.Range(_minAmount, _maxAmount); i++)
            {
                Cube cube = Instantiate(_cubePrefab, cubeExploded.transform.position, cubeExploded.transform.rotation);
                cube.Exploding += Create;
                cube.Init(GetExplodeChance(cubeExploded), GetRandomColor(), GetNewSize(cubeExploded));
                
                rigidbodiesToExplode.Add(cube.Rigidbody);
            }
            
            Explode(cubeExploded, rigidbodiesToExplode);
        }

        private void Explode(Cube cube, List<Rigidbody> rigidbodyToExplode)
        {
            foreach (var rigidbody in rigidbodyToExplode)
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
            float devider = 2;

            return cube.ChanceExplode / devider;
        }

        private Vector3 GetNewSize(Cube cube)
        {
            float devider = 2;

            return new Vector3(cube.Size.x / devider, cube.Size.y / devider, cube.Size.z / devider);
        }
    }
}