using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        _scoreManager.OnScoreChanged += UpdateScoreText;
        UpdateScoreText(_scoreManager.Score);
    }

    private void OnDisable()
    {
        _scoreManager.OnScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
    }
}
