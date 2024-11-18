using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject celda;
    public PlayerStats player;
    
    private bool playerOnTop;

    void Start(){
        playerOnTop = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            if(playerOnTop && player.coinCheck() >= 10){
                celda.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider target){
        if(target.gameObject.tag == "Player"){
            playerOnTop = true;
        }
    }                                                               

    void OnTriggerExit(Collider target){
        if(target.gameObject.tag == "Player"){
            playerOnTop = false;
        }
    }

    

}



