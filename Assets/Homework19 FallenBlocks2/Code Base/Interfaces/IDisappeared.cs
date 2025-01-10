using System;
using UnityEngine;

namespace Homework19
{
    public interface IDisappeared<T> where T : MonoBehaviour
    {
        public event Action<T> Disappeared;
    }
}