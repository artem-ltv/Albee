using UnityEngine;

namespace Albee
{
    public class ItemSpawner : Spawner
    {
        [SerializeField] private Item _item;

        private void Start()
        {
            Spawn();
        }

        public override void Spawn()
        {
            _item.transform.localScale = Vector3.one;
            _item.transform.position = GetRandomPosition();
            _item.gameObject.SetActive(true);
        }
    }
}
