using UnityEngine;

public class BombaCreator : MonoBehaviour
{    
    [SerializeField] GameObject _bombaPrefab;

    IViewPig _pigView;
    private void Start()
    {
        _pigView = GetComponent<Pig>().GetCurrentView();
    }
    public void CreateBomba()
    {
        var bomba = Instantiate(_bombaPrefab);
        bomba.transform.position = _pigView.PointForBombaCreate.position;
    }
}
