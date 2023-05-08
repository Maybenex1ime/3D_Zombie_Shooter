using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Interact
{
    public class Interactable : MonoBehaviour
    {
        public List<InteractEffect> _listEffect;
        public InteractEffect _interactEffect;
        public float rotationSpeed = 10f;

        private void Awake()
        {
            RandomEffect();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                _interactEffect.Apply(other.gameObject);
            }
        }

        private void Update()
        {
            transform.Rotate(Vector3.up,10f * Time.deltaTime);
        }

        private void RandomEffect()
        {
            if(this._interactEffect != null) return;
            int random = Random.Range(0, _listEffect.Count );
            _interactEffect = _listEffect[random];
            Instantiate(_interactEffect._model, this.transform.position,
                _interactEffect._model.transform.rotation, this.transform).transform.localScale = new Vector3(1, 1, 1);
        }
    }
}