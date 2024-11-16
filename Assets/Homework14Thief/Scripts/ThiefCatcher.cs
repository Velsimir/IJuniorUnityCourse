using System;
using UnityEngine;

namespace Homework14
{
    [RequireComponent(typeof(BoxCollider))]
    public class ThiefCatcher : MonoBehaviour
    {
        public event Action ThiefGetIn;
        public event Action ThiefGetOut;
        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<Thief>(out Thief thief))
                ThiefGetIn?.Invoke();
        }
        
        private void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<Thief>(out Thief thief))
                ThiefGetOut?.Invoke();
        }
    }
}