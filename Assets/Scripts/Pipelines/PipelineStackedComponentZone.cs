using System.Collections;
using System.Collections.Generic;
using Collectables;
using Player;
using UnityEngine;

namespace Pipelines
{
    public class PipelineStackedComponentZone : MonoBehaviour
    {
        [SerializeField] private Transform[] _placeholders;
        private List<ICollectable> _components;
        private Coroutine _giveComponentsRoutine;
        private int _placeholderIndex;
        public bool IsFull { get; private set; }

        private void OnEnable()
        {
            _components = new List<ICollectable>();
            IsFull = false;
            _placeholderIndex = 0;
        }

        private void Update()
        {
            IsFull = _components.Count >= _placeholders.Length;
        }

        public void PlaceComponent(ICollectable component)
        {
            _components.Add(component);
            component.Transform.localPosition = _placeholders[_placeholderIndex].localPosition;
            _placeholderIndex++;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerContainer playerStackContainer))
            {
                _giveComponentsRoutine = StartCoroutine(GiveComponents(playerStackContainer));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerContainer _))
            {
                if (_giveComponentsRoutine is not null)
                {
                    StopCoroutine(_giveComponentsRoutine);
                }
            }
        }

        private IEnumerator GiveComponents(PlayerContainer playerContainer)
        {
            while (true)
            {
                if (_components.Count == 0 || playerContainer.IsFull)
                {
                    yield return new WaitUntil(() => _components.Count != 0);
                    yield return new WaitUntil(() => playerContainer.IsFull == false);
                }

                playerContainer.ReceiveComponent(_components[^1]);
                _components.RemoveAt(_components.IndexOf(_components[^1]));
                _placeholderIndex--;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}