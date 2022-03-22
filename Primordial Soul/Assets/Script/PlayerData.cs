using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public float MaxHealth;
    public int LesserSoul;
    public int GreaterSoul;
    public int PrimordialSoul;

    public string AddLifePriceText;
    public float AddLifePrice;


    public PlayerData(PlayerStats playerstats, ShopPNJscript shopPNJscript  )
    {
        MaxHealth = playerstats.MaxHealth;
        LesserSoul = playerstats.LesserSoul;
        GreaterSoul = playerstats.GreaterSoul;
        PrimordialSoul = playerstats.PrimordialSoul;

        AddLifePriceText = shopPNJscript.AddLifePriceText.text;
        AddLifePrice = shopPNJscript.AddLifePrice;


    }
}
