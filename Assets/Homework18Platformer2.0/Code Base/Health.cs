using System;
using UnityEngine;

namespace Homework18
{
    public class Health : MonoBehaviour
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float CurrentHealth { get; private set; }

        public event Action HealthChanged;
        public event Action HealthEnded; 

        public void SetMaxHealth(float maxHealth)
        {
            if (maxHealth > 0)
                MaxHealth = maxHealth;
            
            CurrentHealth = MaxHealth;
            
            HealthChanged?.Invoke();
        }

        public void Increase(int value)
        {
            if (value >= 0)
            {
                if (value + CurrentHealth > MaxHealth)
                    CurrentHealth = MaxHealth;
                else
                    CurrentHealth += value;

                HealthChanged?.Invoke();
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
                
                HealthChanged?.Invoke();
            }
        }
    }
}