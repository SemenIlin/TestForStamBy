using UnityEngine;

public class Dog : MonoBehaviour, IEnemy
{
    const int QUANTITY_VIEWS = 3;
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
        return _dogView switch
        {
            DogView.Simple => _simple,
            DogView.Angry => _angry,
            DogView.Dirty => _dirty,
            _ => _simple,
        };
    }
    public void ChangeView(int view)
    {
        var result = Mathf.Clamp(view, 1, QUANTITY_VIEWS);
        _dogView = (DogView)result;

        GetCurrentView().GetView();
    }
    public void SetNewDogView(DogView view)
    {
        _dogView = view;
    }

}
