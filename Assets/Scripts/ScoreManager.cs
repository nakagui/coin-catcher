using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }
    public event Action<int> OnScoreChanged;

    public void UpdateScore(int points)
    {
        Score += points;
        OnScoreChanged?.Invoke(Score);
    }
}
