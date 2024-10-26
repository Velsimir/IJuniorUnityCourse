using DefaultNamespace;
using UnityEngine;

public class CubeMover : MonoBehaviour, IMovable, IRotatable
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speedMovement;

    private void Update()
    {
        Rotate(Vector3.up, _speedRotation);
        MoveForward(_speedMovement);
    }

    public void MoveForward(float speed)
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    public void Rotate(Vector3 rotation, float speed)
    {
        transform.Rotate(rotation, (speed * Time.deltaTime));
    }
}
