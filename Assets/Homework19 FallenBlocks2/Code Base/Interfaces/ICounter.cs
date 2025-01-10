using System;

namespace Homework19
{
    public interface ICounter
    {
        public event Action NewObjectAdded;
        public event Action ObjectSent;
        public int Count { get; }
    }
}