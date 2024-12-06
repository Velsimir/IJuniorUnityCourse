using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSoundMaker : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonSound;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(MakeSound);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(MakeSound);
    }

    private void MakeSound()
    {
        _buttonSound.Play();
    }
}
