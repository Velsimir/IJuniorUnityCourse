using DG.Tweening;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] private int _scaleTo;
    [SerializeField] private float _duration;

    private void Awake() => 
        ChangeScale();

    private void ChangeScale() => 
        transform.DOScale(_scaleTo, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
}
