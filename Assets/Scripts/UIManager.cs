using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    private void Start()
    {
       
        GameManager.Instance.OnScoreChanged += UpdateScoreUI;
        GameManager.Instance.OnGameOver += ShowGameOverUI;

        gameOverPanel.SetActive(false);
        scoreText.text = "0";
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
        gameOverPanel.SetActive(true);
    }

    
    public void OnRestartButtonClicked()
    {
        GameManager.Instance.RestartLevel();
    }
}