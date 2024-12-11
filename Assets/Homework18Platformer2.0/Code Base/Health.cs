using System;
using NUnit.Framework;
using UnityEngine;

namespace Homework18
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private SliderSmoothView _sliderSmoothView;
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public event Action HealthEnded;

        private void Awake()
        {
            _sliderSmoothView.Initialize(MaxHealth);
        }

        public void SetMaxHealth(float maxHealth)
        {
            if (maxHealth > 0)
                MaxHealth = maxHealth;
            
            CurrentHealth = MaxHealth;
            
            _sliderSmoothView.UpdateValue(CurrentHealth);
        }

        public void Increase(int value)
        {
            if (value >= 0)
            {
                if (value + CurrentHealth > MaxHealth)
                    CurrentHealth = MaxHealth;
                else
                    CurrentHealth += value;

                _sliderSmoothView.UpdateValue(CurrentHealth);
            }
        }

        public void Decrease(int value)
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
                
                _sliderSmoothView.UpdateValue(CurrentHealth);
            }
        }
    }
}