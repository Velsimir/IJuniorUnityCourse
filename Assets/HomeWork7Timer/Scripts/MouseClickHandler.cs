using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickHandler : MonoBehaviour, IPointerClickHandler
{
    public static event Action OnMouseClick;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnMouseClick?.Invoke();
    }
}