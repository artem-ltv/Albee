using UnityEngine;

namespace Albee
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private GameObject _poolContainer;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private Transform _player;
        [SerializeField] private ItemsManager _itemsManager;

        private ObjectsPool<Enemy> _enemyPool;

        private void OnEnable()
        {
            _itemsManager.OnItemDeliveredToPlace += Spawn;
        }

        private void OnDisable()
        {
            _itemsManager.OnItemDeliveredToPlace -= Spawn;
        }

        private void Start()
        {
            _enemyPool = new ObjectsPool<Enemy>(_enemy, _poolContainer, _poolCapacity);

            Spawn();
        }

        public override void Spawn()
        {
            Enemy newEnemy = _enemyPool.Get();

            InitEnemy(newEnemy);
        }

        private void InitEnemy(Enemy enemy)
        {
            enemy.transform.position = GetRandomPosition();

            enemy.TryGetComponent(out EnemyMover mover);

            mover.SetTarget(_player);
        }
    }
}
