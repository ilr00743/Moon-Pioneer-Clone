using System.Collections;
using Collectables;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pipelines
{
    public class Pipeline : MonoBehaviour
    {
        [SerializeField] private CollectableComponent _component;
        [FormerlySerializedAs("_stackedComponent")] [SerializeField] private PipelineStackedComponentZone _stackedComponents;
        [SerializeField] private float _delay;

        private void OnEnable()
        {
            StartCoroutine(SpawnPerSeconds());
        }

        private IEnumerator SpawnPerSeconds()
        {
            var cooldown = new WaitForSeconds(_delay);
            while (true)
            {
                yield return cooldown;
                Spawn();
            }
        }

        private void Spawn()
        {
            if (_stackedComponents.IsFull) return;
            
            var obj = Instantiate(_component, _stackedComponents.transform);
            _stackedComponents.PlaceComponent(obj);
        }
    }
}