using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageNPC : MonoBehaviour
{
    private int health = 100;
    public void DamageTaken(int dmg)
    {
        health -= dmg;
        if(health <= 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
