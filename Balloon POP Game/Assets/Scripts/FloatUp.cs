using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{

    public float moveSpeed; // Speed at which the balloon floats upward
    public float upperBound; // Top boundary that destroys balloon when it exits the screen

    private Balloon balloon; // References the balloon gameobject

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
      balloon = GetComponent<Balloon>();  
      scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the balloon upwards
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Destroy balloon if it passes the top boundary/threshold
        if(transform.position.y > upperBound)
        {
            scoreManager.DecreaseScoreText(balloon.scoreToGive);
            Destroy(gameObject);
        }
    }
}
