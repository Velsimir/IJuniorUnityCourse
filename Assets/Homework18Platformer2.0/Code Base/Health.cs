using System;
using UnityEngine;

namespace Homework18
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private SliderSmoothView _sliderSmoothView;
        [SerializeField] private float _speedUpdate;
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public event Action HealthEnded;

        public void SetMaxHealth(float maxHealth)
        {
            if (maxHealth > 0)
                MaxHealth = maxHealth;
            
            CurrentHealth = MaxHealth;
            
            _sliderSmoothView.UpdateValue(MaxHealth,CurrentHealth, 0);
        }

        public void Increase(float value)
        {
            if (value >= 0)
            {
                if (value + CurrentHealth > MaxHealth)
                    CurrentHealth = MaxHealth;
                else
                    CurrentHealth += value;

                _sliderSmoothView.UpdateValue(MaxHealth, CurrentHealth, _speedUpdate);
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
                
                _sliderSmoothView.UpdateValue(MaxHealth, CurrentHealth, _speedUpdate);
            }
        }
    }
}