using UnityEngine;
using UnityEngine.AI;

namespace Albee
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        private Transform _player;
        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = GetRandomSpeed();
        }

        private void Update()
        {
            if(_player != null)
            {
                _navMeshAgent.SetDestination(_player.position);
            }
        }

        public void SetTarget(Transform player)
        {
            _player = player;
        }

        private float GetRandomSpeed()
        {
            return Random.Range(_minSpeed, _maxSpeed);
        }
    }
}
