using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework19
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Cube : MonoBehaviour, ICreatableObject, IDisappeared<Cube>, IExplosive
    {
        private Renderer _renderer;
        private CubeVisual _cubeVisual;
        private Timer _timer;
        private bool _isInteract;
        private float _minLifeTime = 2f;
        private float _maxLifeTime = 5f;

        public Rigidbody Rigidbody { get; private set; }
        
        public event Action<Cube> Disappeared;

        private void Update()
        {
            if (_isInteract)
                _timer.Update(Time.deltaTime);
        }

        public void Initialize()
        {
            _renderer = GetComponent<MeshRenderer>();
            Rigidbody = GetComponent<Rigidbody>();
            
            _cubeVisual = new CubeVisual(_renderer);
            _isInteract = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Floor floor))
                Interact();
        }

        private void Interact()
        {
            if (_isInteract)
                return;
            
            _cubeVisual.ChangeColor();

            _timer = new Timer(Random.Range(_minLifeTime, _maxLifeTime));
            _timer.OnTimerEnd += Disappear;
            
            _isInteract = true;
        }

        private void Disappear()
        {
            _timer.OnTimerEnd -= Disappear;
            _cubeVisual.SetOriginalColor();
            _isInteract = false;
            Disappeared?.Invoke(this);
        }
    }
}