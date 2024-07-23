using UnityEngine;
using TMPro;

namespace Albee
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthTextDisplay;
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            _playerHealth.OnHealthChanged += OnHealthChangedHandler;
        }

        private void OnDisable()
        {
            _playerHealth.OnHealthChanged -= OnHealthChangedHandler;
        }

        private void OnHealthChangedHandler(int health)
        {
            _healthTextDisplay.SetText(health.ToString());
        }
    }
}
