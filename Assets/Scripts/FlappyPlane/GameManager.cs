using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UIManager uiManager;

    public GameObject gameOverCanvas;
    public GameObject gameOverText;

    public bool isGameStarted = false;

    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindFirstObjectByType<UIManager>();

    }

    private void Start()
    {
        isGameStarted = false;

        GameResultData.LoadBestScore();
        uiManager.UpdateScore(0);

        if (gameOverText != null)
            gameOverText.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        GameResultData.latestScore = currentScore;
        if (currentScore > GameResultData.bestScore)
            GameResultData.bestScore = currentScore;

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(true);

        if (gameOverText != null)
            gameOverText.SetActive(true);

        currentState = GameState.GameOver;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        GameResultData.latestScore = currentScore;

        if (currentScore > GameResultData.bestScore)
            GameResultData.bestScore = currentScore;

        uiManager.UpdateScore(currentScore);
    }

    public enum GameState
    {
        WaitingToStart,
        Playing,
        GameOver
    }

    public GameState currentState = GameState.WaitingToStart;
}
