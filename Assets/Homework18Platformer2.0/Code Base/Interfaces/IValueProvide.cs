using System;

namespace Homework18
{
    public interface IValueProvide
    {
        public event Action<float,float,float> ValueChanged;
    }
}