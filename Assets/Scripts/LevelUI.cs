using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelUI : MonoBehaviour
{
    public GameObject gameOverUI;
    // [SerializeField]
    //  public GameObject ScoreManager;
    // public TextMeshProUGUI pointsText;
    public Text pointsText;

    private ScoreManager scoreManager;


    public void UpdateScore(int score)
    {

        
        // Debug.Log the score for troubleshooting
        Debug.Log("Received Score: " + score); //just to check before adding.
            pointsText.text =$"Total Score:{score} Points";
        
        Debug.Log("Your Score is:"+score);
    }
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += EnableGameOverMenue;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenue;
    }
    private void EnableGameOverMenue()
    {
        gameOverUI.SetActive(true);
      UpdateScore(scoreManager !=null ? scoreManager.GetTotalScore():0); //IT SHOULD NOT BE LIKE THAT!!
        // UpdateScore(scoreManager.GetTotalScore()); //Perfict.
        Time.timeScale = 0;
    }


    void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        gameOverUI.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//current Scene
        Debug.Log("Restart button");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);//should be the main menue index;
        Debug.Log("MainMenu button");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit button");

    }
        
}
