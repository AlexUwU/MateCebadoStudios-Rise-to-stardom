using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    private Camera cam;
    public Transform salaOrigen;
    public Transform salaDestino;

    private Transform salaTemp;

    private bool cambiado;

    private Vector3 vectorTemp;

    [SerializeField] ControlMuroCruce muro1Trigger;
    [SerializeField] ControlMuroCruce muro2Trigger;


    // Start is called before the first frame update
    void Start()
    {
        cambiado = false;
        cam = GameObject.Find("Camera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target){
        vectorTemp = new Vector3(salaDestino.transform.position.x, salaDestino.transform.position.y+18, salaDestino.transform.position.z-13);
        if(target.gameObject.tag == "Player" && !cambiado){
            if(cam.transform.position == vectorTemp){
               invertirSalas(); 
               vectorTemp = new Vector3(salaDestino.transform.position.x, salaDestino.transform.position.y+18, salaDestino.transform.position.z-13);
            }
            cam.transform.position = vectorTemp;
            //cam.transform.LookAt(salaDestino);
            invertirSalas();
            cambiado = true;
        }
    }

    void OnTriggerExit(Collider target){
        if(target.gameObject.tag=="Player"){
            muro1Trigger.jugadorFuera();
            muro2Trigger.jugadorFuera();
        }
        if(target.gameObject.tag == "Player" && cambiado){
            cambiado = false;
        }
    }

    void invertirSalas(){
        salaTemp = salaDestino;
        salaDestino = salaOrigen;
        salaOrigen = salaTemp;
    }
}
