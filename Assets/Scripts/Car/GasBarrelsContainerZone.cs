using System;
using Collectables;
using Player;
using UnityEngine;

namespace Car
{
    public class GasBarrelsContainerZone : BaseContainerZone<GasBarrel>
    {
        private Coroutine _coroutine;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerContainer playerContainer))
            {
                _coroutine = StartCoroutine(ReceiveComponent(playerContainer, ComponentType.Gas));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerContainer playerContainer))
            {
                if (_coroutine is not null)
                {
                    StopCoroutine(_coroutine);
                }
            }
        }
    }
}