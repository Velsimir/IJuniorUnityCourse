using System.Collections;
using UnityEngine;

namespace Homework14
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(ThiefCatcher))]
    public class AlarmSoundSwitcher : MonoBehaviour
    {
        private float _changeTimeDelay = 0.2f;
        private AudioSource _audioSource;
        private ThiefCatcher _thiefCatcher;
        private float _maxVolume = 1;
        private float _minVolume = 0;
        private Coroutine _changingVolume;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _thiefCatcher = GetComponent<ThiefCatcher>();
            _audioSource.volume = _minVolume;
            _audioSource.Play();
            _audioSource.Pause();
        }

        private void OnEnable()
        {
            _thiefCatcher.ThiefGetIn += TurnOn;
            _thiefCatcher.ThiefGetOut += TurnOff;
        }

        private void OnDisable()
        {
            _thiefCatcher.ThiefGetIn -= TurnOn;
            _thiefCatcher.ThiefGetOut -= TurnOff;
        }

        private IEnumerator ChangingVolume()
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
            float targetValue;
            
            if (_changingVolume != null)
                targetValue = _minVolume;
            else
                targetValue = _maxVolume;

            while (true)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _changeTimeDelay * Time.deltaTime);

                if (_audioSource.volume <= _minVolume)
                {
                    _audioSource.Pause();
                    StopCoroutine(_changingVolume);
                }
                
                yield return wait;
            }
        }

        private void TurnOn()
        {
            if (_audioSource.volume <= _minVolume)
                _audioSource.Play();
            
            Increase();
        }

        private void TurnOff()
        {
            Decrease();
        }

        private void Decrease()
        {
            StopCoroutine(_changingVolume);
            _changingVolume = StartCoroutine(ChangingVolume());
        }

        private void Increase()
        {
            if (_changingVolume != null)
            {
                StopCoroutine(_changingVolume);
                _changingVolume = null;
            }
            
            _changingVolume = StartCoroutine(ChangingVolume());
        }
    }
}