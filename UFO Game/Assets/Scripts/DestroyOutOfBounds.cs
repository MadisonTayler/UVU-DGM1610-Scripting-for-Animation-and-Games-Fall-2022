using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBounds = 30.0f;
    public float lowerBounds = -10.0f;
    public GameManager gameManager; // Store reference to GameManager

    private ScoreManager scoreManager;
    private DetectCollision detectCollision;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Reference GameManager Script
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); // Reference scoremanager
        detectCollision = GetComponent<DetectCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBounds)
        {
            scoreManager.DecreaseScore(detectCollision.scoreToGive); // Deduct points if UFO passes lower bounds
            Destroy(gameObject);
            Debug.Log("Game Over!");
            gameManager.isGameOver = true;
        }
    }
}
