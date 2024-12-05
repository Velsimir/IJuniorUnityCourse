using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Homework16_Main_Menu.Scripts
{
    public class VolumeChanger : MonoBehaviour
    {
        private const string MasterSoundVolume = "MasterSoundVolume";
        private const string BackgroundSoundVolume = "BackGroundSoundVolume";
        private const string EffectsSoundVolume = "EffectsSoundVolume";
        
        [SerializeField] private Slider _sliderMaserSoundVolume;
        [SerializeField] private Slider _sliderBackGroundSoundVolume;
        [SerializeField] private Slider _sliderEffectsSoundVolume;
        [SerializeField] private Toggle _toggleSoundSwitcher;
        [SerializeField] private AudioMixer _audioMixer;

        private float _amplitudeToDbMultiplier = 20f;
        private float _minVolume = -80f;
        private float _lastMasterVolume;

        private void OnEnable()
        {
            _sliderMaserSoundVolume.onValueChanged.AddListener(ChangeMasterSoundVolume);
            _sliderBackGroundSoundVolume.onValueChanged.AddListener(ChangeBackgroundSoundVolume);
            _sliderEffectsSoundVolume.onValueChanged.AddListener(ChangeEffectsSoundVolume);
            _toggleSoundSwitcher.onValueChanged.AddListener(SoundSwitcher);
        }
        
        private void OnDisable()
        {
            _sliderMaserSoundVolume.onValueChanged.RemoveListener(ChangeMasterSoundVolume);
            _sliderBackGroundSoundVolume.onValueChanged.RemoveListener(ChangeBackgroundSoundVolume);
            _sliderEffectsSoundVolume.onValueChanged.RemoveListener(ChangeEffectsSoundVolume);
            _toggleSoundSwitcher.onValueChanged.RemoveListener(SoundSwitcher);
        }

        private void ChangeMasterSoundVolume(float volume)
        {
            _lastMasterVolume = Mathf.Log10(volume) * _amplitudeToDbMultiplier;
            _audioMixer.SetFloat(MasterSoundVolume, _lastMasterVolume);
        }

        private void ChangeBackgroundSoundVolume(float volume)
        {
            _audioMixer.SetFloat(BackgroundSoundVolume, Mathf.Log10(volume) * _amplitudeToDbMultiplier);
        }

        private void ChangeEffectsSoundVolume(float volume)
        {
            _audioMixer.SetFloat(EffectsSoundVolume, Mathf.Log10(volume) * _amplitudeToDbMultiplier);
        }

        private void SoundSwitcher(bool flag)
        {
            if (flag)
                _audioMixer.SetFloat(MasterSoundVolume, _lastMasterVolume);
            else
                _audioMixer.SetFloat(MasterSoundVolume, _minVolume);
        }
    }
}