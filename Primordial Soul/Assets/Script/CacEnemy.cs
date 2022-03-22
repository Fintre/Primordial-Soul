using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacEnemy : Enemy
{
    public float AttackRange;
    public float DashSpeed;
    public float Speed = 2;
    public float DetectionRange;
    public float DashCooldown;
    private Vector2 DashDir;
    private bool Dash = false;



    private void Update()
    {
        if (Dash == false)
        {
            FindTarget();
            StartCoroutine(DashCD());
        }
        else
        {
            AttackZone();
        }


    }

    private void FindTarget()
    {

        if (Vector3.Distance(transform.position, Player.transform.position) <= DetectionRange)
        {
            if (Player != null)
            {


                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
            }
        }
    }


    private void AttackZone()
    {

        if (Vector3.Distance(transform.position, Player.transform.position) <= AttackRange)
        {
            if (Player != null)
            {

                DashDir = Player.transform.position;
                //transform.Translate(DashDir * DashSpeed);

                transform.position = Vector3.MoveTowards(transform.position, DashDir, DashSpeed * Time.deltaTime);
                Dash = false;

            }
        }


    }

    IEnumerator DashCD()
    {
        yield return new WaitForSeconds(DashCooldown);
        Dash = true;

    }
}
