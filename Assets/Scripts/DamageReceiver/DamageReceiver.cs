using UnityEngine;

namespace DefaultNamespace
{
    public class DamageReceiver : MonoBehaviour
    {
        [SerializeField] private int _maxHP;
        [SerializeField] private int _currentHP;

        public void Reborn()
        {
            _currentHP = _maxHP;
        }

        public void Deal(int damage)
        {
            _currentHP -= damage;
            if (this._currentHP < 0) this._currentHP = 0;
        }

        public bool isDead()
        {
            return _currentHP <= 0;
        }
        
    }
}