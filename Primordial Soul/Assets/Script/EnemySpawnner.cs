using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject Target;
    public float x, y;
    private Vector3 SpawnPos;
    private int RandomEnemy;
    public int MinEnemy;
    public int MaxEnemy;
    private void Update()
    {
        SpawnEnemy();
    }

    public void  SpawnEnemy()
    {
        
        SpawnPos = transform.position;
        RandomEnemy = Random.Range(MinEnemy, MaxEnemy);
        GameObject mob = Instantiate(Enemies[RandomEnemy],SpawnPos,Quaternion.identity);
        mob.GetComponent<Enemy>().Player = GameObject.FindGameObjectWithTag("PLayer");
        mob.GetComponent<Enemy>().playerStats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStats>();
        Destroy(this);
       
    }


}
