using UnityEngine;

namespace Player.Input
{
    public class JoystickInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Joystick _joystick;
        
        public Vector3 InputDirection { get; private set; }

        private void Awake()
        {
            UnityEngine.Input.multiTouchEnabled = false;
        }

        private void Update()
        {
            InputDirection = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);  
        }
    }
}