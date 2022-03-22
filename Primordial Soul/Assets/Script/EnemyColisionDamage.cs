using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColisionDamage : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Enemy")
        {
            if(collision.name == "Player")
            {
                
                PlayerStats.playerStats.DealDamage(Damage);
            }
        }
    }
}
