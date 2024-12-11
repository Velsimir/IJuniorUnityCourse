using UnityEngine;
using TMPro;

namespace Homework18
{
    [RequireComponent(typeof(TMPro.TextMeshProUGUI))]
    public class ISliderTextView : MonoBehaviour, ISliderView
    {
        private float _maxValue;
        private float _currentValue;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void Initialize(float maxValue)
        {
            _maxValue = maxValue;
        }

        public void UpdateValue(float value)
        {
            _text.text = $"Здоровье {_currentValue}/ {_maxValue}";
        }
    }
}