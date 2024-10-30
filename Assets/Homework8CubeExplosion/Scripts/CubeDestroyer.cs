using UnityEngine;

namespace Homework8
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
                if (hit.transform.GetComponent<Cube>())
                {
                    hit.transform.GetComponent<Cube>().Explode();
                }
            }
        }
    }
}