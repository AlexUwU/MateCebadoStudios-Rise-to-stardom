using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovimientoJugador))]
[RequireComponent(typeof(PersonajeEstadisticas))]
public class JugadorControles : MonoBehaviour
{
    [SerializeField] Camera camara;
    MovimientoJugador motor;
    PersonajeEstadisticas stad;

    public Interactuable focus;

    private void Start()
    {
        motor = GetComponent<MovimientoJugador>();
        stad = GetComponent<PersonajeEstadisticas>();
    }
    private void Update()
    {
        ////////////////////////// INTERACTUAR /////////////////////
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                //hacer cosas cuando se cliquea algo
                Interactuable interactuable = hit.collider.GetComponent<Interactuable>();
                if(interactuable != null)
                {
                    SetFocus(interactuable);
                }
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            RemoveFocus();
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

    void SetFocus(Interactuable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
    }
}
