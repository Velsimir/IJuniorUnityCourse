using UnityEngine;

namespace Homework18
{
    public class ItemCatcher : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Item item))
            {
                switch (item)
                {
                    case Coin coin:
                        coin.Collect();
                        break;
                    
                    case HealthBag healthBag:
                        healthBag.Collect();
                        _player.IncreaseHealth(healthBag.Value);
                        break;
                }
            }
        }
    }
}