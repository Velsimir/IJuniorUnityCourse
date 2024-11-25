using System;
using UnityEngine;

namespace Homework15
{
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