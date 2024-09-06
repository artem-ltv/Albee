using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Albee
{
    public class EnemyCollection : MonoBehaviour
    {
        public UnityAction<List<Enemy>> OnRemovedRandomEnemies;

        [SerializeField] private List<Enemy> _enemies;

        private int _minCountForRandomRemove = 3;

        public void Add(Enemy enemy)
        {
            _enemies.Add(enemy);

            enemy.OnHiding += Remove;
        }

        private void TryRemoveRandom(int count)
        {
            if (count < _enemies.Count && count <= _minCountForRandomRemove)
            {
                List<Enemy> enemiesRemove = new List<Enemy>();

                for(int i = 0; i < count; i++)
                {
                    int randomIndex = Random.Range(0, _enemies.Count);

                    Enemy enemyRemove = _enemies[randomIndex];

                    enemiesRemove.Add(enemyRemove);

                    Remove(enemyRemove);
                }

                OnRemovedRandomEnemies?.Invoke(enemiesRemove);
            }
        }

        private void Remove(Enemy enemy)
        {
            enemy.OnHiding -= Remove;

            _enemies.Remove(enemy);
        }
    }
}
