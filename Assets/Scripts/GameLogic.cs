using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    bool _isGameOver;
    bool _isGameStart;
   
    public bool IsGameOver => _isGameOver;

    public bool IsStartGame => _isGameStart;

    public void GameOver()
    {
        _isGameOver = true;        
    }

    public void StartGame()
    {
        _isGameStart = true;
    }

    public void RestartGame()
    {
        _isGameStart = false;
        _isGameOver = false;
        SceneManager.LoadScene(0);
    }
}
