using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ObjectColorChanger : MonoBehaviour
{
    [SerializeField] private Color _newColor;
    [SerializeField] private float _duration;
    
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        ChangeColor();
    }

    private void ChangeColor()
    {
        _renderer.material.DOColor(_newColor, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}