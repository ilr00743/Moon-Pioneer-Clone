using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _playerModel;
        private Rigidbody _rigidbody;
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction)
        {
            _playerModel.LookAt(_playerModel.position + direction);
            _rigidbody.velocity = direction * _speed;
        }

        public void Stop()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}