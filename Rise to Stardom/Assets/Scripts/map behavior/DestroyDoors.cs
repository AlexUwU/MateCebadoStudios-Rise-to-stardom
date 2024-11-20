using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoors : MonoBehaviour
{
    public GameObject[] spawnDoors;
    public RoomMainBehavior rooms;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (spawnDoors != null)
            {
                foreach (GameObject objeto in spawnDoors)
                {
                    if (objeto != null)
                    {
                        Destroy(objeto);
                        //rooms.cantDoors--;
                    }
                }
                rooms.door = true;
                spawnDoors = null;
            }
        }
    }
}
