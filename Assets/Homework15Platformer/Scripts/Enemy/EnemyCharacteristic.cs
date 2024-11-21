using UnityEngine;

namespace Homework15
{
    public class EnemyCharacteristic : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        public float Speed => _speed;
    }
}