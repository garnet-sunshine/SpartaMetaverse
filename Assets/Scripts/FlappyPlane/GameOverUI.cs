using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;
    public Button mainMenuButton;

    void Start()
    {
        scoreText.text = $"Score: {GameResultData.latestScore}";
        bestText.text = $"Best: {GameResultData.bestScore}";

        mainMenuButton.onClick.AddListener(OnClickMainMenu);
    }

    
    void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
