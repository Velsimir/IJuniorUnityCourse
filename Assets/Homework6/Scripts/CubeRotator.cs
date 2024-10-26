using DefaultNamespace;
using UnityEngine;

public class CubeRotator : MonoBehaviour, IRotatable
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Rotate(Vector3.up, _speed);
    }

    public void Rotate(Vector3 rotation, float speed)
    {
        transform.Rotate(rotation, (speed * Time.deltaTime));
    }
}
