using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{


    public float MinDamage;
    public float MaxDamage;

    public GameObject projectile;
    public float bulletSpeed;
    public PlayerMovements Pm;

    Vector2 ShootPoint;



    // Start is called before the first frame update
    void Start()
    {

    }
    public void Shoot()
    {

        if (GameObject.FindGameObjectWithTag("PLayer") != null)
        {
            ShootPoint = Vector2.zero;
                    if (Pm.FacingDir == PlayerMovements.Facing.UP)
                    {
                        ShootPoint.y = 1;
                    }
                    else if (Pm.FacingDir == PlayerMovements.Facing.DOWN)
                    {
                        ShootPoint.y = -1;
                    }
                    else if (Pm.FacingDir == PlayerMovements.Facing.RIGHT)
                    {
                        ShootPoint.x = 1;
                    }
                    else if (Pm.FacingDir == PlayerMovements.Facing.LEFT)
                    {
                        ShootPoint.x = -1;
                    }
                    Vector2 dir = ShootPoint;
                    dir.Normalize();
                    GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                    spell.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
                    spell.GetComponent<TestProjectile>().damage = Random.Range(MinDamage, MaxDamage);
    }
        }

        
}
  

       // if (joystick.Horizontal >= 0.1f)
       // {
       //     GameObject spell = Instantiate(Projectile, transform.position, Quaternion.identity);
       //     Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       //     Vector2 myPos = transform.position;
       //     Vector2 direction = (mousPos - myPos).normalized;
       //     spell.GetComponent<Rigidbody2D>().velocity = direction * ProjectileForce;
       // }



        // if (Input.GetMouseButtonDown(1))
        // {
        //     GameObject spell = Instantiate(Projectile, transform.position, Quaternion.identity);
        //     Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     Vector2 myPos = transform.position;
        //      Vector2 direction = (mousPos - myPos).normalized;
        //     spell.GetComponent<Rigidbody2D>().velocity = mousPos * ProjectileForce;
        // }
    //}

   

