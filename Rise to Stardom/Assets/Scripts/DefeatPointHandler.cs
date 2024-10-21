using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatPointHandler : MonoBehaviour
{
    private GameBehaviour gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameBehaviour>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if(enemy != null && enemy.enemyStateManager.currentStateName == "DefeatState")
            {
                Destroy(collision.gameObject);

                if (gameManager != null)
                {
                    gameManager.roomEnemy--;
                }
            }
        }
    }
}