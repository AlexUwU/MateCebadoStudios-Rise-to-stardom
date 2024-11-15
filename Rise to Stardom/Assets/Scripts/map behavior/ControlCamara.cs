using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Camera cam;
    public Transform salaActual;

    public Transform salaSiguiente;
    
    [SerializeField] private Transform salaTemp;

    private bool camaraMovida = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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


}
