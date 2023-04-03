using System.Collections;
using Player;
using UnityEngine;

namespace Pipelines
{
    public class Pipeline : MonoBehaviour
    {
        [SerializeField] private GameObject _component;
        [SerializeField] private PipelineStackedComponentZone _stackedComponent;
        private int _delay;

        private void OnEnable()
        {
            _delay = 3;
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
            if (_stackedComponent.IsFull) return;
            
            var obj = Instantiate(_component, _stackedComponent.transform);
            _stackedComponent.SetComponentPosition(obj);
        }
    }
}