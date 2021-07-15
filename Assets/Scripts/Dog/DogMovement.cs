using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] Dog _dog;
    [SerializeField] float _moveSpeed;

    List<Vector2> _pathToBomberMan = new List<Vector2>();
    PathFinder _pathFinder;
    bool _isMoving;

    Vector2 _currentDirection;
    Vector2 _previousDirection;

    void Start()
    {
        _pathFinder = GetComponent<PathFinder>();
        _pathToBomberMan = _pathFinder.GetPath(_pathFinder.Target.position);
        _isMoving = true;
    }

    void Update()
    {
        if (_pathToBomberMan.Count == 0 && Vector2.Distance(transform.position, _pathFinder.Target.transform.position) > 0.5f)
        {
            _pathToBomberMan = _pathFinder.GetPath(_pathFinder.Target.position);
            _isMoving = true;
        }
        if (_pathToBomberMan.Count == 0)
        {
            return;
        }


        if (_isMoving)
        {
            var pointCount = _pathToBomberMan.Count;
            if (Vector2.Distance(transform.position, _pathToBomberMan[pointCount - 1]) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _pathToBomberMan[pointCount - 1], _moveSpeed * Time.deltaTime);
            }
            else
            {
                _dog.GetCurrentView().GetView(GetDirection());
                _isMoving = false;
            }
        }
        else
        {
            _pathToBomberMan = _pathFinder.GetPath(_pathFinder.Target.position);
            _isMoving = true;
        }
    }

    public Vector2 GetCurrentDirection => _currentDirection;
    public Vector2 GetPreviousDirection => _previousDirection;
    Vector2 GetDirection()
    {
        var pointCount = _pathToBomberMan.Count;
        if (pointCount < 2)
        {
            if (_currentDirection != Vector2.zero)
            {
                _previousDirection = _currentDirection;
            }
            return Vector2.zero;
        }
        _currentDirection = _pathToBomberMan[pointCount - 2] - _pathToBomberMan[pointCount - 1];
        return _currentDirection;
    }
}
