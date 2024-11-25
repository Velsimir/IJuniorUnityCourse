using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class HealthBag : MonoBehaviour
    {
        [SerializeField] private int _healthPoint;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                player.IncreaseHealth(_healthPoint);
                Destroy(gameObject);
            }
        }
    }
}