using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(0);// we can just add the index of our game scene directly. SceneManager.GetActiveScene().buildIndex +
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit button");

    }
}
