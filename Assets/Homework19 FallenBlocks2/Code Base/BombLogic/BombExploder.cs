using System.Collections.Generic;
using UnityEngine;

namespace Homework19.BombLogic
{
    public class BombExploder
    {
        private Rigidbody _rigidbody;
        private Timer _timer;
        private float _radius;
        private float _force;

        public BombExploder(Rigidbody rigidbody, float radius, float force)
        {
            _rigidbody = rigidbody;
            _radius = radius;
            _force = force;
        }

        public void StartWork(Timer timer)
        {
            _timer = timer;
            _timer.OnTimerEnd += Explode;
        }

        private void Explode()
        {
            foreach (var explosive in TryFindAllExplosiveObjects())
            {
                explosive.Rigidbody.AddExplosionForce(_force, _rigidbody.position, _radius);
            }
            
            _timer.OnTimerEnd -= Explode;
        }

        private List<IExplosive> TryFindAllExplosiveObjects()
        {
            List<IExplosive> explosiveObjects = new List<IExplosive>();

            Collider[] colliders = Physics.OverlapSphere(_rigidbody.position, _radius);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out IExplosive explosive))
                    explosiveObjects.Add(explosive);
            }

            return explosiveObjects;
        }
    }
}