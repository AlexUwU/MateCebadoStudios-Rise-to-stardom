using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider Objeto)
    {
        Debug.Log("Entro");
    }
    private void OnTriggerStay(Collider Objeto)
    {
        Debug.Log("Mantengo");
    }
    private void OnTriggerExit(Collider Objeto)
    {
        Debug.Log("Adios");
    }
}
