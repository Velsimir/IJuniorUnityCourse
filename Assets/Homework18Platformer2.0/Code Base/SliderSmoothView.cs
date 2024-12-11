using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Homework18
{
    public class SliderSmoothView : MonoBehaviour, ISliderView
    {
        [SerializeField] private float _speed;

        private float _currentValue;
        private float _maxValue;
        private Slider _slider;
        private float _sliderPercent;
        private Coroutine _coroutineChangeValue;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _sliderPercent = (_slider.maxValue - _slider.minValue) / 100;
        }

        public void Initialize(float maxValue)
        {
            _maxValue = maxValue;
        }

        public void UpdateValue(float value)
        {
            if (_coroutineChangeValue != null)
            {
                StopCoroutine(_coroutineChangeValue);
                _coroutineChangeValue = null;
            }
            
            _coroutineChangeValue = StartCoroutine(ChangeValue(value));
        }

        private float TransferToSliderValue(float value)
        {
            float currentHealthPercent = (value / _maxValue) * 100;
            
            return currentHealthPercent * _sliderPercent;
        }
        
        private IEnumerator ChangeValue(float value)
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
            
            while (true)
            {
                _slider.value = Mathf.MoveTowards(_slider.value,TransferToSliderValue(value), Time.deltaTime * _speed);
                
                yield return wait;
            }
        }
    }
}