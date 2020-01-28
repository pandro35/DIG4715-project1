using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnContact : MonoBehaviour
{
    private GameController gameControl;
    private PlayerController player;
    public int scoreValue;
    private int damage;
    public GameObject explosion;
    private AudioSource expAudio;

    // Start is called before the first frame update
    void Start()
    {
        damage = -1;

        GameObject gcObject = GameObject.FindWithTag("GameController");
        gameControl = gcObject.GetComponent<GameController>();
        GameObject pObject = GameObject.FindWithTag("Player");
        player = pObject.GetComponent<PlayerController>();
        expAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("eShot"))
        {
            return;
        }

        /*if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            expAudio.Play();
        }*/

        else if(other.CompareTag("Player"))
        {
            gameControl.UpdateLives(damage);
            Destroy(gameObject);
        }

        else if (other.CompareTag("Defense"))
        {
            if (this.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        else
        {
            gameControl.AddScore(scoreValue);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
