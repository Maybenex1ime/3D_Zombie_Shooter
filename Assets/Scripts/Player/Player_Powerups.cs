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
                if(effect.Duration <=0f ) RemoveEffect(effect);
                else effect.Duration -= Time.deltaTime;
            }
        }

        public void AddEffect(Interactable effect)
        {
            _effects.Add(effect);
        }

        private void RemoveEffect(Interactable effect)
        {
            effect.UnApply();
            _effects.Remove(effect);
        }
        
    }
}