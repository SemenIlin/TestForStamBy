using System.Collections.Generic;
using UnityEngine;

public class RadiusBoom : MonoBehaviour
{
    List<GameObject> _objectForDestroy = new  List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone") || collision.CompareTag("Kust"))
        {
            _objectForDestroy.Add(collision.gameObject);
        }
    }

    public List<GameObject> ObjectsForDestory => _objectForDestroy;
}
