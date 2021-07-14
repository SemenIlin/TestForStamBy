using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class SimplePig : MonoBehaviour, IViewPig
{
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

    SpriteRenderer _sprite;
    CapsuleCollider2D _capsule;

    Vector2 _direction;
    Vector2 _previousDirection;
    Vector2 _currentIndexDirection;
    Vector2 _previousIndexDirection;
    Transform _pointForBombaCreate;

    void Start()
    {
        _capsule = GetComponent<CapsuleCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }    

    public void GetView(Vector2 direction)
    {
        if (direction.x < 0)
        {
            _sprite.sprite = _leftMove;
            _pointForBombaCreate = _horizontalPigLeftPointForBombaCreate;
            SetHorizontalOrientation();
        }
        else if (direction.x > 0 && direction.y == 0)
        {
            _sprite.sprite = _rightMove;
            _pointForBombaCreate = _horizontalPigRightPointForBombaCreate;
            SetHorizontalOrientation();
        }

        else if (direction.y < 0)
        {
            _sprite.sprite = _downMove;
            _pointForBombaCreate = _verticalPigDownPointForBombaCreate;
            SetVerticalOrientation();
        }
        else if (direction.y > 0)
        {
            _sprite.sprite = _upMove;
            _pointForBombaCreate = _verticalPigUpPointForBombaCreate;
            SetVerticalOrientation();
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
