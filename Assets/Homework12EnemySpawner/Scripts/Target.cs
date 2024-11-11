using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework12
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private List<Point> _points;

        private Point _currentPoint;
        private float _speed = 5f;
        private float _minDistance = 0.1f;

        private void Awake()
        {
            ChangePoint();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.transform.position, Time.deltaTime * _speed);

            if (Vector3.Distance(transform.position, _currentPoint.transform.position) < _minDistance)
                ChangePoint();
        }

        private void ChangePoint()
        {
            _currentPoint = _points[Random.Range(0, _points.Count)];
        }
    }
}