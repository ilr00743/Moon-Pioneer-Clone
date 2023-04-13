using System;
using System.Collections;
using System.Collections.Generic;
using Collectables;
using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Car
{
    public abstract class BaseContainerZone<T> : MonoBehaviour where T : ICollectable
    {
        [SerializeField] private int _requiredAmount;
        [SerializeField] private List<T> _components;
        [SerializeField] private int _currentAmount;
        private Transform _transform;
        private bool IsFull => _components.Count == _requiredAmount;

        protected void Start()
        {
            _transform = GetComponent<Transform>();
            _components = new List<T>();
        }

        protected IEnumerator ReceiveComponent(PlayerContainer playerContainer, ComponentType componentType)
        {
            while (true)
            {
                if (playerContainer.IsEmpty) yield break;
                
                var component = playerContainer.GiveComponentItem(componentType);
                if (component is null) yield break;
                
                _components.Add((T)component);
                component.Transform.SetParent(_transform);
                component.Transform.DOMove(_transform.position, 0.3f);
                component.Transform.DOScale(Vector3.zero, 0.3f)
                    .OnComplete(() => component.Transform.gameObject.SetActive(false));
                
                if (_currentAmount != _requiredAmount) _currentAmount++;
                
                yield return null;
            }
        }
    }
}