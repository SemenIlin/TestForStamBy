using UnityEngine;

public interface IViewPig 
{
    void GetView(Vector2 direction);
    Transform PointForBombaCreate { get; }
}
