using UnityEngine;
public interface IViewFarmer
{
    float SpeedMultiplicator { get; }
    void GetView(Vector2 direction);
    void GetView();
}
