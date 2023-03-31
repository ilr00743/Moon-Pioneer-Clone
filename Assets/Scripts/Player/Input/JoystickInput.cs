using UnityEngine;

namespace Player.Input
{
    public class JoystickInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Joystick _joystick;

        private void Awake()
        {
            UnityEngine.Input.multiTouchEnabled = false;
        }

        private void Update()
        {
            if (_joystick.Direction == Vector2.zero)
            {
                _playerMovement.Stop();
                return;
            }
            var direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
            _playerMovement.Move(direction);  
        }
    }
}