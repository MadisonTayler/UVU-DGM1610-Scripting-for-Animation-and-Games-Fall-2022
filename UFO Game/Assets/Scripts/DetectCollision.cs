using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private ScoreManager scoreManager; // A variable to hold the reference to the scoremanager
    public int scoreToGive;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); // Reference scoremanager
    }

    void OnTriggerEnter(Collider other)
    {
        scoreManager.IncreaseScore(scoreToGive); // Increase score
        Destroy(other.gameObject); // Destroy the other game object it hits
        Destroy(gameObject); // Destroy this game object
    }
}
