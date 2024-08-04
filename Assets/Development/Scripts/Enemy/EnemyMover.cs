using UnityEngine;
using UnityEngine.AI;

namespace Albee
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _moveSpeed;

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
    }
}
