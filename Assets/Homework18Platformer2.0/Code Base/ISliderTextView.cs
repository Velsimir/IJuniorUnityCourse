using UnityEngine;
using TMPro;

namespace Homework18
{
    [RequireComponent(typeof(TMPro.TextMeshProUGUI))]
    public class ISliderTextView : MonoBehaviour, ISliderView
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateValue(float maxValue, float targetValue, float fixedTime)
        {
            _text.text = $"Здоровье {targetValue}/ {maxValue}";
        }
    }
}