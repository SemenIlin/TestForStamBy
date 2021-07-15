using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RetryButton : MonoBehaviour
{
    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    public void GameOver()
    {
        _animator.SetTrigger("IsDie");
    }
}
