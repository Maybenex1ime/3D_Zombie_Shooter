using UnityEngine;

namespace Interact
{
    public abstract class InteractEffect : ScriptableObject
    {
        public string _EffectName;
        public int _DropChance;
        public Mesh _model;
        public float _duration;
        public abstract void Apply(GameObject target);
        public abstract void UnApply();
    }
}