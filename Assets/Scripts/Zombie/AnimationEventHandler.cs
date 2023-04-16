using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnFinish;


        private void AnimationFinishedTrigger() => OnFinish?.Invoke();
        
        
    }
}