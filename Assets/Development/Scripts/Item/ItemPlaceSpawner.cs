using UnityEngine;

namespace Albee
{
    public class ItemPlaceSpawner : Spawner
    {
        [SerializeField] private ItemPlace _itemPlace;

        public override void Spawn()
        {
            _itemPlace.transform.position = GetRandomPosition();
            _itemPlace.gameObject.SetActive(true);
        }
    }
}
