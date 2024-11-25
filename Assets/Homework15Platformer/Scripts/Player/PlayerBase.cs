using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerCharacteristic))]
    [RequireComponent(typeof(PlayerVisual))]
    public class PlayerBase : MonoBehaviour
    {
    }
}