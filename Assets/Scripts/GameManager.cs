using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }
    public int HighScore { get; private set; }
    public bool IsGameOver { get; private set; }


    public bool isGameStarted = false;
    public GameObject mainMenuPanel;

    public Action<int> OnScoreChanged;
    public Action OnGameOver;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        HighScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void Start()
    {

        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }
    }


    public void StartGame()
    {
        isGameStarted = true;
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false); 
        }
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

        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt("BestScore", HighScore);
            PlayerPrefs.Save();
        }

        OnGameOver?.Invoke();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}