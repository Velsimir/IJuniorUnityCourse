using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerView : MonoBehaviour
{
    private TextMeshProUGUI _textCounter;

    private void Awake()
    {
        _textCounter = GetComponent<TextMeshProUGUI>();
        _textCounter.text = "";
    }

    private void OnEnable()
    {
        Timer.OnValueChanged += UpdateCounter;
    }

    private void OnDisable()
    {
        Timer.OnValueChanged -= UpdateCounter;
    }

    private void UpdateCounter(int value)
    {
        _textCounter.text = value.ToString();
    }
}