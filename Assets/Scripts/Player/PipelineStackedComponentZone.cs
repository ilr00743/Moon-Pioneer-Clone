using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PipelineStackedComponentZone : MonoBehaviour
    {
        [SerializeField] private Transform[] _positions;
        private int _capacity;
        public bool IsFull { get; private set; }

        private void OnEnable()
        {
            IsFull = false;
            _capacity = _positions.Length-1;
        }

        public void SetComponentPosition(GameObject component)
        {
            if (_capacity < 0)
            {
                IsFull = true;
                Debug.Log("Full Stack");
                return;
            }

            component.transform.localPosition = _positions[_capacity].localPosition;
            _capacity--;
        }
    }
}