using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework19
{
    public class CubeVisual
    {
        private Renderer _renderer;
        private Color _originalColor;

        public CubeVisual(Renderer renderer)
        {
            _renderer = renderer;
            _originalColor = _renderer.material.color;
        }

        public void SetOriginalColor()
        {
            _renderer.material.color = _originalColor;
        }

        public void ChangeColor()
        {
            _renderer.material.color = GetRandomColor();
        }

        private Color GetRandomColor()
        {
            float red = Random.Range(0f, 1f);
            float green = Random.Range(0f, 1f);
            float bloe = Random.Range(0f, 1f);

            return new Color(red, green, bloe);
        }
    }
}