using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework9
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    public class Cube : MonoBehaviour
    {
        [SerializeField] private float _explodeForce;
        [SerializeField] private float _explodeRadius;
        
        private float _minValueChanceExplode = 0;
        private float _maxValueChanceExplode = 100;
        private Vector3 _size = Vector3.one * 2;
        private float _sizeMagnitude;
        private Rigidbody _rigidbody;
        private Renderer _renderer;
        
        public event Action<Cube> Disappearing;
        
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
            _sizeMagnitude = size.magnitude;
        }

        public void SelfDestruction()
        {
            float randomValue = Random.Range(_minValueChanceExplode, _maxValueChanceExplode);

            if (randomValue < ChanceExplode)
                Disappearing?.Invoke(this);
            else
                Explode();
            
            Destroy(gameObject);
        }
        
        private void Explode()
        {
            Vector3 explodePosition = transform.position;
            
            Collider[] allCollidersAround = Physics.OverlapSphere(explodePosition, _explodeRadius);

            foreach (var collider in allCollidersAround)
            {
                Cube cube = collider.GetComponent<Cube>();

                if (cube != null)
                    cube.Rigidbody.AddExplosionForce(IncreaceForce(), explodePosition, IncreaceRadius());
            }
        }

        private float IncreaceRadius()
        {
            return _explodeRadius / _sizeMagnitude;
        }
        
        private float IncreaceForce()
        {
            return _explodeForce / _sizeMagnitude;
        }
    }
}