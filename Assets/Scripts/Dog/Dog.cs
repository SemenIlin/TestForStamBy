using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Dog : MonoBehaviour
{
    protected CapsuleCollider2D _capsule;
    protected SpriteRenderer _sprite;
    void Start()
    {
        _capsule = GetComponent<CapsuleCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
}
