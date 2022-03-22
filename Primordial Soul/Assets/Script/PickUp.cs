using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{   
    public enum pickupObject { LESSERSOUL,GREATERSOUL,PRIMORDIALSOUL};
    public pickupObject CurrentObject;
    public int Quantity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {

            PlayerStats.playerStats.AddCurrency(this);
            Destroy(gameObject);

        }
    }

}
