using UnityEngine;
using TMPro;

public class Bomba : MonoBehaviour
{
    [SerializeField] TextMeshPro _timerText;
    [SerializeField] float _timer;
    [SerializeField] RadiusBoom _radiusBoom;

    private void Start()
    {
        _timerText.text = _timer.ToString();
    }
    float _time;
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 1)
        {
            _timer -= _time;
            if (_timer <= 0)
            {
                Boom();
            }
            _timerText.text = ((int)_timer).ToString();
            _time = 0;
        }

    }

    void Boom()
    {
        _radiusBoom.ObjectsForDestory.ForEach(bomba => bomba.SetActive(false));
        gameObject.SetActive(false);
    }
}
