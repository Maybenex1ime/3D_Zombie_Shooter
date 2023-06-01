/*
    Written By Olusola Olaoye

    To only be used by those who purchased from the Unity asset store

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : Gun
{

    [SerializeField]
    private GameObject shoot_particle;


    protected override void shoot()
    {

        if (current_bullet > 0 && gameObject.activeSelf && is_in_players_pocket && PlayerInput.instance.mouse_left_click )
        {
            shoot_particle.SetActive(true);
            RaycastHit hit;

            
            current_bullet -= 1;

            if (Physics.Raycast(shoot_start_position.position, shoot_start_position.forward, out hit))
            {
                if (hit.collider.GetComponent<Damagable>())
                {
                    hit.collider.GetComponent<Damagable>().takeDamage((int)gun_damage);
                }
            }

        }
        else
        {
            shoot_particle.SetActive(false);
        }

    }



    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

}
