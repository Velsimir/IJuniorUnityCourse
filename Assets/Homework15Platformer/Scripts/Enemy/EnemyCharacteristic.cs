using UnityEngine;

namespace Homework15
{
    public class EnemyCharacteristic : MonoBehaviour
    {
        [field: SerializeField] public int MaxHealth {get; private set;}
        [field: SerializeField] public float Speed {get; private set;}
        [field: SerializeField] public int Damage { get; private set; }
    }
}