using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    public int clickToPop = 3; // How many clicks until the balloon pops
    public float scaleToInflate = 0.10f; // Inflate ballon 10% with each click
    public int scoreToGive = 100;
    private ScoreManager scoreManager;



    // Start is called before the first frame update
    void Start()
    {
        // Reference ScoreManager Component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }


    void OnMouseDown()
    {
        clickToPop = clickToPop - 1; //Reduce clicks by one

        //Inflate the balloon a certain amount every time it's clicked on
        transform.localScale += Vector3.one * scaleToInflate;

        //Check to see if clickToPop has reached zero. If it has, balloon pops
        if(clickToPop == 0)
        {
            // Send points to score manager and update the score
            scoreManager.IncreaseScoreText(scoreToGive);
            // Destroy this balloon
            Destroy(gameObject);
        }

    }
}
