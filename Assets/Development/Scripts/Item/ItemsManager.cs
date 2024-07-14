using UnityEngine;
using UnityEngine.Events;

namespace Albee
{
    public class ItemsManager : MonoBehaviour
    {
        public UnityAction OnItemDeliveredToPlace;

        [SerializeField] private Item _item;
        [SerializeField] private ItemSpawner _itemSpawner;
        [SerializeField] private ItemPlace _itemPlace;
        [SerializeField] private ItemPlaceSpawner _itemPlaceSpawner;

        private void OnEnable()
        {
            _item.OnTake += OnItemTakeHandler;
            _itemPlace.OnEnter += OnItemPlaceEnterHandler;
        }

        private void OnDisable()
        {
            _item.OnTake -= OnItemTakeHandler;
            _itemPlace.OnEnter -= OnItemPlaceEnterHandler;
        }

        private void OnItemTakeHandler(Item item)
        {
            _itemPlaceSpawner.Spawn();
        }

        private void OnItemPlaceEnterHandler(ItemPlace itemPlace)
        {
            OnItemDeliveredToPlace?.Invoke();

            itemPlace.Hide();

            _itemSpawner.Spawn();
        }
    }
}
