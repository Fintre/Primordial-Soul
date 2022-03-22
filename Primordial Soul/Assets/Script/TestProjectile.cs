using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{

    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "PLayer" && collision.tag != "Loot" && collision.tag != "Ally Projectile" && collision.tag != "Enemy Projectile" && collision.tag !="Spawner1")
        {

            if(collision.GetComponent<Enemy>() != null)
            {
                Debug.Log(collision.GetComponent<Enemy>());
                collision.GetComponent<Enemy>().DealDamage(15);
            }
            
            Destroy(gameObject);
        }
    }
    
}
