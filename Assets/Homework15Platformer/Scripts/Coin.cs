using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Coin : Item
    {
        public void Activate()
        {
            gameObject.SetActive(true);
        }
    }
}