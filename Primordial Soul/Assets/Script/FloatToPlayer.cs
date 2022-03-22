using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatToPlayer : MonoBehaviour
{
    private GameObject Player;
    public float speed;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        
    }
}
