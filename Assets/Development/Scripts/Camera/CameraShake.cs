using System.Collections;
using UnityEngine;
using Cinemachine;

namespace Albee
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;
        [SerializeField] private float _duration;
        [SerializeField] private PlayerHealth _playerHealth;

        private CinemachineBasicMultiChannelPerlin _multiChannelPerlin;

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
            _multiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            ShakeReset();
        }

        private void OnHealthChangedHandler(int health)
        {
            StartCoroutine(Shake(_duration));
        }

        private IEnumerator Shake(float duration)
        {
            _multiChannelPerlin.m_AmplitudeGain = _amplitude;
            _multiChannelPerlin.m_FrequencyGain = _frequency;

            yield return new WaitForSeconds(duration);

            ShakeReset();
        }

        private void ShakeReset()
        {
            _multiChannelPerlin.m_AmplitudeGain = 0;
            _multiChannelPerlin.m_FrequencyGain = 0;
        }
    }
}
