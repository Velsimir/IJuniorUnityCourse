using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework8
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    public class Cube : MonoBehaviour
    {
        public event Action<Cube> OnExplode;
        
        private float _minValueChanceExplode = 0;
        private float _maxValueChanceExplode = 100;
        private float _chanceExplode = 200;
        private Rigidbody _rigidbody;
        private Renderer _renderer;
        private Vector3 _size;
        
        public Rigidbody Rigidbody => _rigidbody;
        public Vector3 Size => _size;
        public float ChanceExplode => _chanceExplode;

        public void Init(float chanceExplode, Color color, Vector3 size)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _renderer = GetComponent<Renderer>();
            _chanceExplode = chanceExplode;
            _renderer.material.color = color;
            _size = size;
        }

        public void Explode()
        {
            float randomValue = Random.Range(_minValueChanceExplode, _maxValueChanceExplode);

            if (randomValue < ChanceExplode)
            {
                Debug.Log($"Explode {randomValue} шанс взрыва {_chanceExplode}");
                OnExplode?.Invoke(this);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log($"Destroy {randomValue} шанс взрыва {_chanceExplode}");
                Destroy(gameObject);
            }
        }
    }
}