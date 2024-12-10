using System;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemyAggression : MonoBehaviour
    {
        public event Action<Player> PlayerIn;
        public event Action PlayerOut;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
                PlayerIn?.Invoke(player);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
                PlayerOut?.Invoke();
        }
    }
}