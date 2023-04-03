using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        [SerializeField] private Animator _animator;

        public void SetSpeed(float speed)
        {
            if (speed < 0)
            {
                throw new ArgumentException();
            }
            _animator.SetFloat(Speed, speed);
        }
    }
}