using UnityEngine;

namespace Albee
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 directon)
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(directon, 1) * _moveSpeed;
        }

        public void Rotate(Vector3 direction)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotationSpeed); 
        }

        public void Stop()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
