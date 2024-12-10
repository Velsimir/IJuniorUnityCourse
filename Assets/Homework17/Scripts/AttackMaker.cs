using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AttackMaker : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Button _attackButton;
    private int _damage = 10;

    private void Awake()
    {
        _attackButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _attackButton.onClick.AddListener(Attack);
    }
    
    private void OnDisable()
    {
        _attackButton.onClick.RemoveListener(Attack);
    }

    private void Attack()
    {
        _health.Decrease(_damage);
    }
}