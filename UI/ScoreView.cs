using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += ChangeScore;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= ChangeScore;
    }

    private void ChangeScore(int score)
    {
        _score.text = score.ToString();
    }
}
