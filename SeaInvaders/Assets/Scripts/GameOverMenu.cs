using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        //Time.timeScale = 1.0f;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
