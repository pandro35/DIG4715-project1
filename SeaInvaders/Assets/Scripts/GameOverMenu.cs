using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text HighScoreText;
    public Text ScoreText;

    public void Start()
    {
        ScoreText.text = "Your Score was: " + GameController.Score;
        HighScoreText.text = "High Score: " + GameController.HighScore;
    }
    public void mainMenu()
    {
        GameController.Score = 0;
        SceneManager.LoadScene(0);
        //Time.timeScale = 1.0f;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
