using UnityEngine;

namespace Homework13
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        public void Fire(Vector3 direction, float power)
        {
            _rigidbody.linearVelocity = direction * power; 
        }
    }
}