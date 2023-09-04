using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManegerScript : MonoBehaviour
{
    public GameObject gameOverUI;

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
    }


    void Start()
    {
        gameOverUI.SetActive(false);

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
