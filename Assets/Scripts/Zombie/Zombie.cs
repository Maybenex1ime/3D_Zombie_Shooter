using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    private CharController _player;
    private ZombieDie _die;
    public GameObject _orientation;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        _player = FindObjectOfType<CharController>();
        _die = GetComponent<ZombieDie>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_die.BeDead())
        {
            navMeshAgent.SetDestination(_player.transform.position);
            transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
        }
    }

    public void Stop()
    {
        navMeshAgent.SetDestination(this.transform.position);
    }
}