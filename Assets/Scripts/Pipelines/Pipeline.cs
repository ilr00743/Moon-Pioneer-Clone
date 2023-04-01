using System;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Pipelines
{
    public class Pipeline : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _area;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement player))
            {
                Debug.Log("Enter");
                
                var currentScale = _area.transform.localScale;
                _area.transform.DOScale(new Vector3(currentScale.x + 1, currentScale.y + 1), 0.3f);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement player))
            {
                Debug.Log("Exit");

                var currentScale = _area.transform.localScale;
                _area.transform.DOScale(new Vector3(currentScale.x - 1, currentScale.y - 1), 0.3f);
            }
        }
    }
}