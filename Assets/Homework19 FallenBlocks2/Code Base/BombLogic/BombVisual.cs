using UnityEngine;

namespace Homework19.BombLogic
{
    public class BombVisual
    {
        private Renderer _renderer;
        private Color _standartColor = new Color(0,0,0,1);
        private float _fadeStep;
        private float _currentAlpha;

        public BombVisual(Renderer renderer)
        {
            _renderer = renderer;
        }

        public void UpdateColorChange(float deltaTime)
        {
            _currentAlpha -= _fadeStep * deltaTime;
            _renderer.material.color = new Color(_standartColor.r,_standartColor.g,_standartColor.b, _currentAlpha);

            if (_currentAlpha < 0)
                _currentAlpha = 0;
        }

        public void Refresh(float fadeDuration)
        {
            _fadeStep = 1 / fadeDuration;
            _renderer.material.color = _standartColor;
            _currentAlpha = _renderer.material.color.a;
        }
    }
}