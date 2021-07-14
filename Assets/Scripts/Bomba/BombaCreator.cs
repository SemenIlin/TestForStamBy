using UnityEngine;

public class BombaCreator : MonoBehaviour
{    
    [SerializeField] GameObject _bombaPrefab;

    PigMovement _pigMovement;
    private void Start()
    {
        _pigMovement = GetComponent<PigMovement>();
    }
    public void CreateBomba()
    {
        var bomba = Instantiate(_bombaPrefab);
        bomba.transform.position = _pigMovement.PointForBombaCreate.position;
    }
}
