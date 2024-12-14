using System;
using UnityEngine;

namespace Homework18
{
    public class ItemCatcher : MonoBehaviour
    {
        public event Action<Item> ItemCatched;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Item item))
                ItemCatched?.Invoke(item);
        }
    }
}