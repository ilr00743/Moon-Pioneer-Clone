using UnityEngine;

namespace Collectables
{
    public class GasBarrel : CollectableComponent
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            ComponentType = ComponentType.Gas;
        }

        public override void ReplaceToContainer(Transform parent, Transform positionStorage)
        {
            base.ReplaceToContainer(parent, positionStorage);
            Transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }
}