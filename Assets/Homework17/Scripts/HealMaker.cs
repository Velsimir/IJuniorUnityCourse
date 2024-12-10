using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealMaker : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Button _attackButton;
    private int _heal = 10;

    private void Awake()
    {
        _attackButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _attackButton.onClick.AddListener(Heal);
    }
    
    private void OnDisable()
    {
        _attackButton.onClick.RemoveListener(Heal);
    }

    private void Heal()
    {
        _health.Increase(_heal);
    }
}