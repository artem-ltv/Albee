using UnityEngine;

namespace Albee
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerMover _playerMover;

        private void FixedUpdate()
        {
            Vector3 direction = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);

            if (direction != Vector3.zero)
            {
                _playerMover.Move(direction);
                _playerMover.Rotate(direction);
            }
            else
            {
                _playerMover.Stop();
            }
        }
    }
}
