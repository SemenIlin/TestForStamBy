using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public class Bomba : MonoBehaviour
{
    [SerializeField] TextMeshPro _timerText;
    [SerializeField] float _timer;
    [SerializeField] RadiusBoom _radiusBoom;
    
    Animator _animator;
    bool _isBoom;
    GameLogic _gameLogic;
    private void Start()
    {
        _gameLogic = FindObjectOfType<GameLogic>();

        _animator = GetComponent<Animator>();
        _timerText.text = _timer.ToString();
    }
    float _time;
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 1)
        {
            _timer -= _time;
            _timer = Mathf.Ceil(_timer);
            if (_timer <= 0 && !_isBoom)
            {
                Boom();
                _isBoom = true;
            }
            _timerText.text = _timer.ToString();
            _time = 0;
        }
    }

    void Boom()
    {
        _animator.SetTrigger("IsBoom");
        _timerText.enabled = false;
        _radiusBoom.ObjectsForDestory.ForEach(bomba =>Destroy(bomba));

        _radiusBoom.EnemyUnderBoom.ForEach(enemy => {
            enemy.GetComponent<IEnemy>().ChangeView(3);
        });

        _radiusBoom.Pig?.ToDie();
        _gameLogic.GameOver();
    }

    public void Disactive()
    {
        _animator.ResetTrigger("IsBoom");
        Destroy(transform.parent.gameObject);
    }
}
