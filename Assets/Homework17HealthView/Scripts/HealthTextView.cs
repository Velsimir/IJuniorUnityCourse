using UnityEngine;
using TMPro;

namespace Homework17.Scripts
{
    [RequireComponent(typeof(TMPro.TextMeshProUGUI))]
    public class HealthTextView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Health _health;
        
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _health.HealthChanged += UpdateHealth;
        }

        private void Start()
        {
            UpdateHealth();
        }
        
        private void OnDisable()
        {
            _health.HealthChanged -= UpdateHealth;
        }

        public void UpdateHealth()
        {
            _text.text = $"Здоровье {_health.CurrentHealth}/ {_health.MaxHealth}";
        }
    }
}