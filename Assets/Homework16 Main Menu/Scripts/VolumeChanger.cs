using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Homework16_Main_Menu.Scripts
{
    public class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private List<SliderVolume> _sliderVolumes;
        [SerializeField] private Toggle _toggleSoundSwitcher;
        [SerializeField] private AudioMixer _audioMixer;

        private float _amplitudeToDbMultiplier = 20f;
        private float _minVolume = -80f;
        private Dictionary<string, float> _allSlidersParameters = new Dictionary<string, float>();

        private void OnEnable()
        {
            ConnectAllSliders();
            _toggleSoundSwitcher.onValueChanged.AddListener(ToggleAllSound);
        }
        
        private void OnDisable()
        {
            DisconnectAllSliders();
            _toggleSoundSwitcher.onValueChanged.RemoveListener(ToggleAllSound);
        }

        private void ConnectAllSliders()
        {
            foreach (var setting in _sliderVolumes)
            {
                setting.Slider.onValueChanged.AddListener(value => ChangeVolume(setting.MixerGroupParameter, value));
            }
        }

        private void DisconnectAllSliders()
        {
            foreach (var setting in _sliderVolumes)
            {
                setting.Slider.onValueChanged.RemoveAllListeners();
            }
        }

        private void ChangeVolume(string nameMixerGroup, float value)
        {
            float dbValue = Mathf.Log10(value) * _amplitudeToDbMultiplier;
            
            Debug.Log(nameMixerGroup + ": " + dbValue);
            _audioMixer.SetFloat(nameMixerGroup, dbValue);
        }

        private void ToggleAllSound(bool isOn)
        {
            string parameterName;
            float value;
            
            foreach (var setting in _sliderVolumes)
            {
                parameterName = setting.MixerGroupParameter;
                value = setting.Slider.value;

                if (isOn)
                {
                    value = _allSlidersParameters[parameterName];
                }
                else
                {
                    SaveVolumeParameter(parameterName, value);
                    value = _minVolume;
                }
                
                ChangeVolume(parameterName, value);
            }
        }

        private void SaveVolumeParameter(string parameter, float value)
        {
            _allSlidersParameters[parameter] = value;
        }
    }
}