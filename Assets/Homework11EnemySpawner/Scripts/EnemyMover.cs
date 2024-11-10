using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed;

    private void Update()
    {
        MoveForward();
    }

    public void Initilazie(float speed)
    {
        _speed = speed;
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }
}
