using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public GameBehaviour gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.AddCoins(coinValue);
            Destroy(this.gameObject);
        }
    }
}
