public interface IStationState 
{
    void SwitchState<T>() where T : IViewPig;
}
