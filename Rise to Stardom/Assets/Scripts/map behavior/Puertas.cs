using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject[] puertaBloqueo;
    public GameBehaviour gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameBehaviour>();
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
                
                puertaBloqueo[i].SetActive(true);
                Debug.Log(i+1);
                
            }
            Destroy(this.gameObject);
        }
    }
}
