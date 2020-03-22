using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float top, bottom;
}
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer colorChange;
    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    private AudioSource expAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        expAudio = GetComponent<AudioSource>();
        colorChange = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalMov = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(0.0f, verticalMov, 0.0f);
        rb2d.velocity = movement * speed;

        rb2d.position = new Vector3(8.5f, Mathf.Clamp(rb2d.position.y, boundary.bottom, boundary.top), 0.0f);

    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            expAudio.Play();
        }
    }

    public void PlayerHit()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        colorChange.color = Color.red;
        yield return new WaitForSecondsRealtime(0.1f);
        colorChange.color = Color.white;
        yield return new WaitForSecondsRealtime(0.1f);
        colorChange.color = Color.red;
        yield return new WaitForSecondsRealtime(0.1f);
        colorChange.color = Color.white;

    }
}
