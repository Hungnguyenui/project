using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
 
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }


    public Action<int> OnScoreChanged;
    public Action OnGameOver;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        if (IsGameOver) return;
        Score += points;
        OnScoreChanged?.Invoke(Score); 
    }

    public void EndGame()
    {
        IsGameOver = true;
        OnGameOver?.Invoke(); 
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}