using UnityEngine;

namespace Albee
{
    public class PlayerTaker : MonoBehaviour
    {
        [SerializeField] private Transform _takeItemPoint;
        [SerializeField] private float _sizeItemTaken;

        private bool _isItemTaken = false;

        private Item _item;

        private void Update()
        {
            if (_isItemTaken && _item != null)
            {
                _item.transform.position = _takeItemPoint.position;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Item item))
            {
                if (!_isItemTaken)
                {
                    _isItemTaken = true;

                    _item = item;

                    TryTakeItem(_item);
                }
            }

            if(collision.gameObject.TryGetComponent(out ItemPlace place))
            {
                if (_isItemTaken)
                {
                    _isItemTaken = false;

                    TryThrowItem(_item);
                }
            }
        }

        private void TryTakeItem(Item item)
        {
            if(item == null)
            {
                return;
            }

            item.transform.SetParent(transform);
            item.transform.localRotation = Quaternion.Euler(Vector3.zero);
            item.transform.localScale = Vector3.one * _sizeItemTaken;
        }

        private void TryThrowItem(Item item)
        {
            if(item == null)
            {
                return;
            }

            Destroy(item.gameObject);
        }
    }
}
