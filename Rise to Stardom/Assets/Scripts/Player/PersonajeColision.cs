using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeColision : MonoBehaviour
{
    [SerializeField] GameObject personaje;
    private void OnTriggerEnter(Collider Pared)
    {
        Debug.Log("Entro");
    }
    private void OnTriggerStay(Collider Pared)
    {
        Debug.Log("Mantengo");
    }
    private void OnTriggerExit(Collider Pared)
    {
        Debug.Log("Adios");
    }
}
