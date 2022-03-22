using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy" && collision.tag != "Enemy Projectile" && collision.tag != "Ally Projectile" && collision.tag != "Spawner1")
            {
            
            if (collision.name == "Player")
            {
                PlayerStats.playerStats.DealDamage(damage);
            }
            
             
                

                
             Debug.Log(collision.tag);
                        Destroy(gameObject);
            }

           
    }
}

