using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Collectables;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerContainer : MonoBehaviour
    {
        [SerializeField] private List<Transform> _placeholders;
        [SerializeField] private Transform _parent;
        private List<ICollectable> _components;
        [SerializeField] private int _placeholderIndex;
        public bool IsFull => _components.Count == _placeholders.Count;
        public bool IsEmpty => _components.Count == 0;

        private void Start()
        {
            _components = new List<ICollectable>();
        }

        public void ReceiveComponent(ICollectable component)
        {
            if (IsFull) return;

            _components.Add(component);
            component.ReplaceToContainer(_parent, _placeholders[_placeholderIndex]);
            _placeholderIndex++;
        }

        public ICollectable GiveComponentItem(ComponentType componentType)
        {
            var component = _components.LastOrDefault(x => x.ComponentType == componentType);
            _components.Remove(component);
            _placeholderIndex = _placeholderIndex <= 0 ? _placeholderIndex = 0 : --_placeholderIndex;
            return component;
        }
    }
}