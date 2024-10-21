using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject[] puertaBloqueo;
    public GameBehaviour gameManager;
    public EnemySpawner enemySpawner;
    public DefeatPoints defeatPoints;
    void Start()
    {
        gameManager = FindObjectOfType<GameBehaviour>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        defeatPoints = FindObjectOfType<DefeatPoints>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.estPuertas = true;
            //Destroy(this.gameObject);
            for (int i = 0; i < puertaBloqueo.Length; i++)
            {
                puertaBloqueo[i].tag = "DefeatPoint";

                if (puertaBloqueo[i].GetComponent<DefeatPointHandler>() == null)
                {
                    puertaBloqueo[i].AddComponent<DefeatPointHandler>();
                }

                puertaBloqueo[i].SetActive(true);
                //Debug.Log(i+1);

                if (!enemySpawner.spawnDoors.Contains(puertaBloqueo[i]))
                {
                    enemySpawner.spawnDoors.Add(puertaBloqueo[i]);
                }

                AssignDoorToConfiguration(puertaBloqueo[i]);
                defeatPoints.AddPoint(puertaBloqueo[i].transform);
            }
            Destroy(this.gameObject);
        }
    }
    private void AssignDoorToConfiguration(GameObject activatedDoor)
    {
        foreach (SpawnConfiguration config in enemySpawner.spawnConfigurations)
        {
            if (config.door == null)
            {
                config.door = activatedDoor;
                break;
            }
        }
    }
}
