using UnityEngine;
using DG.Tweening;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private int _highPoint;

    private void Awake() => 
        MoveTo();

    private void MoveTo() => 
        transform.DOMoveY(_highPoint, _duration).SetLoops(-1, LoopType.Yoyo);
}
