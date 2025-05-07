using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultData : MonoBehaviour
{
    public static int latestScore = 0;
    public static int bestScore = 0;

    public static void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }
}
