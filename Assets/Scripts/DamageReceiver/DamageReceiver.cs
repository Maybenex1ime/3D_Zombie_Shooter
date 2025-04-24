using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    
    [CustomEditor(typeof(DamageReceiver))]
    public class DamageReceiverEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DamageReceiver damageReceiver = (DamageReceiver)target;
            if (GUILayout.Button("Damage"))
            {
                damageReceiver.Deal(1);
            }
            if (GUILayout.Button("Heal"))
            {
                damageReceiver.Heal(1);
            }
            base.OnInspectorGUI();
        }
    } 
    public class DamageReceiver : MonoBehaviour
    {
        public int _maxHP;
        public int _currentHP;
        public Image healthbar;

        public void Reborn()
        {
            _currentHP = _maxHP;
        }

        public virtual void Deal(int damage)
        {
            _currentHP -= damage;
            if (this._currentHP < 0) _currentHP = 0;
            if(healthbar != null) healthbar.fillAmount = (float)_currentHP /  (float)_maxHP;
        }

        public bool isDead()
        {
            return _currentHP <= 0;
        }

        public void Heal(int heal)
        {
            _currentHP += heal;
            if (this._currentHP > this._maxHP) this._currentHP = _maxHP;
            if(healthbar != null) healthbar.fillAmount = (float)_currentHP /  (float)_maxHP;
        }
        
    }
}