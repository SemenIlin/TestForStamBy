using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Button _startGameButton;
    [SerializeField] Text _playerScoreText;
    [SerializeField] RawImage _gameOver;
    [SerializeField] RetryButton _retryButton;
    [SerializeField] GameObject _gameScreen;

    [SerializeField] GameLogic _gameLogic;

    private void Start()
    {
        UpdateScoreText(0);
        HideGameOver();
    }
    public void StartGame()
    {
        _gameLogic.StartGame();
        _startGameButton.gameObject.SetActive(false);
    }  

    public void UpdateScoreText(int value)
    {
        _playerScoreText.text = value.ToString();
    }
    public void ShowGameOver()
    {
        _gameOver.gameObject.SetActive(true);
        _retryButton.GameOver();
    }

    public void HideGameScreen()
    {
        _gameScreen.SetActive(false);
    }

    void HideGameOver()
    {
        _gameOver.gameObject.SetActive(false);
    }
}
