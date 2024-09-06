using UnityEngine;
using UnityEngine.Events;

namespace Albee
{
    [RequireComponent(typeof(EnemyAttacker))]
    public class Enemy : MonoBehaviour
    {
        public UnityAction<Enemy> OnHiding;

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
            HideAllSkins();
            EnableRandomSkin();
        }

        private void OnAttackedHandler()
        {
            OnHiding?.Invoke(this);
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
