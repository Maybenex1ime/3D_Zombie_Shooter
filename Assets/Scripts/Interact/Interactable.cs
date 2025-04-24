using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Interact
{
    [RequireComponent(typeof(MeshFilter))]
    public class Interactable : MonoBehaviour
    {
        public List<InteractEffect> _listEffect;
        private InteractEffect _interactEffect;
        [SerializeField] private float rotationSpeed = 10f;
        private Mesh model;
        private MeshFilter _filter;
        private float _duration;

        public float Duration
        {
            get => _duration;
            set { _duration = value; }
        }
        
        public int DropChance
        {
            get { return _interactEffect._DropChance; }
        }

        private void Awake()
        {
            _filter = GetComponent<MeshFilter>();
            RandomEffect();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                _interactEffect.Apply(other.gameObject);
                Player_Powerups.instance.AddEffect(this);
            }
        }

        private void Update()
        {
            transform.Rotate(Vector3.up,10f * Time.deltaTime);
        }

        public void RandomEffect()
        {
            int random = Random.Range(0, _listEffect.Count );
            _interactEffect = _listEffect[random];
            _filter.mesh = _interactEffect._model;
        }

        public void UnApply()
        {
            _interactEffect.UnApply();
        }
    }
}