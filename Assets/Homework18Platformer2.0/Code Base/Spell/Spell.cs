using System;
using System.Collections;
using UnityEngine;

namespace Homework18
{
    public abstract class Spell : MonoBehaviour
    {
        public float Cooldown { get; protected set; }
        
        public event Action CastFinished;
        
        public abstract void Use(SliderSmoothView sliderSmoothView);
        protected abstract IEnumerator Cast(SliderSmoothView sliderSmoothView);

        protected void SendCastFinished()
        {
            CastFinished?.Invoke();
        }
    }
}