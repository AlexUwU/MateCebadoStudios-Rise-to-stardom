using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMainBehavior : MonoBehaviour
{
    public int cantDoors;
    public GameBehaviour gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cantDoors);
        if (cantDoors == 1 && !gameManager.estPuertas && gameManager.roomEnemy == 0)
        {
            Destroy(this.gameObject);
            Debug.Log(cantDoors);
        }
    }
}
