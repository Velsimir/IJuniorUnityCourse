using System;
using UnityEngine;

namespace Homework18
{
    public class Item : MonoBehaviour
    {
        [field: SerializeField] public int Value {get; private set;}
        
        public event Action<Item> Collected;

        public void Collect()
        {
            Collected?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}