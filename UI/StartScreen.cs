using UnityEngine;
using UnityEngine.UI;
using System;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _startButton;

    public event Action PlayButtonClicked;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Close()
    {
        _windowGroup.alpha = 0f;
        _startButton.interactable = false;
    }

    public void Open()
    {
        _windowGroup.alpha = 1f;
        _startButton.interactable = true;
    }

    private void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
