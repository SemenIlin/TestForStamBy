using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    [SerializeField] Farmer _farmer;
    [SerializeField] float _moveSpeed;

    private List<Vector2> _pathToBomberMan = new List<Vector2>();
    private PathFinder _pathFinder;
    private bool isMoving;



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
                _farmer.GetCurrentView().GetView(GetDirection(pointCount));
                transform.position = Vector2.MoveTowards(transform.position, _pathToBomberMan[pointCount - 1], _moveSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
            }
        }
        else
        {
            _pathToBomberMan = _pathFinder.GetPath(_pathFinder.Target.position);
            isMoving = true;
        }
    }

    Vector2 GetDirection(int pointCount)
    {
        if (pointCount < 2)
        {
            return Vector2.zero;
        }
        var result = _pathToBomberMan[pointCount - 2] - _pathToBomberMan[pointCount - 1];
        return _pathToBomberMan[pointCount - 2] - _pathToBomberMan[pointCount - 1];
    }
}
