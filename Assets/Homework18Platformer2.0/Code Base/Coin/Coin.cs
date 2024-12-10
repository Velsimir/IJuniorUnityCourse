using UnityEngine;

namespace Homework18
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