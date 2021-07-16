using System;
using UnityEngine;

public class Kust : MonoBehaviour
{
    [SerializeField] int _reward;

    public event Action<Kust> DestroyKustEvent;
    public int Reward => _reward;

    private void OnDestroy()
    {
        DestroyKustEvent?.Invoke(this);
    }
}
