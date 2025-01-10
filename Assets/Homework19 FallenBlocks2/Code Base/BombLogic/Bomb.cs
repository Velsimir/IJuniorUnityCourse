using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework19.BombLogic
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Renderer))]
    public class Bomb : MonoBehaviour, ICreatableObject, IDisappeared<Bomb>
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _force;
        
        private Rigidbody _rigidbody;
        private Renderer _renderer;
        private BombVisual _visual;
        private BombExploder _exploder;
        private Timer _timer;

        private float _minTimeToExplode = 2f;
        private float _maxTimeToExplode = 5f;
        
        private bool _isActive;
        
        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _renderer = GetComponent<Renderer>();
            _visual = new BombVisual(_renderer);
            _exploder = new BombExploder(_rigidbody, _radius, _force);
        }
        
        public event Action<Bomb> Disappeared;
        
        private void Update()
        {
            if (_isActive == false)
                return;
            
            _visual.UpdateColorChange(Time.deltaTime);
            _timer.Update(Time.deltaTime);
        }

        public void StartWork()
        {
            float timeToExplode = Random.Range(_minTimeToExplode, _maxTimeToExplode);
            _timer = new Timer(timeToExplode);
            _timer.OnTimerEnd += Disappear;
            _visual.Refresh(timeToExplode);
            _exploder.StartWork(_timer);
            _isActive = true;
        }

        private void Disappear()
        {
            _isActive = false;
            _timer.OnTimerEnd -= Disappear;
            Disappeared?.Invoke(this);
        }
    }
}