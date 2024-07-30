using UnityEngine;
using UnityEngine.UI;

namespace Albee
{
    public class ItemPointerDisplay : MonoBehaviour
    {
        [SerializeField] private Image _pointerIcon;
        [SerializeField] private float _alphaOpaque;

        private float _alphaTransparent = 0;

        private void Start()
        {
            SetTransparent(_alphaOpaque);
        }

        public void SetPosition(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        public void Hide()
        {
            SetTransparent(_alphaTransparent);
        }
        
        public void Show()
        {
            SetTransparent(_alphaOpaque);
        }

        private void SetTransparent(float alpha)
        {
            _pointerIcon.color = new Color(_pointerIcon.color.r, _pointerIcon.color.g, _pointerIcon.color.b, alpha);
        }
    }
}
