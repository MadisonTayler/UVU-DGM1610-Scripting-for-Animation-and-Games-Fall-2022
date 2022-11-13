using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy has perished!");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + " Damage Taken");
    }
}
