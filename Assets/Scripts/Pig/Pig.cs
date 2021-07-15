using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Pig : MonoBehaviour
{
    [SerializeField] SimplePig _simple;
    PigView _pigView;
    Animator _animator;
    int _score;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _pigView = PigView.Simple;
    }

    public void ToDie()
    {
        _animator.SetTrigger("IsDie");
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
