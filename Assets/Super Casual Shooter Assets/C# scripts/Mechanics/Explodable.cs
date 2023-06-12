/*
    Written By Olusola Olaoye

    To only be used by those who purchased from the Unity asset store

*/


using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.DamageSender;
using UnityEngine;

[RequireComponent(typeof(DamageReceiver))]
[RequireComponent(typeof(DamageSender))]
public class git Explodable : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosion_particle; // particle for explosion
    
    [SerializeField]
    private int explosion_range_radius = 10; // at this range all rigidbodies will be affected and all damagables will be damaged

    [SerializeField]
    private int explosion_force = 20; // explosion force on rigid bodies

    [SerializeField]
    private int attack_value = 1; // damage on damagables


    public void nowExplode()
    {
        
        Instantiate(explosion_particle, transform.position, Quaternion.identity);

        foreach (Collider collider in Physics.OverlapSphere(transform.position, explosion_range_radius))
        {
            Rigidbody rigidbody_ = collider.GetComponent<Rigidbody>();
            if (rigidbody_)
            {
                rigidbody_.AddExplosionForce(explosion_force, transform.position, explosion_range_radius);
            }


            DamageReceiver damagable = collider.gameObject.GetComponent<DamageReceiver>();
            if (damagable)
            {
                damagable.Deal(attack_value);
            }

        }
    }
}

