using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    bool _isGameOver;
    bool _isGameStart;
    bool _isVictory;

    public bool IsVictory => _isVictory;
    public bool IsGameOver => _isGameOver;

    public bool IsStartGame => _isGameStart;

    public void GameOver()
    {
        _isGameOver = true;        
    }
    
    public void GetVictory()
    {
        Debug.Log(KustManger.Kusts.Count);
        _isVictory = KustManger.Kusts.Count == 1;
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
