using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class ViewDog : MonoBehaviour
{    protected Vector2 _currentDirection => _movement.GetCurrentDirection == Vector2.zero ?
        _movement.GetPreviousDirection :
        _movement.GetCurrentDirection;

    protected CapsuleCollider2D _capsule;
    protected SpriteRenderer _sprite;

    DogMovement _movement;
    void Start()
    {
        _movement = GetComponent<DogMovement>();

        _capsule = GetComponent<CapsuleCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
}
