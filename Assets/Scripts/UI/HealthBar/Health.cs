using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace UI.HealthBar
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _duration;
        private Image _healthBar;
        private float _normalizeHeath = 1f;

        private float _currentHealth;

        private void Awake()
        {
            _healthBar = GetComponentInChildren<HealthBar>().GetComponent<Image>();
            _healthBar.fillAmount = _normalizeHeath;
        }

        public void Init(float healthOnStart)
        {
            _currentHealth = healthOnStart;
            
        }

        public async UniTaskVoid ShowHealth(float heath)
        {
            await _healthBar.DOFillAmount(_normalizeHeath, _duration);
        }

        
    }
    
}