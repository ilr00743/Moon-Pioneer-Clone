using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _playerModel;
        private PlayerAnimation _animation;
        private Rigidbody _rigidbody;
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            _animation = GetComponent<PlayerAnimation>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction)
        {
            _playerModel.LookAt(_playerModel.position + direction);
            _rigidbody.velocity = direction * _speed;
            _animation.SetSpeed(direction.magnitude);
        }

        public void Stop()
        {
            _animation.SetSpeed(0);
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}