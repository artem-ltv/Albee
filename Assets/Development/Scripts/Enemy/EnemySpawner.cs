using System.Collections.Generic;
using UnityEngine;

namespace Albee
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Transform _player;
        [SerializeField] private ItemsManager _itemsManager;
        [SerializeField] private GameObject _poolContainer;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private EnemyCollection _enemyCollection;

        private ObjectPool<Enemy> _enemyPool;

        private void OnEnable()
        {
            _itemsManager.OnItemDeliveredToPlace += OnItemDeliveredToPlaceHandler;
            _enemyCollection.OnRemovedRandomEnemies += OnRemovedRandomEnemiesHandler;
        }

        private void OnDisable()
        {
            _itemsManager.OnItemDeliveredToPlace -= OnItemDeliveredToPlaceHandler;
            _enemyCollection.OnRemovedRandomEnemies += OnRemovedRandomEnemiesHandler;
        }

        private void Start()
        {
            _enemyPool = new ObjectPool<Enemy>(_enemy, _poolContainer, _poolCapacity);

            Spawn();
        }

        public override void Spawn()
        {
            Enemy newEnemy = _enemyPool.Get();

            newEnemy.OnHiding += BackInPool;

            _enemyCollection.Add(newEnemy);

            InitEnemy(newEnemy);
        }

        private void InitEnemy(Enemy enemy)
        {
            enemy.transform.position = GetRandomPosition();
            enemy.TryGetComponent(out EnemyMover mover);

            mover.SetTarget(_player);
        }

        private void BackInPool(Enemy enemy)
        {
            enemy.OnHiding -= BackInPool;

            _enemyPool.Release(enemy);
        }

        private void OnItemDeliveredToPlaceHandler()
        {
            Spawn();
        }

        private void OnRemovedRandomEnemiesHandler(List<Enemy> enemies)
        {
            foreach(var enemy in enemies)
            {
                BackInPool(enemy);
            }
        }
    }
}
