using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Interact
{
    public class Interactable : MonoBehaviour
    {
        public List<InteractEffect> _listEffect;
        public InteractEffect _interactEffect;
        public float rotationSpeed = 10f;
        public float _duration;
        public GameObject model;

        private void Awake()
        {
            RandomEffect();
            _duration = _interactEffect._duration;
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
            if(model != null) Destroy(model); 
            model = Instantiate(_interactEffect._model, this.transform.position,
                _interactEffect._model.transform.rotation, this.transform);
            model.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}