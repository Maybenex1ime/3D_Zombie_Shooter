using System;
using System.Collections.Generic;
using Interact;
using UnityEngine;

namespace Player
{
    public class Player_Powerups : MonoBehaviour
    {
        public List<Interactable> _effects = new List<Interactable>();
        public static Player_Powerups instance;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            instance = this;
        }

        private void Update()
        {
            foreach (Interactable effect in _effects.ToArray())
            {
                if(effect._duration <=0f ) RemoveEffect(effect);
                else effect._duration -= Time.deltaTime;
            }
        }

        public void AddEffect(Interactable effect)
        {
            _effects.Add(effect);
        }

        private void RemoveEffect(Interactable effect)
        {
            effect._interactEffect.UnApply();
            _effects.Remove(effect);
        }
        
    }
}