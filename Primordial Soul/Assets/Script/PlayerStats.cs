using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerStats;

   
    public float MaxHealth;
    public float Health;
    public float Heal;
    public int LesserSoul;
    public int GreaterSoul;
    public int PrimordialSoul;
     
    public GameObject player;
    public ShopPNJscript shopPNJscript;
    public Text HealthText;
    public Slider HealthSlider;
    public Text LesserSoulText;
    public Text GreaterSoulText;
    public Text PrimordialSoulText;
    public int EnemyAlive;
    public GameObject DeathScreen;
    public GameObject[] MapSpawner;
    public GameObject[] MonsterSupp;
    public GameObject[] Doors;

    private void Awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }else
        {
            playerStats = this; 
        }
        playerStats = this;
        DontDestroyOnLoad(this);
        EnemyAlive = 0;
    }

    
    void Start()
    {
        LoadPlayer();
        player = GameObject.FindGameObjectWithTag("PLayer");
        Health = MaxHealth;
        SetHealUi();
    }

    public void SavePlayer()
    {
        SaveSysteme.SavePlayerStats(this , shopPNJscript);

    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSysteme.LoadPlayer();

        MaxHealth = data.MaxHealth;
        LesserSoul = data.LesserSoul;
        GreaterSoul = data.GreaterSoul;
        PrimordialSoul = data.PrimordialSoul;

        shopPNJscript.AddLifePriceText.text = data.AddLifePriceText;
        shopPNJscript.AddLifePrice = data.AddLifePrice;
        shopPNJscript.Actualise(shopPNJscript.AddLifePriceText, shopPNJscript.AddLifePrice.ToString());
        DisplayCurrency();
        Health = MaxHealth;
        SetHealUi();
    }
    public void DealDamage(float damage)
    {
        Health -= damage;
        checkDeath();
        SetHealUi();
    }

    public void HealCharacter()
    {
        Health += Heal;
        CheckOverHeal();
        SetHealUi();
    }

    public void SetHealUi()
    {
        HealthSlider.value = CalculateHealthPercentage();
        HealthText.text = Mathf.Ceil(Health).ToString() + "/" + Mathf.Ceil(MaxHealth).ToString();
    }

    private void CheckOverHeal()
    {
         if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    private void checkDeath()
    {
        if (Health <= 0)
        {
            Health = 0;
            player.SetActive(false);
            DeathScreen.SetActive(true);
        }
    }

    public void AddCurrency(PickUp currency)
    {
        if(currency.CurrentObject == PickUp.pickupObject.LESSERSOUL)
        {
            LesserSoul += currency.Quantity;
            LesserSoulText.text = LesserSoul.ToString();

        }else if (currency.CurrentObject == PickUp.pickupObject.GREATERSOUL)
        {
            GreaterSoul += currency.Quantity;
            GreaterSoulText.text = GreaterSoul.ToString();
        }
        else if (currency.CurrentObject == PickUp.pickupObject.PRIMORDIALSOUL)
        {
            PrimordialSoul += currency.Quantity;
            PrimordialSoulText.text = PrimordialSoul.ToString();
        }
        
    }
    public void DisplayCurrency()
    {
        LesserSoulText.text = LesserSoul.ToString();
        GreaterSoulText.text = GreaterSoul.ToString();
        PrimordialSoulText.text = PrimordialSoul.ToString();
    }

    float CalculateHealthPercentage()
    {
        return Health / MaxHealth;
    }

    public void Respawn()
    {
        player.SetActive(true);
        player.transform.position = new Vector3(133.04f, -106, 0);
        DeathScreen.SetActive(false);
        Health = MaxHealth;
        SavePlayer();
        SetHealUi();
        DisplayCurrency();



        foreach (GameObject i in MapSpawner)
        {
            i.SetActive(true);
        }

        MonsterSupp = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject z in MonsterSupp)
        {
            Destroy(z);
        }

        Doors = GameObject.FindGameObjectsWithTag("Door");

        foreach (GameObject k in Doors)
        {
            Destroy(k);
        }
    }
  
}
  
