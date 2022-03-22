using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnemy : Enemy
{
    public float ProjectileForce;
    public GameObject Projectile;
    public float Damage;
    public float ShootCoolDown;
    public bool CanShoot;
    public float DetectionRange;
    public float ShootRange;
    public float Speed;
    private enum State { Chase , Shoot}
    private State state;


    private void Awake()
    {
        Health = MaxHealth;
        CanShoot = true;
        state = State.Chase;
    }

    

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Chase:
                FindTarget();
                
                break;
            case State.Shoot:
                
                if (Vector3.Distance(transform.position, Player.transform.position) >= ShootRange)
                        {
                             state = State.Chase;
                        }
                if (CanShoot == true)
                {
                    Shoot();
                    StartCoroutine(ShootCD()); 
                    
                }
                break;
        }
        
    }
    void Shoot()
    {

        
        GameObject EnemySpell = Instantiate(Projectile, transform.position, Quaternion.identity);
        Vector2 PlayerPos = Player.transform.position;
        Vector2 myPos = transform.position;
        Vector2 direction = (PlayerPos - myPos).normalized;
        EnemySpell.GetComponent<Rigidbody2D>().velocity = direction * ProjectileForce;
        EnemySpell.GetComponent<EnemyProjectile>().damage = Damage;
        CanShoot = false;
       



    }

    IEnumerator ShootCD()
    {
        
        yield return new WaitForSeconds(ShootCoolDown);
        CanShoot = true;
        
    }

    private void FindTarget()
    {

        if (Vector3.Distance(transform.position, Player.transform.position) <= DetectionRange)
        {
            if (Player != null)
            {


                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
                if(Vector3.Distance(transform.position, Player.transform.position) <= ShootRange)
                {
                    state = State.Shoot;
                }
            }
        }
    }

    

}
