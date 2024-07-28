using UnityEngine;
using UnityEngine.Events;

namespace Albee
{
    public class PlayerHealth : MonoBehaviour
    {
        public UnityAction<int> OnHealthChanged;
        public int Health => _health;

        [SerializeField] private int _health;

        public void TryAddDamage(int health)
        {
            if(health > 0)
            {
                _health -= health;

                OnHealthChanged?.Invoke(_health);
            }
        }
    }
}
