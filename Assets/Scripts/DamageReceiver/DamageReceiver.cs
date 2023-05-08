using UnityEngine;

namespace DefaultNamespace
{
    public class DamageReceiver : MonoBehaviour
    {
        public int _maxHP;
        public int  _currentHP;

        public void Reborn()
        {
            _currentHP = _maxHP;
        }

        public virtual void Deal(int damage)
        {
            _currentHP -= damage;
            if (this._currentHP < 0) this._currentHP = 0;
        }

        public bool isDead()
        {
            return _currentHP <= 0;
        }

        public void Heal(int heal)
        {
            _currentHP += heal;
            if (this._currentHP > this._maxHP) this._currentHP = _maxHP;
        }
        
    }
}