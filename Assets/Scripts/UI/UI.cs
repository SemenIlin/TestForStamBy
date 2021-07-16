using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Button _startGameButton;
    [SerializeField] Text _playerScoreText;
    [Header("Result Sprite")]
    [SerializeField] RawImage _gameOver;
    [SerializeField] Texture _win;
    [SerializeField] Texture _lose;
    [Header("")]

    [SerializeField] RetryButton _retryButton;
    [SerializeField] GameObject _gameScreen;

    [SerializeField] GameLogic _gameLogic;

    Pig _pig;

    private void Start()
    {
        _pig = FindObjectOfType<Pig>();
        _pig.ShowGameOwerEvevent += HideGameScreen;
        _pig.ShowGameOwerEvevent += ShowGameOver;

        UpdateScoreText(0);
        HideGameOver();
        HideGameScreen();

        _retryButton.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        _gameLogic.StartGame();
        _startGameButton.gameObject.SetActive(false);
        ShowGameScreen();
    }  

    public void UpdateScoreText(int value)
    {
        _playerScoreText.text = value.ToString();
    }
    public void ShowGameOver()
    {
        _gameOver.texture = _gameLogic.IsVictory ? _win : _lose;

        _gameOver.gameObject.SetActive(true);
        _retryButton.GameOver();
    }

    public void HideGameScreen()
    {
        _gameScreen.SetActive(false);
        _retryButton.gameObject.SetActive(true);
    }

    void ShowGameScreen()
    {
        _gameScreen.SetActive(true);
        _retryButton.gameObject.SetActive(false);
    }
    void HideGameOver()
    {
        _gameOver.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _pig.ShowGameOwerEvevent -= ShowGameOver;
        _pig.ShowGameOwerEvevent -= HideGameScreen;
    }
}
