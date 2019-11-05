using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
 
    public void RestartGame()
    {
        //if (Input.GetMouseButtonDown(0))
        Player.isPlayerAlive = true;
            SceneManager.LoadScene("scene");
    }
    public void QuitGame()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            Player.isPlayerAlive = true;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
