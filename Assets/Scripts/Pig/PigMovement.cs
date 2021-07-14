using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PigMovement : MonoBehaviour
{       
    [SerializeField] float _speed;

    Vector2 _direction;
    Vector2 _previousDirection;
    Vector2 _currentIndexDirection;
    Vector2 _previousIndexDirection;

    Rigidbody2D _rb;
    Vector3 _directional;
    Joystick _joystick;

    Pig _pig;

    void Start()
    {
        _pig = GetComponent<Pig>();
        _joystick = FindObjectOfType<Joystick>();

        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // change orientation on start move
            _previousDirection = Vector2.one;
        }
        if (Input.GetMouseButton(0))
        {
            ChangeDirection(_joystick.Direction);

            _directional = new Vector3(_direction.x, _direction.y, 0);
            _rb.MovePosition(transform.position + _directional * (Time.deltaTime * _speed));
        }        
    }

    void ChangeDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            _previousIndexDirection.x = _currentIndexDirection.x;
            _previousDirection = _direction;

            _direction.x = direction.x;
            _currentIndexDirection.x = 0 <= _direction.x && 0 <= _previousDirection.x ? 1 : -1;
            _direction.y = 0;

            if (_previousDirection.y != 0)
            {
                _pig.GetCurrentView().GetView(_direction);
            }
        }
        else
        {
            _previousIndexDirection.y = _currentIndexDirection.y;
            _previousDirection = _direction;

            _direction.x = 0;
            _direction.y = direction.y;
            _currentIndexDirection.y = 0 <= _direction.y && 0 <= _previousDirection.y ? 1 : -1;
            if (_previousDirection.x != 0)
            {
                _pig.GetCurrentView().GetView(_direction);
            }
        }

        if (_previousIndexDirection.x != _currentIndexDirection.x ||
            _previousIndexDirection.y != _currentIndexDirection.y)
        {
            
            _pig.GetCurrentView().GetView(_direction);
        }
    }
}
