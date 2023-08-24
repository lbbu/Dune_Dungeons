using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransfer : MonoBehaviour
{
    public int SceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Transfer is Trigger");

            Debug.Log("switching scene to"+ SceneIndex);
            SceneManager.LoadScene(SceneIndex,LoadSceneMode.Single);
        }
    }
}
