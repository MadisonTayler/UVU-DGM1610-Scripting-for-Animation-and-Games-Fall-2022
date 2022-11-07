using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public int health = 100;
    
    public void TakeDamage (int damage)
    {
        health -= damage; // Subtract health when damage is taken
        if(health <= 0)
        {
            Death(); // Run death method when health is less than or equal to 0
        }
    }

    void Death()
    {
        Destroy(gameObject); // Destroys the enemy
    }
}
