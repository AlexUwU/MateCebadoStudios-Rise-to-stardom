using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloqueo : MonoBehaviour
{
    public float move;
    public float distance;
    public GameBehaviour gameManager;
    void Start()
    {
        move = 0.5f * Time.deltaTime;
        gameManager = FindObjectOfType<GameBehaviour>();
    }

    void Update()
    {
        if (distance<2.5)
        {
            MoveDoor();

        }
        if (distance>2.5)
        {
            DestroyBlocking();
        }
    }

    private void MoveDoor()
    {
        transform.Translate(move, 0, 0);
        distance += move;
        Debug.Log(distance);

        if (distance>2.5)
        {
            CreateEnemy();
        }
    }

    void DestroyBlocking()
    {
        if (gameManager.roomEnemy == 0)
        {
            Destroy(this.gameObject);
            gameManager.estPuertas = false;
        }
    }
    void CreateEnemy()
    {
        if (gameManager.estPuertas)
        {
            gameManager.roomEnemy++;
            Debug.Log("enemy" + gameManager.roomEnemy);
        }
    }


}
