using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private float _lerpTimer;
        public float _chipSpeed;
        public Image _frontHealthBar;
        public Image _backHealthBar;
        private CharController _player;
        private float health;
        private float maxHealth;

        private void Awake()
        {
            _player = FindObjectOfType<CharController>();
        }

        private void Start()
        {
            maxHealth = _player.transform.GetComponent<DamageReceiver>()._maxHP;
            health = _player.transform.GetComponent<DamageReceiver>()._currentHP;
        }

        void Update()
        {
            UpdateHealthUI();
        }

        public void UpdateHealthUI()
        {
            
            #region Update UI
            float fillB = _backHealthBar.fillAmount;
            float hFraction = health / maxHealth;
            if (fillB > hFraction)
            {
                _frontHealthBar.fillAmount = hFraction;
                _backHealthBar.color = Color.red;
                _lerpTimer += Time.deltaTime;
                float percentComplete = _lerpTimer / _chipSpeed;
                _backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
            }
            #endregion

            #region TakeDamage

            float HPCur = _player.transform.GetComponent<DamageReceiver>()._currentHP;
            if (health > HPCur) _lerpTimer = 0f;
            health = HPCur;

            #endregion
        }
    }
}