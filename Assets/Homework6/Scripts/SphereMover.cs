using DefaultNamespace;
using UnityEngine;

public class SphereMover : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        MoveForward(_speed);
    }

    public void MoveForward(float speed)
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
