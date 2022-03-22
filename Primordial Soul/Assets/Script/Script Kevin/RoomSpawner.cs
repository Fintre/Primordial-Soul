using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public GameObject VerticalDoor;
    public GameObject ThisCollider;
   
    

    public PlayerStats playerStats;
    public float x, y;
    private Vector3 SpawnEn;
    private Vector3 SpawnDoor;
    private int RandomEnemy;
    public GameObject[] spawner;
    public int MinEnemy;
    public int MaxEnemy;
    private int i = 0;
    public float RightDoorX;
    public float RightDoorY;
    public float LeftDoorX;
    public float LeftDoorY;
    public float RightDoorX2;
    public float RightDoorY2;
    public float LeftDoorX2;
    public float LeftDoorY2;
    public float VerticalDoorX;
    public float VerticalDoorY;
    public float VerticalDoorX2;
    public float VerticalDoorY2;
    public string SpawnerName;

    public void Update()
    {
        if (playerStats.EnemyAlive <= 0) { 
            DoorDestroy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            
            
                ActiveSpawn(SpawnerName);
                DoorSpawn(LeftDoorX,LeftDoorY,RightDoorX,RightDoorY,  VerticalDoorX, VerticalDoorY, VerticalDoorX2, VerticalDoorY2,RightDoorX2, RightDoorY2, LeftDoorX2, LeftDoorY2);
            ThisCollider.SetActive(false);
            
        }
    }

    public void ActiveSpawn(string SpawnerName)
    {int x = 0;
        
        spawner = GameObject.FindGameObjectsWithTag(SpawnerName);
        foreach (GameObject i in spawner)
        {
            Debug.Log(spawner[x].name);
            spawner[x].AddComponent<EnemySpawnner>();
            spawner[x].GetComponent<EnemySpawnner>().Enemies = Enemies;
            spawner[x].GetComponent<EnemySpawnner>().MinEnemy = MinEnemy;
            spawner[x].GetComponent<EnemySpawnner>().MaxEnemy = MaxEnemy;
            x += 1;
            Debug.Log(playerStats.EnemyAlive);
            playerStats.EnemyAlive = x;
        
        }
        
        
    }

    public void DoorSpawn(float LeftDoorX, float LeftDoorY, float RightDoorX, float RightDoorY, float VerticalDoorX, float VerticalDoorY,float VerticalDoorX2, float VerticalDoorY2, float RightDoorX2, float RightDoorY2, float LeftDoorX2, float LeftDoorY2)
    {
        
        SpawnDoor.x = RightDoorX;
        SpawnDoor.y = RightDoorY;
        Instantiate(RightDoor, SpawnDoor, Quaternion.identity);
        SpawnDoor.x = LeftDoorX;
        SpawnDoor.y = LeftDoorY;
        Instantiate(LeftDoor, SpawnDoor, Quaternion.identity);

        SpawnDoor.x = RightDoorX2;
        SpawnDoor.y = RightDoorY2;
        Instantiate(RightDoor, SpawnDoor, Quaternion.identity);
        SpawnDoor.x = LeftDoorX2;
        SpawnDoor.y = LeftDoorY2;
        Instantiate(LeftDoor, SpawnDoor, Quaternion.identity);

        SpawnDoor.x = VerticalDoorX;
        SpawnDoor.y = VerticalDoorY;
        Instantiate(VerticalDoor, SpawnDoor, Quaternion.identity);

        SpawnDoor.x = VerticalDoorX2;
        SpawnDoor.y = VerticalDoorY2;
        Instantiate(VerticalDoor, SpawnDoor, Quaternion.identity);

        
        
    }
    public void DoorDestroy()
    {
        if (playerStats.EnemyAlive <= 0)
        {
            
            
         
            Destroy(GameObject.FindGameObjectWithTag("Door"));
        }
    }
}

