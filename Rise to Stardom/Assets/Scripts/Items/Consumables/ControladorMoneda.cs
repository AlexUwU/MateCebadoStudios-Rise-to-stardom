using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMoneda : MonoBehaviour
{

    private GameObject player;

    void Start(){
        player = GameObject.Find("Player");
        gameObject.transform.Rotate(35f, 0f, 0f);
    }
    
    void OnTriggerEnter(Collider target){
        if (target.gameObject.tag=="Player"){
            player.GetComponent<PlayerStats>().pickupCoin();
            Destroy(gameObject);
        }
    }
}
