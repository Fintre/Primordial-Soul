using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    
   public float ProjectileForce;
    public GameObject Projectile;
    public float Damage;
    public float ShootCoolDown;
    public bool CanShoot;
    public float DetectionRange;
    public float ShootRange;
    public float Speed;
    public float ShootSpace;
    public float DamagePowerShoot;
    private int Shooted;
    private int ShootNeeded;
    private enum State { Chase, Shoot }
    private State state;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("PLayer");
        Health = MaxHealth;
        CanShoot = true;
        ShootNeeded = Random.Range(2, 7);
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
              
                if (CanShoot == true )
                {
                    Shoot();
                    CanShoot = false;
                    StartCoroutine(ShootCD());
                }
                
                break;
        }

    }
    void Shoot()
    {
        if (Shooted == ShootNeeded)
        {
            GameObject EnemySpell = Instantiate(Projectile, transform.position, Quaternion.identity);
            EnemySpell.transform.localScale = new Vector3(EnemySpell.transform.localScale.x * 2, EnemySpell.transform.localScale.y * 2, 0);
            Vector2 PlayerPos = Player.transform.position;
            Vector2 myPos = transform.position;
            Vector2 direction = (PlayerPos - myPos).normalized;
            EnemySpell.GetComponent<Rigidbody2D>().velocity = direction * ProjectileForce;
            EnemySpell.GetComponent<EnemyProjectile>().damage = DamagePowerShoot;
            Shooted = 0;
            ShootNeeded = Random.Range(2, 7);
        }

        else if (CanShoot == true)
        {
            GameObject EnemySpell = Instantiate(Projectile, transform.position, Quaternion.identity);
        
            Vector2 PlayerPos = Player.transform.position;
            Vector2 myPos = transform.position;
            Vector2 direction = (PlayerPos - myPos).normalized;
            EnemySpell.GetComponent<Rigidbody2D>().velocity = direction * ProjectileForce;
            EnemySpell.GetComponent<EnemyProjectile>().damage = Damage;
            Shooted += 1;
        }
        
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
                if (Vector3.Distance(transform.position, Player.transform.position) <= ShootRange)
                {
                    state = State.Shoot;
                }
            }
        }
    }


}
