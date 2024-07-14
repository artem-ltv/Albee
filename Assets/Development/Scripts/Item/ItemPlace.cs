using UnityEngine;
using UnityEngine.Events;

namespace Albee
{
    public class ItemPlace : MonoBehaviour
    {
        public UnityAction<ItemPlace> OnEnter;

        private void Start()
        {
            Hide();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerTaker playerTaker))
            {
                OnEnter?.Invoke(this);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
