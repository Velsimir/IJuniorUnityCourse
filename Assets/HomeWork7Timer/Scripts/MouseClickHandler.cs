using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Homework7
{
    public class MouseClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public static event Action OnMouseClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnMouseClick?.Invoke();
        }
    }
}