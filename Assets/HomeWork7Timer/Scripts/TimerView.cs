using TMPro;
using UnityEngine;

namespace Homework7
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(Timer))]
    public class TimerView : MonoBehaviour
    {
        private TextMeshProUGUI _textCounter;
        private Timer _timer;

        private void Awake()
        {
            _textCounter = GetComponent<TextMeshProUGUI>();
            _timer = GetComponent<Timer>();
            _textCounter.text = "";
        }

        private void OnEnable()
        {
            _timer.ValueChanged += UpdateCounter;
        }

        private void OnDisable()
        {
            _timer.ValueChanged -= UpdateCounter;
        }

        private void UpdateCounter(int value)
        {
            _textCounter.text = value.ToString();
        }
    }
}