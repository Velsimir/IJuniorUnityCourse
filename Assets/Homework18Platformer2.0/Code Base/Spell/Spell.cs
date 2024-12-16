using System;
using System.Collections;
using UnityEngine;

namespace Homework18
{
    public abstract class Spell : MonoBehaviour
    {
        public float Cooldown { get; protected set; }
        public float Duration { get; protected set; }
        
        public event Action CastFinished;
        
        public abstract void Use(IHealable playerHealth);
        protected abstract IEnumerator Cast(IHealable playerHealth);

        protected void SendCastFinished()
        {
            CastFinished?.Invoke();
        }
    }
}