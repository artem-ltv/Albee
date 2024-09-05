using UnityEngine;

namespace Albee
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Transform _player;

        [ContextMenu("Spawn")]
        public override void Spawn()
        {
            Vector3 randomPosition = GetRandomPosition();

            Enemy newEnemy = Instantiate(_enemy, randomPosition, Quaternion.identity);

            InitEnemy(newEnemy);
        }

        private void InitEnemy(Enemy enemy)
        {
            enemy.TryGetComponent(out EnemyMover mover);

            mover.SetTarget(_player);
        }
    }
}
