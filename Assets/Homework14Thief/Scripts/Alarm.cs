using System.Collections;
using UnityEngine;

namespace Homework14
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(AudioSource))]
    public class Alarm : MonoBehaviour
    {
        private float _changingTime = 0.2f;
        private AudioSource _audioSource;
        private float _maxVolume = 1;
        private float _minVolume = 0;
        private bool _isActive;
        private Coroutine _changingVolume;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = _minVolume;
            _audioSource.Play();
            _audioSource.Pause();
        }

        private void OnTriggerEnter(Collider collider)
        {
            Thief thief = collider.gameObject.GetComponent<Thief>();

            if (thief != null)
            {
                TurnOn();

                _isActive = true;

                if (_changingVolume != null)
                    StopCoroutine(_changingVolume);
                
                _changingVolume = StartCoroutine(ChangingVolume());
            }
        }
        
        private void OnTriggerExit(Collider collider)
        {
            Thief thief = collider.gameObject.GetComponent<Thief>();

            if (thief != null)
            {
                _isActive = false;
                
                if (_changingVolume != null)
                    StopCoroutine(_changingVolume);
                
                _changingVolume = StartCoroutine(ChangingVolume());
            }
        }

        private IEnumerator ChangingVolume()
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
            float targetValue;

            if (_isActive)
                targetValue = _maxVolume;
            else
                targetValue = _minVolume;

            while (true)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _changingTime * Time.deltaTime);

                PauseAlarm();
                
                yield return wait;
            }
        }

        private void PauseAlarm()
        {
            if (_audioSource.volume <= _minVolume)
            {
                _audioSource.Pause();
                StopCoroutine(_changingVolume);
            }
        }

        private void TurnOn()
        {
            if (_audioSource.volume <= _minVolume)
                _audioSource.Play();
        }
    }
}