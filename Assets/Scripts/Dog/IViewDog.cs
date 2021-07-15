using UnityEngine;

public interface IViewDog
{
    float SpeedMultiplicator { get; }
    void GetView();
    void GetView(Vector2 direction);
}
