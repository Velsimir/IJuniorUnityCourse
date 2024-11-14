using UnityEngine;

namespace Homework13
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform _pointHolder;
        
        private Point[] _arrayPlaces;
        private Vector3 _currentPoint;
        private float _speed;
        private float _minDistance;
        private int _currentPointSequenceNumber;

        private void Awake()
        {
            _arrayPlaces = GetAllPoints();
            _currentPoint = GetNextPoint();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint, _speed * Time.deltaTime);

            if (transform.position.IsEnoughDistance(_currentPoint, _minDistance))
                _currentPoint = GetNextPoint();
        }

        private Vector3 GetNextPoint(){
            _currentPointSequenceNumber++;

            if (_currentPointSequenceNumber == _arrayPlaces.Length)
                _currentPointSequenceNumber = 0;
            
            return _arrayPlaces[_currentPointSequenceNumber].transform.position;
        }

        private Point[] GetAllPoints()
        {
            Point[] arrayPlaces = new Point[_pointHolder.childCount];

            for (int i = 0; i < _pointHolder.childCount; i++)
                _arrayPlaces[i] = _pointHolder.GetChild(i).GetComponent<Point>();

            return arrayPlaces;
        }
    }
}