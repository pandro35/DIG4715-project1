using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    private int ChildCountTracker;
    private float i, j;

    public GameObject shot;
    public float fireRate;

    public GameObject canvas;
    public GameObject gameController;
    public GameObject MainCamera;

    private AudioSource expAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        i = 0.01f;
        j = 0.6f;
        InvokeRepeating("MoveEnemy", i, j);
        enemyHolder = GetComponent<Transform>();
        ChildCountTracker = enemyHolder.transform.childCount;
        expAudio = GetComponent<AudioSource>();
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.down * speed;

        foreach (Transform enemy in enemyHolder)
        {
            if(enemy.position.y < -6.2 || enemy.position.y > 5.0)
            {
                speed = -speed;
                enemyHolder.position += Vector3.right * 0.2f;
                return;
            }
            if(Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation );
                expAudio.Play();
            }
            if(enemy.position.x >= 8)
            {
                SceneManager.LoadScene(3);
            }
        }

        UpdateMovSpeed();

        if(enemyHolder.childCount == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                Destroy(canvas);
                Destroy(MainCamera);
                Destroy(gameController);
                SceneManager.LoadScene(4);
            }
        }
    }

    void UpdateMovSpeed()
    {
        if(ChildCountTracker != enemyHolder.transform.childCount)
        {
            ChildCountTracker = enemyHolder.transform.childCount;
            j = j - 0.01f;
            CancelInvoke();
            InvokeRepeating("MoveEnemy", i, j);

        }
    }

    /*IEnumerator LoadYourAsyncScene()
    {

        Destroy(Defense);
        Time.timeScale = 0.0f;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);
        Debug.Log("Scene created");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MergeScenes(SceneManager.GetSceneByBuildIndex(1), SceneManager.GetSceneByBuildIndex(2));
        Debug.Log("Another Scene");
        Time.timeScale = 1.0f;
        Destroy(gameObject);

    }*/
}
