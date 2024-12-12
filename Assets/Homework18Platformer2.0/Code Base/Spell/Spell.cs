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
        
        public abstract void Use();
        protected abstract IEnumerator Cast();

        protected void SendCastFinished()
        {
            CastFinished?.Invoke();
        }
    }
}