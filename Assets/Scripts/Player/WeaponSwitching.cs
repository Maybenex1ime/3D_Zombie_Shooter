﻿using System;
using UnityEngine;

namespace Player
{
    public class WeaponSwitching : MonoBehaviour
    {
        public int selectedWeapon = 0;

        private void Start()
        {
            SelectWeapon();
        }

        private void Update()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (selectedWeapon >= transform.childCount - 1) selectedWeapon = 0;
                else selectedWeapon++;
                SelectWeapon();
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
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