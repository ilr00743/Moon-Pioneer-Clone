using DG.Tweening;
using UnityEngine;

namespace Collectables
{
    public abstract class CollectableComponent : MonoBehaviour, ICollectable
    {
        public ComponentType ComponentType { get; protected set; }
        public Transform Transform { get; private set; }

        protected virtual void OnEnable()
        {
            Transform = GetComponent<Transform>();
        }

        public virtual void ReplaceToContainer(Transform parent, Transform positionStorage)
        {
            Transform.SetParent(parent);
            Transform.DOLocalMove(positionStorage.localPosition, 0.2f);
            Transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}