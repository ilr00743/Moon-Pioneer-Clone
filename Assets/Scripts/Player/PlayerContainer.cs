using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Collectables;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerStackContainer : MonoBehaviour
    {
        [SerializeField] private List<Transform> _placeholders;
        [SerializeField] private Transform _parent;
        private List<ICollectable> _components;
        private int _placeholderIndex;
        private Coroutine _giveComponentsRoutine;
        public bool IsFull => _components.Count - 1 == _placeholders.Count - 1;

        private void Start()
        {
            _components = new List<ICollectable>();
        }

        public void ReceiveComponent(ICollectable component)
        {
            if (IsFull) return;
            
            _components.Add(component);
            component.Transform.SetParent(_parent);
            component.Transform.DOLocalMove(_placeholders[_placeholderIndex].localPosition, 0.2f);
            component.Transform.localRotation = Quaternion.Euler(0, 0, 0);
            _placeholderIndex++;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out CarZone carZone))
            {
                _giveComponentsRoutine = StartCoroutine(GiveComponents(carZone));
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent(out CarZone carZone))
            {
                if (_giveComponentsRoutine is not null) 
                {
                    StopCoroutine(_giveComponentsRoutine);
                }
            }
        }

        /*private IEnumerator GiveComponents(CarZone carZone)
        {
            while (_components.Count != 0)
            {
                if (carZone.IsFull)
                {
                    yield break;
                }
                
                carZone.ReceiveComponent(_components[^1]);
                Destroy(_components[^1].Transform.gameObject);
                _components.RemoveAt(_components.IndexOf(_components[^1]));
                _placeholderIndex--;
                yield return new WaitForSeconds(0.2f);
            }

            yield return null;
        }*/

        public ICollectable GetComponent()
        {
            return _components.FirstOrDefault(x=> x.ComponentType == ComponentType.Gas);
        }
    }
}