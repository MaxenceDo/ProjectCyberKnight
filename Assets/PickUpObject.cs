using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    AudioSource coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coin = GetComponent<AudioSource>();
            Inventory.instance.AddCoins(1);
            coin.Play();
            Destroy(gameObject);
        }
    }



}
