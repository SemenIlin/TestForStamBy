using UnityEngine;

public class Farmer : MonoBehaviour
{

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
    public void SetNewFarmerView(FarmerView view)
    {
        _farmerView = view;
    }
}
