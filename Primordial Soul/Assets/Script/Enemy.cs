using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    public float MaxHealth;
    public float Health;
    public GameObject HealthBar;
    public GameObject LootDrop;
    public GameObject Player;
    public PlayerStats playerStats;
    public Slider HealthBarSlider;
    


  
    void Start()
    {
        Health = MaxHealth;
    }

    public void HealCharacter()
    {
        Health += Health;
        CheckOverHeal();
        HealthBarSlider.value = CalculateHealthPercentage();
        
    }


    
    private void CheckOverHeal()
    {
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

    }
    public void DealDamage(float damage)
    {
        HealthBar.SetActive(true);
       
        Health -= damage;
        checkDeath();
        HealthBarSlider.value = CalculateHealthPercentage();
    }

    private void checkDeath()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(LootDrop, transform.position, Quaternion.identity);
            playerStats.EnemyAlive -=1;
        }

    }

    private float CalculateHealthPercentage()
    {
        return (Health / MaxHealth);
    }

  
}


