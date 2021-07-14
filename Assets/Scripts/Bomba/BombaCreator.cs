using UnityEngine;

public class BombaCreator : MonoBehaviour
{    
    [SerializeField] Bomba _bombaPrefab;

    PigMovement _pigMovement;
    private void Start()
    {
        _pigMovement = GetComponent<PigMovement>();
    }
    public void CreateBomba()
    {
        var bomba = Instantiate(_bombaPrefab.gameObject);
        bomba.transform.position = _pigMovement.PointForBombaCreate.position;
    }
}
