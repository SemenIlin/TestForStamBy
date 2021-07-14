using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] SimplePig _simple;
    PigView _pigView;

    void Start()
    {
        _pigView = PigView.Simple;
    }

    public PigView PigView => _pigView;

    public IViewPig GetCurrentView()
    {
        switch (_pigView)
        {
            case PigView.Simple:
                return _simple;

            default:
                return _simple;
        }
    }
  

    public void SetNewPigView(PigView view)
    {
        _pigView = view;
    }

}
