using UnityEngine;

public class ShapeRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Spin();
    }

    public void Spin()
    {
        transform.Rotate(Vector3.up, (_speed * Time.deltaTime));
    }
}
