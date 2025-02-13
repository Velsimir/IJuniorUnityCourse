using UnityEngine;
using DG.Tweening;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _rotation;

    private void Awake() =>
        Rotate();

    private void Rotate() => 
        transform.DORotate(_rotation, _duration).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
}
