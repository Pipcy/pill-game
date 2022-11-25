using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    //check when collision is triggered (with anything, not just coin)
    /* to add item:
    1. Add new tag name: coin, apply to coin object
    */
    int coin_count = 0;
    [SerializeField] TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Coin"))
        {
            //when collided, check to see if the tag is coin
            Destroy(other.gameObject);
            coin_count++;
            // Debug.Log("Coins: " + coin_count);
            coinText.text = "Coins: " + coin_count;
        }


    }
}
