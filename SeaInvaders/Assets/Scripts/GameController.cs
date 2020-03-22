using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int Lives = 3;
    public static int Score = 0;
    public static int HighScore = 0;

    public Text ScoreText;
    public Text LivesText;
    public Text HighScoreText;

    public GameObject bonusShip;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        LivesText.text = "Lives: " + Lives;
        ScoreText.text = "Score: " + Score;
        HighScoreText.text = "High Score: " + HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }

        if (Random.value > spawnRate)
        {
            Vector3 spawnPosition = new Vector3(-8.0f, -6.0f, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(bonusShip, spawnPosition, spawnRotation);
        }

    }

    public void UpdateLives(int newLivesValue)
    {
        if (Lives > 1)
        {
            Lives += newLivesValue;
            LivesText.text = "Lives: " + Lives;
        }
        else
        {
            if(HighScore < Score)
            {
                HighScore = Score;
            }
            Lives = 3;
            SceneManager.LoadScene(3);
        }
    }
    public void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
        ScoreText.text = "Score: " + Score;
    }

    
}
