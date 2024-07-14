using UnityEngine;

namespace Albee
{
    public class ItemsManager : MonoBehaviour
    {
        [SerializeField] private Item _item;
        [SerializeField] private ItemSpawner _itemSpawner;
        [SerializeField] private ItemPlace _itemPlace;
        [SerializeField] private ItemPlaceSpawner _itemPlaceSpawner;

        private void OnEnable()
        {
            _item.OnTake += OnItemTake;
            _itemPlace.OnEnter += OnItemPlaceEnter;
        }

        private void OnDisable()
        {
            _item.OnTake -= OnItemTake;
            _itemPlace.OnEnter -= OnItemPlaceEnter;
        }

        private void OnItemTake(Item item)
        {
            _itemPlaceSpawner.Spawn();
        }

        private void OnItemPlaceEnter(ItemPlace itemPlace)
        {
            itemPlace.Hide();
            _itemSpawner.Spawn();
        }
    }
}
