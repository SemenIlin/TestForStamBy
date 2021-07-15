using UnityEngine;

public class Dog : MonoBehaviour, IEnemy
{
    const int QUANTITY_STATES = 3;
    [SerializeField] SimpleDog _simple;
    [SerializeField] AngryDog _angry;
    [SerializeField] DirtyDog _dirty;

    DogView _dogView;
    
    void Start()
    {
        _dogView = DogView.Simple;
    }

    public DogView DogView => _dogView;

    public IViewDog GetCurrentView()
    {
        switch (_dogView)
        {
            case DogView.Simple:
                return _simple;

            case DogView.Angry:
                return _angry;

            case DogView.Dirty:
                return _dirty;

            default:
                return _simple;
        }
    }
    public void ChangeView()
    {
        _dogView += 1;
        _dogView = (DogView)Mathf.Clamp((int)_dogView, 1, QUANTITY_STATES);

        GetCurrentView().GetView();
    }
    public void SetNewDogView(DogView view)
    {
        _dogView = view;
    }
}
