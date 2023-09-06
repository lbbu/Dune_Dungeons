using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private int totalScore ;
    public Text pointsText;
    // Singleton instance for ScoreManager
    private static ScoreManager instance;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance == null)
                {
                    instance = new GameObject("ScoreManager").AddComponent<ScoreManager>();
                }
            }
            return instance;
        }
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public void IncrementScore()
    {
        totalScore++;
        Debug.Log("Total Score: " + totalScore);
    }
}
