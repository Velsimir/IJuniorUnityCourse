using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Homework18
{
    public class SliderSmoothView : MonoBehaviour, ISliderView
    {
        private float _currentValue;
        private Slider _slider;
        private float _sliderPercent;
        private Coroutine _coroutineChangeValue;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _sliderPercent = (_slider.maxValue - _slider.minValue) / 100;
        }

        public void UpdateValue(float maxValue, float targetValue, float fixedTime)
        {
            if (_coroutineChangeValue != null)
            {
                StopCoroutine(_coroutineChangeValue);
                _coroutineChangeValue = null;
            }
            
            _coroutineChangeValue = StartCoroutine(IncreaseValue(maxValue, targetValue, fixedTime));
        }

        private float TransferToSliderValue(float maxValue, float targetValue)
        {
            float currentHealthPercent = (targetValue / maxValue) * 100;
            
            return currentHealthPercent * _sliderPercent;
        }

        private IEnumerator IncreaseValue(float maxValue, float targetValue, float fixedTime)
        {
            WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
            float startSliderValue = _slider.value;
            float targetSliderValue = TransferToSliderValue(maxValue, targetValue);
            float elapsedTime = 0f;
            
            while (startSliderValue != targetSliderValue)
            {
                elapsedTime += Time.deltaTime;
                
                _slider.value = Mathf.Lerp(startSliderValue, targetSliderValue, elapsedTime / fixedTime);
                yield return waitForEndOfFrame;
            }
        }
    }
}