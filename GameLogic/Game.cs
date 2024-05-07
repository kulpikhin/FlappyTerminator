using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Camera _camera;

    private Color _startColor;

    private void Start()
    {
        _startColor = _camera.backgroundColor;
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        _camera.backgroundColor = Color.red;
        Time.timeScale = 0;
        _startScreen.Open();
    }


    private void OnPlayButtonClick()
    {
        _camera.backgroundColor = _startColor;
        StartGame();
        _startScreen.Close();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _scoreCounter.Reset();
        _player.Reset();
    }
}
