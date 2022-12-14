using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals : MonoBehaviour

{
    public int speed = 20;
    public int hitObstacleLimit = 5;
    public int gameOver;
    public int finishLine = 0;
    public TextMeshProUGUI gameTipsText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI youWonText;
    
    
    public void UpdateGameTipsText()
    {
        // Displays game tips depending on player's speed
        if(speed > 20)
        {
           gameTipsText.text = "TOO FAST!";
        }
        if(speed < 20)
        {
           gameTipsText.text = "Doing good!";
        }
        if(speed < 10)
        {
           gameTipsText.text = "TOO SLOW!";
        }
        
    }
    
    
    void Update()
    {
        // Lowers the number of times you can hit an obstacle before losing the game
        hitObstacleLimit = hitObstacleLimit - 1
    {
    
    
    public void UpdateGameOverText()
    {
        // Causes game over text when max number of obstacles has been hit
        if(hitObstacleLimit == 0)
        {
            gameOverText.text = "GAME OVER";
        }
        
        
    public void UpdateYouWonText()
    {
        // Displays the "You Won" text once player has passed the finish line
        if(finishLine = 1)
        {
            youWonText.text = "YOU WON!";
        }
    }
}