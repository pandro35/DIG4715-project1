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

        else if(other.CompareTag("Player"))
        {
            gameControl.UpdateLives(damage);
            expAudio.Play();
            player.PlayerHit();
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
                expAudio.Play();
                Destroy(gameObject);
            }
        }

        else
        {
            gameControl.AddScore(scoreValue);
            expAudio.Play();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
