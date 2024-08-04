using UnityEngine;

namespace Albee
{
    [RequireComponent(typeof(EnemyAttacker))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject[] _skins;

        private EnemyAttacker _attacker;

        private void Awake()
        {
            _attacker = GetComponent<EnemyAttacker>();
        }

        private void OnEnable()
        {
            _attacker.OnAttacked += OnAttackedHandler;
        }

        private void OnDisable()
        {
            _attacker.OnAttacked -= OnAttackedHandler;
        }

        private void Start()
        {
            //HideAllSkins();
            //EnableRandomSkin();
        }

        private void OnAttackedHandler()
        {
            Hide();
        }

        private void Hide()
        {
            // Изменить
            Destroy(gameObject);
        }

        private void HideAllSkins()
        {
            foreach(var skin in _skins)
            {
                skin.SetActive(false);
            }
        }

        private void EnableRandomSkin()
        {
            int randomIndex = Random.Range(0, _skins.Length);

            _skins[randomIndex].SetActive(true);
        }
    }
}
