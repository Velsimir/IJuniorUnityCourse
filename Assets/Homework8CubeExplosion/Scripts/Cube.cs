using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework8
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    public class Cube : MonoBehaviour
    {
        private float _minValueChanceExplode = 0;
        private float _maxValueChanceExplode = 100;
        private Vector3 _size = Vector3.one * 2;
        private Rigidbody _rigidbody;
        private Renderer _renderer;
        
        public event Action<Cube> Exploding;
        
        public Rigidbody Rigidbody => _rigidbody;
        public Vector3 Size => _size;
        public float ChanceExplode { get; private set; } = 200;

        public void Init(float chanceExplode, Color color, Vector3 size)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _renderer = GetComponent<Renderer>();
            ChanceExplode = chanceExplode;
            _renderer.material.color = color;
            transform.localScale = size;
            _size = transform.localScale;
        }

        public void Explode()
        {
            float randomValue = Random.Range(_minValueChanceExplode, _maxValueChanceExplode);

            if (randomValue < ChanceExplode)
                Exploding?.Invoke(this);
            
            Destroy(gameObject);
        }
    }
}