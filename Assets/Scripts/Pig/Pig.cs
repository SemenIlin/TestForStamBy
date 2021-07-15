using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] SimplePig _simple;
    PigView _pigView;
    int _score;

    void Start()
    {
        _pigView = PigView.Simple;
    }

    public PigView PigView => _pigView;

    public int Score => _score;

    public void IncreaceScore(int reward)
    {
        _score += reward;
    }

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
