using UnityEngine;
using UnityEngine.AI;

namespace Albee
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _damage;

        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = _moveSpeed;
        }

        private void Update()
        {
            _navMeshAgent.SetDestination(_player.position);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TryAddDamage(_damage);

                Hide();
            }
        }

        private void Hide()
        {
            Destroy(gameObject);
        }
    }
}
