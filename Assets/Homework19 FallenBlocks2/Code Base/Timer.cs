using System;

namespace Homework19
{
    public class Timer
    {
        private float _timeToEnd;
        private bool _isActive;

        public Timer(float timeToEnd)
        {
            _timeToEnd = timeToEnd;
            _isActive = true;
        }

        public event Action OnTimerEnd;
        
        public void Update(float deltaTime)
        {
            if (_isActive == false)
                return;
            
            _timeToEnd -= deltaTime;

            if (_timeToEnd <= 0)
            {
                OnTimerEnd?.Invoke();
                _isActive = false;
            }
        }
    }
}