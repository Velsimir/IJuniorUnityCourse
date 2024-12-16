using UnityEngine;
using UnityEngine.UI;

namespace Homework18
{
    [RequireComponent(typeof(Slider))]
    public class SliderView : MonoBehaviour
    {
        private float _maxValue;
        private Slider _slider;
        private float _sliderPercent;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _sliderPercent = (_slider.maxValue - _slider.minValue) / 100;
        }

        private float TransferToSliderValue(float maxValue, float targetValue, float fixedTime)
        {
            float currentHealthPercent = (targetValue / maxValue) * 100;
            
            return currentHealthPercent * _sliderPercent;
        }

        public void UpdateValue(float maxValue, float targetValue, float fixedTime)
        {
            _slider.value = TransferToSliderValue(maxValue, targetValue, fixedTime);
        }
    }
}