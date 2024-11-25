using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(EnemyMover))]
    [RequireComponent(typeof(EnemyCharacteristic))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class EnemyBase : MonoBehaviour
    {
    }
}