using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed;
    private bool _isMoving;
    
    private void Update()
    {
        if (_isMoving)
            Move();
    }

    public void StartMove(float speed)
    {
        _isMoving = true;
        _speed = speed;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }
}
