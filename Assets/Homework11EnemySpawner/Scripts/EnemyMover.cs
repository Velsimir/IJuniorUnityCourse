using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;

    private void Update()
    {
        Move();
    }

    public void Initilazie(float speed, Vector3 direction)
    {
        _speed = speed;
        _direction = direction;
    }

    private void Move()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
    }
}
