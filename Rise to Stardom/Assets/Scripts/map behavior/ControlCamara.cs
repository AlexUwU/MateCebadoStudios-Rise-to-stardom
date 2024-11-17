using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
<<<<<<< Updated upstream
    public Camera cam;
    public Transform salaActual;

    public Transform salaSiguiente;
    
    [SerializeField] private Transform salaTemp;

    private bool camaraMovida = false;
=======

    public Camera cam;
    public Transform salaOrigen;
    public Transform salaDestino;

    private Transform salaTemp;

    private bool cambiado;

    private Vector3 vectorTemp;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream

=======
        cambiado = false;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< Updated upstream
    void OnTriggerEnter(Collider colision){
        Vector3 temp = new Vector3(salaSiguiente.transform.position.x, salaSiguiente.transform.position.y + 25, salaSiguiente.transform.position.z - 15);
        if (colision.gameObject.tag == "Player" && !camaraMovida){
            if(cam.transform.position == temp ){
                invertirTriggers();
                temp = new Vector3(salaSiguiente.transform.position.x, salaSiguiente.transform.position.y + 25, salaSiguiente.transform.position.z - 15);
                cam.transform.position = temp;
                cam.transform.LookAt(salaSiguiente);
                camaraMovida = true;
            } else
            cam.transform.position = temp;
            cam.transform.LookAt(salaSiguiente);
            invertirTriggers();
            camaraMovida = true;
        }
    }

    void OnTriggerExit (Collider colision){
        if(colision.gameObject.tag == "Player" && camaraMovida){
            camaraMovida = false;
        }
    }

    void invertirTriggers(){
        salaTemp = salaSiguiente;
        salaSiguiente = salaActual;
        salaActual = salaTemp;
        salaTemp = null;
    }


=======
    void OnTriggerEnter(Collider target){
        vectorTemp = new Vector3(salaDestino.transform.position.x, salaDestino.transform.position.y+15, salaDestino.transform.position.z-14);
        if(target.gameObject.tag == "Player" && !cambiado){
            if(cam.transform.position == vectorTemp){
               invertirSalas(); 
               vectorTemp = new Vector3(salaDestino.transform.position.x, salaDestino.transform.position.y+15, salaDestino.transform.position.z-14);
            }
            cam.transform.position = vectorTemp;
            cam.transform.LookAt(salaDestino);
            invertirSalas();
            cambiado = true;
        }
    }

    void OnTriggerExit(Collider target){
        if(target.gameObject.tag == "Player" && cambiado){
            cambiado = false;
        }
    }

    void invertirSalas(){
        salaTemp = salaDestino;
        salaDestino = salaOrigen;
        salaOrigen = salaTemp;
    }
>>>>>>> Stashed changes
}
