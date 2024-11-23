using System;
using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Coin : MonoBehaviour
    {
        public event Action<Coin> Collected;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>())
                Collect();
        }

        private void Collect()
        {
            Collected?.Invoke(this);
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }
    }
}