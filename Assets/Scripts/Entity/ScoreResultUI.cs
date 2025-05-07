using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreResultUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;

    void Start()
    {
        scoreText.text = $"Score: {GameResultData.latestScore}";
        bestText.text = $"Best: {GameResultData.bestScore}";
    }
}
