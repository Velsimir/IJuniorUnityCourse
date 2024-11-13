using System.Collections;
using UnityEngine;

namespace Homework13
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Target _target;
        [SerializeField] private float _power;
        [SerializeField] float _delay;
        
        private void Start() 
        {
            StartCoroutine(AutoShootLoop());
        }
        
        private IEnumerator AutoShootLoop()
        {
            while (true)
            {
                Shoot();
                
                yield return new WaitForSeconds(_delay);
            }
        }

        private void Shoot()
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            
            Vector3 direction = _target.transform.position - transform.position;
            
            bullet.Fire(direction.normalized, _power);
        }
    }
}