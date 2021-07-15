using UnityEngine;

public class Farmer : MonoBehaviour, IEnemy
{
    const int QUANTITY_VIEWS = 3;

    [SerializeField] SimpleFarmer _simple;
    [SerializeField] AngryFarmer _angry;
    [SerializeField] DirtyFarmer _dirty;

    FarmerView _farmerView;
    void Start()
    {
        _farmerView = FarmerView.Simple;
    }

    public FarmerView FarmerView => _farmerView;

    public IViewFarmer GetCurrentView()
    {
        return _farmerView switch
        {
            FarmerView.Simple => _simple,
            FarmerView.Angry => _angry,
            FarmerView.Dirty => _dirty,
            _ => _simple,
        };
    }

    public void ChangeView(int view)
    {
        var result = Mathf.Clamp(view, 1, QUANTITY_VIEWS);
        _farmerView = (FarmerView)result;

        GetCurrentView().GetView();
    }

}
