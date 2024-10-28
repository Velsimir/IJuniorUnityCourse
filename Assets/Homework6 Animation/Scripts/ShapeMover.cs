using UnityEngine;

public class ShapeMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        MoveForward();
    }

    public void MoveForward()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }
}
