using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScoreText(int amount)
    {
        score = score + amount; // Also correct is "score += amount;" Increase score by a certain amount

        UpdateScoreText();

    }

public void DecreaseScoreText(int amount)
    {
        score -= amount; // Decrease score by a certain amount

        UpdateScoreText();

    }


    public void UpdateScoreText()
    {
        scoreText.text = "Score: "+ score;
    }
}
