using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovimientoJugador))]
[RequireComponent(typeof(PersonajeEstadisticas))]
public class JugadorControles : MonoBehaviour
{
    [SerializeField] Camera camara;
    [SerializeField] Transform inventarioCanvas;
    InventarioUI inventarioUI;
    MovimientoJugador motor;
    PersonajeEstadisticas stad;

    public Interactuable focus;

    private void Start()
    {
        inventarioUI = inventarioCanvas.GetComponentInChildren<InventarioUI>();
        motor = GetComponent<MovimientoJugador>();
        stad = GetComponent<PersonajeEstadisticas>();
    }
    private void Update()
    {
        ////////////////////////// Disparar /////////////////////
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                //hacer cosas cuando se cliquea algo
                Debug.Log("Disparo");
            }
        }
        /////////////////////// USAR INSTRUMENTO ///////////////////
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventarioUI.tocarInstrumento();
        }
        ////////////////////////// PRUEbA DAÑO //////////////////////////////////
        if (Input.GetKeyDown(KeyCode.T))
        {
            stad.RecibirDmg(1);
        }
        ////////////////// MOVIMIENTO ////////////////////////////
        if (Input.GetKey(KeyCode.W))
        {
           motor.Moverse(Vector3.forward, stad.velMov.GetValor());
        }
        if (Input.GetKey(KeyCode.S))
        {
            motor.Moverse(Vector3.forward, -stad.velMov.GetValor());
        }
        if (Input.GetKey(KeyCode.D))
        {
            motor.Moverse(Vector3.right, stad.velMov.GetValor());
        }
        if (Input.GetKey(KeyCode.A))
        {
            motor.Moverse(Vector3.right, -stad.velMov.GetValor());
        }
    }
}
