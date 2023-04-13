using UnityEngine;

namespace Collectables
{
    public interface ICollectable
    {
        ComponentType ComponentType { get; }
        Transform Transform { get;}
        void ReplaceToContainer(Transform parent, Transform positionStorage);
    }
}