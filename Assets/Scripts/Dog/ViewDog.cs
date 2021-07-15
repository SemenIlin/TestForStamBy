using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class ViewDog : MonoBehaviour
{
    protected CapsuleCollider2D _capsule;
    protected SpriteRenderer _sprite;
    void Start()
    {
        _capsule = GetComponent<CapsuleCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
}
