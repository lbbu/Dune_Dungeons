using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManegerScript : MonoBehaviour
{
    public GameObject gameOverUI;
   // [SerializeField]
  //  public GameObject ScoreManager;
    public Text pointsText;
    
    private ScoreManager scoreManager;


    public void Setup(int score)
    {

        gameObject.SetActive(true);
        // Debug.Log the score for troubleshooting
        Debug.Log("Received Score: " + score); //just to check before adding.
            pointsText.text ="Total Score: "+score.ToString() + " Points";
        
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
    public void EnableGameOverMenue()
    {
        gameOverUI.SetActive(true);
        Setup(scoreManager != null ? scoreManager.GetTotalScore() : 0);
    }


    void Start()
    {
        gameOverUI.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//current Scene
        Debug.Log("Restart button");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);//should be the main menue index;
        Debug.Log("MainMenue button");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit button");

    }
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }     
}
