using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 offset;

   
    void Update()
    {
        
       transform.position = player.position + offset; 
    }
}
