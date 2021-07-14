using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PigMovement : MonoBehaviour
{
    [SerializeField, Range(0.001f, 0.3f)] float _offsetForChangeDirection = 0.05f;
    
    [Header("Horizontal orientation")]
    [SerializeField] Sprite _rightMove;
    [SerializeField] Sprite _leftMove;
    [SerializeField] Vector2 _horizontalColliderSize;
    [SerializeField] Vector2 _horizontalColliderOffset;

    [SerializeField] Transform _horizontalPigRightPointForBombaCreate;
    [SerializeField] Transform _horizontalPigLeftPointForBombaCreate;

    [Header("Vertical orientation")]
    [SerializeField] Sprite _upMove;
    [SerializeField] Sprite _downMove;
    [SerializeField] Vector2 _verticalColliderSize;
    [SerializeField] Vector2 _verticalColliderOffset;

    [SerializeField] Transform _verticalPigUpPointForBombaCreate;
    [SerializeField] Transform _verticalPigDownPointForBombaCreate;

    [SerializeField] float _speed;

    Rigidbody2D _rb;
    CapsuleCollider2D _capsule;
    SpriteRenderer _sprite;

    Vector2 _direction;
    Vector2 _previousDirection;
    Vector2 _currentIndexDirection;
    Vector2 _previousIndexDirection;
    Vector3 _directional;

    Joystick _joystick;
    Transform _pointForBombaCreate;

    void Start()
    {
        _joystick = FindObjectOfType<Joystick>();

        _rb = GetComponent<Rigidbody2D>();
        _capsule = GetComponent<CapsuleCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        _pointForBombaCreate = _verticalPigDownPointForBombaCreate;
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

    public Transform PointForBombaCreate => _pointForBombaCreate;

    void ChangeDirection(Vector2 direction)
    {
        //if(Mathf.Pow(direction.x - direction.y, 2) < _offsetForChangeDirection)
        //{
        //    _directional = Vector2.zero;
        //    return;
        //}

        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            _previousIndexDirection.x = _currentIndexDirection.x;
            _previousDirection = _direction;

            _direction.x = direction.x;
            _currentIndexDirection.x = 0 <= _direction.x && 0 <= _previousDirection.x  ? 1 : -1;
            _direction.y = 0;

            if (_previousDirection.y != 0)
            {
                ChangeSprite(_direction);
                SetHorizontalOrientation();
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
                ChangeSprite(_direction);
                SetVerticalOrientation();
            }
        }

        if (_previousIndexDirection.x != _currentIndexDirection.x ||
            _previousIndexDirection.y != _currentIndexDirection.y)
        {
            ChangeSprite(_direction);
        }
    }

    void ChangeSprite(Vector2 direction)
    {
        if(direction.x < 0)
        {
            _sprite.sprite = _leftMove;
            _pointForBombaCreate = _horizontalPigLeftPointForBombaCreate;
        }
        else if(direction.x >= 0 && direction.y == 0)
        {
            _sprite.sprite = _rightMove;
            _pointForBombaCreate = _horizontalPigRightPointForBombaCreate;
        }

        else if(direction.y < 0)
        {
            _sprite.sprite = _downMove;
            _pointForBombaCreate = _verticalPigDownPointForBombaCreate;
        }
        else if(direction.y > 0)
        {
            _sprite.sprite = _upMove;
            _pointForBombaCreate = _verticalPigUpPointForBombaCreate;
        }
    }

    void SetVerticalOrientation()
    {
        _capsule.direction = CapsuleDirection2D.Vertical;
        _capsule.offset = _verticalColliderOffset;
        _capsule.size = _verticalColliderSize;
    }

    void SetHorizontalOrientation()
    {
        _capsule.direction = CapsuleDirection2D.Horizontal;
        _capsule.offset = _horizontalColliderOffset;
        _capsule.size = _horizontalColliderSize;
    }
}
