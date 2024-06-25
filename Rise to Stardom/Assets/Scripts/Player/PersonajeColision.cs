using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider terreno)
    {
        Debug.Log("hola");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Mantengo");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Adios");
    }
}
