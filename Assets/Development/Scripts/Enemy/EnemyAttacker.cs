using UnityEngine;
using UnityEngine.Events;

namespace Albee
{
    public class EnemyAttacker : MonoBehaviour
    {
        public UnityAction OnAttacked;

        [SerializeField] private int _damage;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TryAddDamage(_damage);

                OnAttacked?.Invoke();
            }
        }
    }
}
