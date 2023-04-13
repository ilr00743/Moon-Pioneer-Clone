using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ComponentCounter : MonoBehaviour
    {
        [SerializeField] private ComponentType _componentType;
        private TMP_Text _text;
        private int _currentRequiredAmount;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void SetRequiredAmount(int amount)
        {
            _currentRequiredAmount = amount <= 0 ? 0 : amount;
            _text.text = $"{_componentType}: {_currentRequiredAmount}";
        }
    }
}