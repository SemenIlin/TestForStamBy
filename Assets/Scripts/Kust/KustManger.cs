using System.Collections.Generic;
using UnityEngine;

public class KustManger : MonoBehaviour
{
    static List<Kust> _kusts;
    void Start()
    {
        InitKusts();
    }

    public static List<Kust> Kusts => _kusts;
    void RemoveKust(Kust kust)
    {
        kust.DestroyKustEvent -= RemoveKust;
        _kusts.Remove(kust);
    }

    void InitKusts()
    {
        _kusts = new List<Kust>();
        foreach (var kust in transform.GetComponentsInChildren<Kust>())
        {
            kust.DestroyKustEvent += RemoveKust;
            _kusts.Add(kust);
        }
    }
}
