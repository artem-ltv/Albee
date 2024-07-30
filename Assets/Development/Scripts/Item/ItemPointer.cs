using UnityEngine;

namespace Albee
{
    public class ItemPointer : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _item;
        [SerializeField] private Camera _camera;
        [SerializeField] private ItemPointerDisplay _pointerIcon;

        private int _frustumCount = 4;
        private int _planeIndex = 0;

        private void Update()
        {
            if(_item == null || _player == null)
            {
                return;
            }

            Vector3 directionToItem = _item.position - _player.position;
            Ray ray = new Ray(_player.position, directionToItem);
            Debug.DrawRay(_player.position, directionToItem);

            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

            float minDistance = Mathf.Infinity;

            for (int i = 0; i < _frustumCount; i++)
            {
                if(planes[i].Raycast(ray, out float distance))
                {
                    if(distance < minDistance)
                    {
                        minDistance = distance;
                        _planeIndex = i;
                    }
                }
            }

            minDistance = Mathf.Clamp(minDistance, 0, directionToItem.magnitude);

            Vector3 worldPosition = ray.GetPoint(minDistance);

            Vector3 iconPosition = _camera.WorldToScreenPoint(worldPosition);
            Quaternion iconRotation = GetIconRotation(_planeIndex);

            _pointerIcon.SetPosition(iconPosition, iconRotation);

            if(directionToItem.magnitude > minDistance)
            {
                _pointerIcon.Show();
            }
            else
            {
                _pointerIcon.Hide();
            }
        }

        public void SetItem(Transform item)
        {
            _item = item;
        }

        private Quaternion GetIconRotation(int planeIndex)
        {
            switch (planeIndex)
            {
                case 0: return Quaternion.Euler(0, 0, 90);
                case 1: return Quaternion.Euler(0, 0, -90);
                case 2: return Quaternion.Euler(0, 0, 180);
                case 3: return Quaternion.Euler(0, 0, 0);

                default: return Quaternion.identity;
            }
        }
    }
}
