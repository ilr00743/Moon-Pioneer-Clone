using System;
using UnityEngine;

namespace Collectables
{
    public class Gear : CollectableComponent
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            ComponentType = ComponentType.Gear;
        }
    }
}