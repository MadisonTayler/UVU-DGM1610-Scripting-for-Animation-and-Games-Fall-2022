using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private ScoreManager scoreManager; // A variable to hold the reference to the scoremanager
    public int scoreToGive;
    public ParticleSystem explosionParticle;
    public GameObject explosion;
    public Vector3 explosionSize;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); // Reference scoremanager
        explosionSize = new Vector3(.25f, .25f, .25f);
        //explosionParticle.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        //explosionParticle.transform.position = gameObject.transform.position;
        //explosionParticle.Play();
        Instantiate(explosion, transform.position, transform.rotation);
        explosion.transform.localScale = explosionSize;
        scoreManager.IncreaseScore(scoreToGive); // Increase score
        Destroy(other.gameObject); // Destroy the other game object it hits
        Destroy(gameObject); // Destroy this game object
    }
}
