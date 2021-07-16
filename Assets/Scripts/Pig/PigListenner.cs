using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PigListenner : MonoBehaviour
{
    [SerializeField] Pig _pig;
    List<IEnemy> _enemies;
    UI _ui;
    GameLogic _gameLogic;
    private void Start()
    {
        _enemies = new List<IEnemy>();
        _ui = FindObjectOfType<UI>();
        _gameLogic = FindObjectOfType<GameLogic>();

        var tempEnemies = FindObjectsOfType<MonoBehaviour>().OfType<IEnemy>();
        foreach (IEnemy enemy in tempEnemies)
        {
            _enemies.Add(enemy);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kust"))
        {
            var kust = collision.gameObject;
            _pig.IncreaceScore(kust.GetComponent<Kust>().Reward);
            _ui.UpdateScoreText(_pig.Score);

            _enemies.ForEach(enemy => enemy.ChangeView(2));
            Destroy(kust);
            _gameLogic.GetVictory();

            if (!_gameLogic.IsGameOver && _gameLogic.IsVictory)
            {
                _pig.GameOver();
            }
        }

        if (collision.gameObject.CompareTag("Farmer") ||
            collision.gameObject.CompareTag("Dog"))
        {
            _pig.ToDie();
        }
    }
}
