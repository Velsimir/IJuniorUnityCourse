using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth { get; private set; } = 100;
    public float CurrentHealth { get; private set; }

    public event Action HealthChanged;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
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
                CurrentHealth = 0;
            else
                CurrentHealth -= value;
            
            HealthChanged?.Invoke();
        }
    }
}