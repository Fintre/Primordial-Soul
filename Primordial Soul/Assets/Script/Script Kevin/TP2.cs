using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP2 : MonoBehaviour
{
    public int iLeveltoLoad;
    public string sLeveltoLoad;
    public GameObject player;
    public bool useIntegerToLoadLevel = false;

    // Update is called once per frame

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLayer");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            player.transform.position = new Vector3(-11, -110, 0);
        }
    }

}
