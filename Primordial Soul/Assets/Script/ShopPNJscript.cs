using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopPNJscript : MonoBehaviour
{
    

    public GameObject Player;
    public PlayerStats playerstats;
    public GameObject IntercactButton;
    public GameObject ShopOverlay;
    public Text AddLifePriceText;

    public float AddLifePrice;
    public int AddLifeAmount;

    public float ShopInRange;

    
    public void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("PLayer");
        ShopOverlay.SetActive(false);

    }

    public void Update()
    {
        ShopRange();
        Actualise(AddLifePriceText, AddLifePrice.ToString());
    }
    public void ShopRange()
    {

        if (Vector3.Distance(transform.position, Player.transform.position) <= ShopInRange)
        {
            if (Player != null)
            {

                IntercactButton.SetActive(true);

            }
        }
        else
        {
            IntercactButton.SetActive(false);
        }
    }

    public void OpenShop()
    {
        ShopOverlay.SetActive(true);
    }

    public void CloseShop()
    {
        ShopOverlay.SetActive(false);
    }

    public void PurchaseLife()
    {
        if (playerstats.LesserSoul >= AddLifePrice)
        {
            playerstats.MaxHealth += AddLifeAmount;
            playerstats.LesserSoul -= Mathf.CeilToInt(AddLifePrice);
            AddLifePrice = Mathf.Ceil(AddLifePrice * 1.5f);
            Actualise(AddLifePriceText, AddLifePrice.ToString());

            playerstats.Health = playerstats.MaxHealth;
            playerstats.SetHealUi();
            playerstats.DisplayCurrency();
        }
        else
        {
            Debug.Log("Pas assez de Lesser Soul");
        }
    }

    public void Actualise(Text text, string value)
    {
        text.text = value;
    }
}
