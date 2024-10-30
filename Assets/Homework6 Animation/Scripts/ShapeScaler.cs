using UnityEngine;

namespace Homework6
{
    public class ShapeScaler : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            Increase();
        }

        private void Increase()
        {
            transform.localScale += Vector3.one * (_speed * Time.deltaTime);
        }
    }
}
