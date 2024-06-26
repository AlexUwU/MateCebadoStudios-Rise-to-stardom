using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovimientoJugador))]
[RequireComponent(typeof(ProtagonistaEstadisticas))]
[RequireComponent(typeof(DispararJugador))]
public class JugadorControles : MonoBehaviour
{
    [SerializeField] Camera camara;
    [SerializeField] Transform inventarioCanvas;
    InventarioUI inventarioUI;
    MovimientoJugador motor;
    DispararJugador disparar;
    ProtagonistaEstadisticas stad;

    private void Start()
    {
        inventarioUI = inventarioCanvas.GetComponentInChildren<InventarioUI>();
        motor = GetComponent<MovimientoJugador>();
        stad = GetComponent<ProtagonistaEstadisticas>();
        disparar = GetComponent<DispararJugador>();
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
                if(stad.dmg.GetValor() > 0)
                    disparar.Disparar(hit,stad.dmg.GetValor(), stad.velProy.GetValor());
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
            stad.RecibirDmg(stad.dmg.GetValor());
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
