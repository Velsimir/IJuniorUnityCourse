using System;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemyAggression : MonoBehaviour
    {
        public event Action<ITarget> TargetIn;
        public event Action TargetOut;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ITarget target))
                TargetIn?.Invoke(target);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ITarget target))
                TargetOut?.Invoke();
        }
    }
}