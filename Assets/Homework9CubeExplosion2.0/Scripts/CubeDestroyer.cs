using UnityEngine;

namespace Homework9
{
    [RequireComponent(typeof(RaycastClickHandler))]
    public class CubeDestroyer : MonoBehaviour
    {
        private RaycastClickHandler _raycastClickHandler;

        private void Awake()
        {
            _raycastClickHandler = GetComponent<RaycastClickHandler>();
        }

        private void OnEnable()
        {
            _raycastClickHandler.RaycastsGot += Destroy;
        }

        private void OnDisable()
        {
            _raycastClickHandler.RaycastsGot -= Destroy;
        }

        private void Destroy(RaycastHit[] raycastHits)
        {
            foreach (var hit in raycastHits)
            {
                Cube cube = hit.collider.GetComponent<Cube>();
                
                if (cube != null)
                    cube.SelfDestruction();
            }
        }
    }
}