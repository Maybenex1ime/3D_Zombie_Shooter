using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class WeaponSwitching : MonoBehaviour
    {
        [SerializeField] private InputActionReference _mouseScroll;
        public int selectedWeapon = 0;

        private void Start()
        {
            SelectWeapon();
        }

        private void Update()
        {
            Vector2 scrolling = _mouseScroll.action.ReadValue<Vector2>();
            if (scrolling.y > 0)
            {
                if (selectedWeapon >= transform.childCount - 1) selectedWeapon = 0;
                else selectedWeapon++;
                SelectWeapon();
            }
            if (scrolling.y < 0)
            {
                if (selectedWeapon <= 0) selectedWeapon = transform.childCount - 1;
                else selectedWeapon--;
                SelectWeapon();
            }
        }

        void SelectWeapon()
        {
            int i = 0;
            foreach (Transform weapon in transform)
            {
                if(i == selectedWeapon) 
                    weapon.gameObject.SetActive(true);
                else 
                    weapon.gameObject.SetActive(false);
                i++;
            }
        }
    }
}