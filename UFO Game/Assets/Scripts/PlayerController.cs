using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hInput;
    public float speed;
    private float xRange = 17.0f;
    public GameObject lazerBolt; // GameOBject projectile to shoot
    public Transform blaster; // Point of origin for the lazerBolt
    public GameManager gameManager;
    private AudioSource blasterAudio;
    public AudioClip laserBlast;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Reference GameManager script
        blasterAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       // Set horizontal input to receive values from the keyboard keymap horizontal -1 to 1
       hInput = Input.GetAxis("Horizontal");

       // Move the player left and right
       transform.Translate(Vector3.right * hInput * speed * Time.deltaTime);

       // Keep player within set bounds
       // Keep player inside right wall at set xRange
       if(transform.position.x > xRange)
       {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
       }
       // Keep player inside left wall at set -xRange
       if(transform.position.x < -xRange)
       {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
       }

       if(Input.GetKeyDown(KeyCode.Space) && gameManager.isGameOver == false) // Second condition gameManager prevents player from shooting after game is over
       {
          blasterAudio.PlayOneShot(laserBlast,1.0f);
          Instantiate(lazerBolt, blaster.transform.position, lazerBolt.transform.rotation); // Instantiate laserBolt GameObject at blaster position
       }
    }
}
