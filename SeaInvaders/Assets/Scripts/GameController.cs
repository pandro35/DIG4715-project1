using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int Lives;
    public int Score;

    public Text ScoreText;
    public Text LivesText;

    public GameObject bonusShip;
    public float spawnRate;

    public GameObject Canvas;
    public AudioSource BGM;
    public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {

        Lives = 3;
        Score = 0;
        LivesText.text = "Lives: " + Lives;
        ScoreText.text = "Score: " + Score;
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
            Destroy(Canvas);
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

        if (Random.value > spawnRate)
        {
            Vector3 spawnPosition = new Vector3(-8.0f, -6.0f, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(bonusShip, spawnPosition, spawnRotation);
        }

        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Destroy(gameObject);
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
            Destroy(Canvas);
            Destroy(MainCamera);
            SceneManager.LoadScene(3);
            Destroy(gameObject);
        }
    }
    public void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
        ScoreText.text = "Score: " + Score;
    }

    
}
