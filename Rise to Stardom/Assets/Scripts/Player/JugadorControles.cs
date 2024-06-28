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
    private bool tempo = true;

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
        if (Input.GetMouseButton(0))
        {
            //No dispara si la variable "tempo" no es verdadera.
            if (tempo)
            {
                Ray ray = camara.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    //No dispara si el daño es 0.
                    if (stad.dmg.GetValor() > 0)
                    {
                        disparar.Disparar(hit, stad.dmg.GetValor(), stad.velProy.GetValor());
                        StartCoroutine(Tempo());
                    }
                }
            }
        }
        /////////////////////// USAR INSTRUMENTO ///////////////////
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventarioUI.tocarInstrumento();
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


    //Sirve para determinar la velocidad de ataque del protagonista.
    IEnumerator Tempo()
    {
        tempo = false;
        //Tras disparar se cambia su valor, evitando que el jugador haga mas llamados.
        Debug.Log("Instrumento suena");
        yield return new WaitForSeconds(stad.velAtq.GetValor());
        tempo = true;
        //Pasado el tiempo, determinado por la velocidad de ataque del jugador, cambia de nuevo el valor de la variable.
    }
}
