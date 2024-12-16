using System;
using UnityEngine;

namespace Homework18
{
    public class Health : MonoBehaviour, IValueProvide
    {
        [SerializeField] private float _speedUpdate;
        [SerializeField] private SliderSmoothView _sliderSmoothView;

        private float _maxHealth;

        public event Action HealthEnded;
        public event Action<float, float, float> ValueChanged;

        public float CurrentHealth { get; private set; }

        private void Awake()
        {
            _sliderSmoothView.Initialize(this);
        }

        public void SetMaxHealth(float maxHealth)
        {
            if (maxHealth > 0)
                _maxHealth = maxHealth;
            
            CurrentHealth = _maxHealth;
            
            ValueChanged?.Invoke(_maxHealth,CurrentHealth, 0);
        }

        public void Increase(float value)
        {
            if (value >= 0)
            {
                if (value + CurrentHealth > _maxHealth)
                    CurrentHealth = _maxHealth;
                else
                    CurrentHealth += value;

                ValueChanged?.Invoke(_maxHealth, CurrentHealth, _speedUpdate);
            }
        }

        public void Decrease(float value)
        {
            if (value >= 0)
            {
                if (CurrentHealth - value < 0)
                {
                    CurrentHealth = 0;
                    HealthEnded?.Invoke();
                }
                else
                {
                    CurrentHealth -= value;
                }
                
                ValueChanged?.Invoke(_maxHealth, CurrentHealth, _speedUpdate);
            }
        }
    }
}