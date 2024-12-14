using System.Security.Cryptography;
using UnityEngine;

namespace Homework18
{
    [CreateAssetMenu(menuName = "Character/Characteristic", fileName = "newCharacteristic", order = 1)]
    public class CharacteristicSo : ScriptableObject
    {
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
    }
}