using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Albee
{
    public class FrameDamage : MonoBehaviour
    {
        [SerializeField] private Image _frame;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _alphaOpaque;
        [SerializeField] private PlayerHealth _playerHealth;

        private float _alphaTransparent = 0;

        private void OnEnable()
        {
            _playerHealth.OnHealthChanged += OnHealthChangedHandler;
        }

        private void OnDisable()
        {
            _playerHealth.OnHealthChanged -= OnHealthChangedHandler;
        }

        private void Start()
        {
            _frame.color = new Color(_frame.color.r, _frame.color.g, _frame.color.b, _alphaTransparent);
        }

        private void OnHealthChangedHandler(int health)
        {
            RunAnimation();
        }

        [ContextMenu("Fade")]
        public void RunAnimation()
        {
            _frame.color = new Color(_frame.color.r, _frame.color.g, _frame.color.b, _alphaOpaque);
            _frame.DOFade(_alphaTransparent, _animationDuration).SetEase(Ease.Linear);
        }
    }
}
