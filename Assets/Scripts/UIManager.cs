using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; 
    public GameObject gameOverPanel;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreUI;
        GameManager.Instance.OnGameOver += ShowGameOverUI;

        gameOverPanel.SetActive(false);
        scoreText.text = "0";

   
        if (highScoreText != null)
        {
            highScoreText.text = "BEST: " + GameManager.Instance.HighScore;
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= UpdateScoreUI;
            GameManager.Instance.OnGameOver -= ShowGameOverUI;
        }
    }

    private void UpdateScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }

    private void ShowGameOverUI()
    {
      
        if (highScoreText != null)
        {
            highScoreText.text = "BEST: " + GameManager.Instance.HighScore;
        }

        gameOverPanel.SetActive(true);
    }

    public void OnRestartButtonClicked()
    {
        GameManager.Instance.RestartLevel();
    }
}