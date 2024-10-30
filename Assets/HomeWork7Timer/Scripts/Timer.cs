using System;
using System.Collections;
using UnityEngine;

namespace Homework7
{
    [RequireComponent(typeof(MouseClickHandler))]
    [RequireComponent(typeof(TimerView))]
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _delay;

        public event Action<int> ValueChanged;

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
            if (_increaseValue != null)
            {
                StopCoroutine(_increaseValue);
                _increaseValue = null;
            }
            else
            {
                _increaseValue = StartCoroutine(IncreaceValue());
            }
        }

        private IEnumerator IncreaceValue()
        {
            WaitForSeconds waitDelay = new WaitForSeconds(_delay);

            while (true)
            {
                _value++;
                ValueChanged?.Invoke(_value);
                yield return waitDelay;
            }
        }
    }
}
