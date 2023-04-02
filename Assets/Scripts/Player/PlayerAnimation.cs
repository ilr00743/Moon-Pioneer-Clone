using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetSpeed(float speed)
        {
            if (speed < 0)
            {
                throw new ArgumentException();
            }
            _animator.SetFloat("Speed", speed);
        }
    }
}