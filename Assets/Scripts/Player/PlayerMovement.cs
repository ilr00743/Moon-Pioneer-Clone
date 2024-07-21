using Player.Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _playerModel;
        [SerializeField] private JoystickInput _joystickInput;
        private CharacterController _characterController;
        private PlayerAnimation _animation;
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            _animation = GetComponent<PlayerAnimation>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move(_joystickInput.InputDirection);
        }
        
        public void Move(Vector3 inputDirection)
        {
            if (inputDirection == Vector3.zero)
            {
                Stop();
            }

            _playerModel.LookAt(_playerModel.position + inputDirection);
            _characterController.Move(inputDirection *_speed * Time.deltaTime);
            _animation.SetSpeed(inputDirection.magnitude);
        }

        public void Stop()
        {
            _animation.SetSpeed(0);
            _characterController.Move(Vector3.zero);
        }
    }
}