using UnityEngine;

public class Farmer : MonoBehaviour, IEnemy
{
    const int QUANTITY_STATES = 3;

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
        switch (_farmerView)
        {
            case FarmerView.Simple:
                return _simple;

            case FarmerView.Angry:
                return _angry;

            case FarmerView.Dirty:
                return _dirty;

            default:
                return _simple;
        }
    }

    public void ChangeView()
    {
        _farmerView += 1;
        _farmerView = (FarmerView)Mathf.Clamp((int)_farmerView, 1, QUANTITY_STATES);
        GetCurrentView().GetView();
    }
}
