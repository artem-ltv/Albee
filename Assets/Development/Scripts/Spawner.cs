using UnityEngine;

namespace Albee
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected Transform[] SpawnPoints;

        protected Vector3 GetRandomPosition()
        {
            int randomIndex = Random.Range(0, SpawnPoints.Length);

            Transform randomPoint = SpawnPoints[randomIndex];

            return randomPoint.position;
        }

        public abstract void Spawn();
    }
}
