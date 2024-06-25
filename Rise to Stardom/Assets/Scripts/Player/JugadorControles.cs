using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovimientoJugador))]
public class JugadorControles : MonoBehaviour
{
    [SerializeField] Camera camara;
    MovimientoJugador motor;
    PersonajeEstadisticas stad;

    private void Start()
    {
        motor = GetComponent<MovimientoJugador>();
        stad = GetComponent<PersonajeEstadisticas>();
    }
    private void Update()
    {
        ////////////////////////// INTERACTUAR /////////////////////
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                //hacer cosas cuando se cliquea algo
                Debug.Log(hit.collider.name + hit.point);
            }
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
