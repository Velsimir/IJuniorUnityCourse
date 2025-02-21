using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework10
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Cube : MonoBehaviour
    {
        public event Action<Cube> Disappeared;
        
        private Renderer _renderer;
        private bool _isInteract = false;
        private Color _originalColor;
        private float _lifeTime;
        
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _originalColor = _renderer.material.color;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_isInteract == false && other.gameObject.GetComponent<Floor>())
                Interact();
        }

        public void Refresh(Vector3 position)
        {
            transform.position = position;
            _renderer.material.color = _originalColor;
            _isInteract = false;
            _lifeTime = 0;
            gameObject.SetActive(true);
        }

        private void Interact()
        {
            _lifeTime = GetRandomLifeTime();
            ChangeColor();
            StartCoroutine(DisableAfterLifeTime());
        }

        private void ChangeColor()
        {
            _renderer.material.color = GetRandomColor();
            _isInteract = true;
        }

        private float GetRandomLifeTime()
        {
            float minValue = 2;
            float maxValue = 5;
            
            return Random.Range(minValue, maxValue); 
        }

        private Color GetRandomColor()
        {
            float red = Random.Range(0f, 1f);
            float green = Random.Range(0f, 1f); 
            float bloe = Random.Range(0f, 1f);
            
            return new Color(red, green, bloe);
        }

        private IEnumerator DisableAfterLifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);
            
            Disappeared?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}