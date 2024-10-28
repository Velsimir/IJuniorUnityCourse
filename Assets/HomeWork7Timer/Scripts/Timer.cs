using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MouseClickHandler))]
[RequireComponent(typeof(TimerView))]
public class Timer : MonoBehaviour
{
    [SerializeField] private float _delay;

    public static event Action<int> OnValueChanged;
    
    private int _value;
    private Coroutine _increaseValue;

    private void OnEnable()
    {
        MouseClickHandler.OnMouseClick += SwitchStatus;
    }
    
    private void OnDisable()
    {
        MouseClickHandler.OnMouseClick += SwitchStatus;
    }

    private void SwitchStatus()
    {
        if (_increaseValue == null)
        {
            _increaseValue = StartCoroutine(IncreaceValue());
        }
        else
        {
            StopCoroutine(_increaseValue);
            _increaseValue = null;
        }
    }

    private IEnumerator IncreaceValue()
    {
        WaitForSeconds waitDelay = new WaitForSeconds(_delay);
        
        while (true)
        {
            _value++;
            OnValueChanged?.Invoke(_value);
            yield return waitDelay;
        }
    }
}
