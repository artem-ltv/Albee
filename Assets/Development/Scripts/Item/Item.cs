using UnityEngine;
using UnityEngine.Events;

namespace Albee
{
    public class Item : MonoBehaviour
    {
        public UnityAction<Item> OnTake;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out PlayerTaker playerTaker))
            {
                OnTake?.Invoke(this);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
