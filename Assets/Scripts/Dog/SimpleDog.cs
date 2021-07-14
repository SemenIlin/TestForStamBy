using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class SimpleDog : MonoBehaviour, IViewDog
{
    [Header("Horizontal orientation")]
    [SerializeField] Sprite _rightMove;
    [SerializeField] Sprite _leftMove;
    [SerializeField] Vector2 _horizontalColliderSize;
    [SerializeField] Vector2 _horizontalColliderOffset;

    [Header("Vertical orientation")]
    [SerializeField] Sprite _upMove;
    [SerializeField] Sprite _downMove;
    [SerializeField] Vector2 _verticalColliderSize;
    [SerializeField] Vector2 _verticalColliderOffset;

    CapsuleCollider2D _capsule;
    SpriteRenderer _sprite;

    void Start()
    {
        _capsule = GetComponent<CapsuleCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    public void GetView(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            SetHorizontalOrientation();
            SetVerticalOrientation();
            ChangeSprite(direction);
        }
    }
    void ChangeSprite(Vector2 direction)
    {
        if (direction.x < 0)
        {
            _sprite.sprite = _leftMove;
        }
        else if (direction.x > 0 && direction.y == 0)
        {
            _sprite.sprite = _rightMove;
        }

        else if (direction.y < 0)
        {
            _sprite.sprite = _downMove;
        }
        else if (direction.y > 0)
        {
            _sprite.sprite = _upMove;
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
