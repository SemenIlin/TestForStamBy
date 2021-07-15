using System.Collections.Generic;
using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    [SerializeField] float _timeForTransitionToSimple = 2f;
    [SerializeField] Farmer _farmer;
    [SerializeField] float _moveSpeed;

    List<Vector2> _pathToBomberMan = new List<Vector2>();
    PathFinder _pathFinder;
    bool isMoving;

    Vector2 _currentDirection;
    Vector2 _previousDirection;

    float _timer;

    void Start()
    {
        _pathFinder = GetComponent<PathFinder>();
        _pathToBomberMan = _pathFinder.GetPath(_pathFinder.Target.position);
        isMoving = true;
    }

    void Update()
    {
        if (_pathToBomberMan.Count == 0 && Vector2.Distance(transform.position, _pathFinder.Target.transform.position) > 0.5f)
        {
            _pathToBomberMan = _pathFinder.GetPath(_pathFinder.Target.position);
            isMoving = true;
        }
        if (_pathToBomberMan.Count == 0)
        {
            return;
        }


        if (isMoving)
        {
            var pointCount = _pathToBomberMan.Count;
            if (Vector2.Distance(transform.position, _pathToBomberMan[pointCount - 1]) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _pathToBomberMan[pointCount - 1], _moveSpeed * Time.deltaTime);
            }
            else
            {
                _farmer.GetCurrentView().GetView(GetDirection());
               
                isMoving = false;
            }
        }
        else
        {
            _pathToBomberMan = _pathFinder.GetPath(_pathFinder.Target.position);
            isMoving = true;
        }

        if (_farmer.FarmerView == FarmerView.Angry)
        {
            _timer += Time.deltaTime;
            if (_timer > _timeForTransitionToSimple)
            {
                _farmer.ChangeView(1);
                _timer = 0;
            }
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
