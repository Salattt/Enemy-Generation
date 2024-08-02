using System.Collections.Generic;
using UnityEngine;

public class PointMover : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _error;

    private Transform _transform;
    private int _currentPoint = 0;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_points.Count > 0)
        {
            Vector3 direction = _points[_currentPoint].Position - _transform.position;

            _transform.position += direction.normalized * _speed * Time.deltaTime;

            if(direction.magnitude < _error)
            {
                _currentPoint++;

                if(_currentPoint >= _points.Count)
                    _currentPoint = 0;
            }
        }
    }

    public void SetPoint(Point point)
    {
        _points = new List<Point> {point };
        _currentPoint = 0;
    }
}
