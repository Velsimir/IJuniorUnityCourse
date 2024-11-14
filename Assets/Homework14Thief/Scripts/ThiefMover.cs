using UnityEngine;

namespace Homework14
{
    [RequireComponent(typeof(InputHandler))]
    public class ThiefMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private InputHandler _inputHandler;
        private Vector3 _direction;

        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
        }

        private void OnEnable()
        {
            _inputHandler.DirectionChanging += SetDirection;
        }

        private void OnDisable()
        {
            _inputHandler.DirectionChanging -= SetDirection;
        }

        private void Update()
        {
            Move();
        }

        private void SetDirection(Vector2 direction)
        {
            _direction.x = direction.x;
            _direction.z = direction.y;
        }

        private void Move()
        {
            transform.Translate(_direction * (_speed * Time.deltaTime));
        }
    }
}
