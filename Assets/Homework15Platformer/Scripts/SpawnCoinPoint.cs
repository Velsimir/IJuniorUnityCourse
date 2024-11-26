using UnityEngine;

namespace Homework15
{
    public class SpawnCoinPoint : MonoBehaviour
    {
        public bool IsEmpty { get; private set; }

        public void Activate()
        {
            IsEmpty = false;
        }

        public void Deactivate()
        {
            IsEmpty = true;
        }
    }
}