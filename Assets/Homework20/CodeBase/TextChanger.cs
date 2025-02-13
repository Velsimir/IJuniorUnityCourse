using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private string _textToChange;
    [SerializeField] private float _duration;
    
    private Text _text;
    private Sequence _sequence;

    private void Awake()
    {
        _text = GetComponent<Text>();
        
        ChangeText();
    }

    private void ChangeText()
    {
        _sequence = DOTween.Sequence();
        
        _sequence.Append(_text.DOText(_textToChange, _duration));
        _sequence.Append(_text.DOText(_textToChange, _duration).SetRelative());
        _sequence.Append(_text.DOText(_textToChange, _duration, false, ScrambleMode.All));
    }
}
