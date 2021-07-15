using System.Collections.Generic;
using UnityEngine;

public class RadiusBoom : MonoBehaviour
{
    List<GameObject> _objectForDestroy = new  List<GameObject>();
    List<GameObject> _enemyUnderBoom = new List<GameObject>();
    Pig _pig;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone") || collision.CompareTag("Kust"))
        {
            _objectForDestroy.Add(collision.gameObject);
        }

        if (collision.CompareTag("Dog")) 
        {
            _enemyUnderBoom.Add(collision.gameObject); 
        }
        if (collision.CompareTag("Farmer"))
        {
            _enemyUnderBoom.Add(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            _pig = collision.GetComponent<Pig>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            _enemyUnderBoom.Remove(collision.gameObject);
        }
        if (collision.CompareTag("Farmer"))
        {
            _enemyUnderBoom.Remove(collision.gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            _pig = null;
        }
    }

    public Pig Pig => _pig;
    public List<GameObject> EnemyUnderBoom => _enemyUnderBoom;
    public List<GameObject> ObjectsForDestory => _objectForDestroy;
}
