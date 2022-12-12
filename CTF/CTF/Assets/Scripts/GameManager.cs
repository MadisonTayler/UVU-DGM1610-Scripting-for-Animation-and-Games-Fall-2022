using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;

    // Start is called before the first frame update
    void Start()
    {
        // Flag bools
        hasFlag = false;
        flagPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(flagPlaced == true)
        {
            WinGame();
        }
    }

    public void PlaceFlag()
    {
        flagPlaced = true;
    }

    void WinGame()
    {
        Debug.Log("You've won!");
        Time.timeScale = 0; // Freeze the game
        // Show win screen
        // GameUI.instance.SetEndGameScreen(true, curScore);
    }
}
